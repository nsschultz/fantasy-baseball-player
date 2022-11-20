using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for updaing a player.</summary>
    public class UpdatePlayerService : IUpdatePlayerService
    {
        private readonly IPlayerEntityMergerService _entityMerger;
        private readonly IPlayerRepository _playerRepo;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
        /// <param name="entityMerger">Service for converting a BaseballPlayer to a PlayerEntity.</param>
        public UpdatePlayerService(IPlayerRepository playerRepo, IPlayerEntityMergerService entityMerger) =>
            (_playerRepo, _entityMerger) = (playerRepo, entityMerger);

        /// <summary>Updates the given player.</summary>
        /// <param name="player">The player to update.</param>
        public async Task UpdatePlayer(BaseballPlayerV2 player)
        {
            var existingPlayer = await _playerRepo.GetPlayerById(player.Id);
            if (existingPlayer == null) throw new BadRequestException("This player does not exist");
            var updatedPlayer = await _entityMerger.MergePlayerEntity(player, existingPlayer);
            await _playerRepo.UpdatePlayer(updatedPlayer);
        }
    }
}