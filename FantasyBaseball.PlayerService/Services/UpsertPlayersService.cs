using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for upsert players.</summary>
    public class UpsertPlayersService : IUpsertPlayersService
    {
        private readonly IMergePlayerService _mergeService;
        private readonly IPlayerRepository _playerRepo;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
        /// <param name="mergeService">Service for converting a BaseballPlayer to a PlayerEntity.</param>
        public UpsertPlayersService(IPlayerRepository playerRepo, IMergePlayerService mergeService) =>
            (_playerRepo, _mergeService) = (playerRepo, mergeService);

        /// <summary>Gets the players from the underlying source.</summary>
        /// <param name="players">All of the players to upsert into the source.</param>
        public async Task UpsertPlayers(List<BaseballPlayerV2> players)
        {
            var mergedPlayers = players.Select(async p => await _mergeService.MergePlayer(p, await FindEntity(p)));
            await _playerRepo.UpsertPlayers(await Task.WhenAll(mergedPlayers));
        }

        private async Task<PlayerEntity> FindEntity(BaseballPlayerV2 player) =>
            player.Id != default
                ? await _playerRepo.GetPlayerById(player.Id)
                : await _playerRepo.GetPlayerByBhqId(player.BhqId, player.Type);
    }
}