using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.FileReaders;
using FantasyBaseball.PlayerService.Maps.CsvMaps;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services.Mergers;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for merging the CSV file into the existing data store.</summary>
    public class MergeProjectionService : IMergeProjectionService
    {
        private static readonly Dictionary<PlayerType, ClassMap> CsvFileMaps = new Dictionary<PlayerType, ClassMap>
        {
            { PlayerType.B, new BhqBattingStatsMap() },
            { PlayerType.P, new BhqPitchingStatsMap() }
        };
        private readonly IPlayerMerger _merger = new BhqPlayerMerger();
        private readonly ICsvFileReaderService _fileReaderService;
        private readonly IMergePlayerService _mergeService;
        private readonly IPlayerRepository _playerRepo;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="fileReaderService">Service for reading CSV file.</param>
        /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
        /// <param name="mergeService">Service for converting a BaseballPlayer to a PlayerEntity.</param>
        public MergeProjectionService(IPlayerRepository playerRepo, ICsvFileReaderService fileReaderService, IMergePlayerService mergeService) =>
            (_playerRepo, _fileReaderService, _mergeService) = (playerRepo, fileReaderService, mergeService);

        /// <summary>Reads in data from the given CSV file and merges it into the existing data store.</summary>
        /// <param name="fileReader">Helper for reading the contents of a file.</param>
        /// <param name="type">The type of player to update.</param>
        /// <returns>The count of players from the file that were merged in.</returns>
        public async Task<int> MergeProjection(IFileReader fileReader, PlayerType type)
        {
            var projectedPlayers = await _fileReaderService.ReadCsvData(CsvFileMaps[type], fileReader);
            if (projectedPlayers.Count == 0) return 0;
            var existingPlayers = await _playerRepo.GetPlayers(type);
            var existingDictionary = existingPlayers.GroupBy(p => BuildKey(p)).ToDictionary(g => g.Key, g => g.First());
            var mergedPlayers = await MergePlayers(existingDictionary, projectedPlayers);
            await _playerRepo.UpsertPlayers(mergedPlayers);
            return projectedPlayers.Count;
        }

        private static ProjectionKey BuildKey(CsvBaseballPlayer player) => new ProjectionKey(player.BhqId, player.Type);

        private static ProjectionKey BuildKey(PlayerEntity player) => new ProjectionKey(player.BhqId, player.Type);

        private static PlayerEntity FindAndRemovePlayer(Dictionary<ProjectionKey, PlayerEntity> existingDictionary, ProjectionKey key)
        {
            if (!existingDictionary.ContainsKey(key)) return null;
            var existingPlayer = existingDictionary[key];
            existingDictionary.Remove(key);
            return existingPlayer;
        }

        private async Task<PlayerEntity> MergePlayer(PlayerEntity existing, CsvBaseballPlayer bhqData) =>
            await _mergeService.MergePlayer(_merger, bhqData, existing);

        private async Task<List<PlayerEntity>> MergePlayers(Dictionary<ProjectionKey, PlayerEntity> existingPlayers, List<CsvBaseballPlayer> projectedPlayers)
        {
            var mergedPlayers = new List<Task<PlayerEntity>>();
            mergedPlayers.AddRange(projectedPlayers.Select(b => MergePlayer(FindAndRemovePlayer(existingPlayers, BuildKey(b)), b)));
            mergedPlayers.AddRange(existingPlayers.Values.Select(e => MergePlayer(e, new CsvBaseballPlayer())));
            return (await Task.WhenAll(mergedPlayers)).ToList();
        }
    }
}