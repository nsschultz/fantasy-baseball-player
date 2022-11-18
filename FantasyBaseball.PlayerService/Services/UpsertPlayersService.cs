using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for upsert players.</summary>
    public class UpsertPlayersService : IUpsertPlayersService
    {
        private readonly IPlayerEntityMergerService _entityMerger;
        private readonly IPlayerRepository _playerRepo;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
        /// <param name="entityMerger">Service for converting a BaseballPlayer to a PlayerEntity.</param>
        public UpsertPlayersService(IPlayerRepository playerRepo, IPlayerEntityMergerService entityMerger) =>
            (_playerRepo, _entityMerger) = (playerRepo, entityMerger);

        /// <summary>Gets the players from the underlying source.</summary>
        /// <param name="players">All of the players to upsert into the source.</param>
        public async Task UpsertPlayers(List<BaseballPlayer> players)
        {
            var mergedPlayers = players.Select(async p => await _entityMerger.MergePlayerEntity(p, await FindEntity(p)));
            await _playerRepo.UpsertPlayers(await Task.WhenAll(mergedPlayers));
        }

        private async Task<PlayerEntity> FindEntity(BaseballPlayer player) =>
            player.Id != default
                ? await _playerRepo.GetPlayerById(player.Id)
                : await _playerRepo.GetPlayerByBhqId(player.BhqId, player.Type);

    }
}