using System;
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
  /// <summary>Service for merging a CSV file into the existing data store.</summary>
  public class MergeStatsService : IMergeStatsService
  {
    private static readonly Dictionary<Tuple<PlayerType, StatsType>, ClassMap> CsvFileMaps = new()
    {
      { new Tuple<PlayerType, StatsType>(PlayerType.B, StatsType.YTD ), new BhqYtdBattingsStatsMap() },
      { new Tuple<PlayerType, StatsType>(PlayerType.B, StatsType.PROJ ), new BhqProjBattingsStatsMap() },
      { new Tuple<PlayerType, StatsType>(PlayerType.P, StatsType.YTD ), new BhqYtdPitchingStatsMap() },
      { new Tuple<PlayerType, StatsType>(PlayerType.P, StatsType.PROJ ), new BhqProjPitchingStatsMap() }
    };
    private readonly IPlayerMerger _merger = new BhqPlayerMerger();
    private readonly ICsvFileReaderService _fileReaderService;
    private readonly IMergePlayerService _mergeService;
    private readonly IPlayerRepository _playerRepo;
    private readonly IBattingStatsRepository _battingStatsRepo;
    private readonly IPitchingStatsRepository _pitchingStatsRepo;

    /// <summary>Creates a new instance of the service.</summary>
    /// <param name="fileReaderService">Service for reading CSV file.</param>
    /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
    /// <param name="mergeService">Service for converting a BaseballPlayer to a PlayerEntity.</param>
    /// <param name="battingStatsRepo">Repo for CRUD functionality regarding to batting stats.</param>
    /// <param name="pitchingStatsRepo">Repo for CRUD functionality regarding to pitching stats.</param>
    public MergeStatsService(
        IPlayerRepository playerRepo,
        ICsvFileReaderService fileReaderService,
        IMergePlayerService mergeService,
        IBattingStatsRepository battingStatsRepo,
        IPitchingStatsRepository pitchingStatsRepo) =>
      (_playerRepo, _fileReaderService, _mergeService, _battingStatsRepo, _pitchingStatsRepo) =
       (playerRepo, fileReaderService, mergeService, battingStatsRepo, pitchingStatsRepo);

    /// <summary>Reads in data from the given CSV file and merges it into the existing data store.</summary>
    /// <param name="fileReader">Helper for reading the contents of a file.</param>
    /// <param name="player">The type of player to update.</param>
    /// <param name="stats">The type of stats being loaded.</param>
    /// <returns>The count of players from the file that were merged in.</returns>
    public async Task<int> MergeStats(IFileReader fileReader, PlayerType player, StatsType stats)
    {
      var tuple = new Tuple<PlayerType, StatsType>(player, stats);
      var incomingPlayers = await _fileReaderService.ReadCsvData(CsvFileMaps[tuple], fileReader);
      if (incomingPlayers.Count == 0) return 0;
      await CleanupStats(player, stats);
      var existingPlayers = await _playerRepo.GetPlayers(player);
      var existingDictionary = existingPlayers.GroupBy(BuildKey).ToDictionary(g => g.Key, g => g.First());
      var mergedPlayers = await MergePlayers(existingDictionary, incomingPlayers);
      await _playerRepo.UpsertPlayers(mergedPlayers);
      return incomingPlayers.Count;
    }

    private static Tuple<int, PlayerType> BuildKey(CsvBaseballPlayer player) => new(player.BhqId, player.Type);

    private static Tuple<int, PlayerType> BuildKey(PlayerEntity player) => new(player.BhqId, player.Type);

    private async Task CleanupStats(PlayerType playerType, StatsType statsType)
    {
      if (playerType == PlayerType.B) await _battingStatsRepo.DeleteAllBattingStats(statsType);
      else await _pitchingStatsRepo.DeleteAllPitchingStats(statsType);
    }

    private static PlayerEntity FindAndRemovePlayer(Dictionary<Tuple<int, PlayerType>, PlayerEntity> existingDictionary, Tuple<int, PlayerType> key)
    {
      if (!existingDictionary.TryGetValue(key, out PlayerEntity value)) return null;
      var existingPlayer = value;
      existingDictionary.Remove(key);
      return existingPlayer;
    }

    private async Task<PlayerEntity> MergePlayer(PlayerEntity existing, CsvBaseballPlayer bhqData) =>
      await _mergeService.MergePlayer(_merger, bhqData, existing);

    private async Task<List<PlayerEntity>> MergePlayers(
      Dictionary<Tuple<int, PlayerType>, PlayerEntity> existingPlayers,
      List<CsvBaseballPlayer> incomingPlayers)
    {
      var mergedPlayers = new List<Task<PlayerEntity>>();
      mergedPlayers.AddRange(incomingPlayers.Select(b => MergePlayer(FindAndRemovePlayer(existingPlayers, BuildKey(b)), b)));
      mergedPlayers.AddRange(existingPlayers.Values.Select(e => MergePlayer(e, new CsvBaseballPlayer())));
      return [.. (await Task.WhenAll(mergedPlayers))];
    }
  }
}