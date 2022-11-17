using System;
using System.Threading.Tasks;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database;
using Microsoft.EntityFrameworkCore;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for updaing a player.</summary>
    public class PlayerUpdateService : IPlayerUpdateService
    {
        private readonly IPlayerContext _context;
        private readonly IPlayerEntityMergerService _entityMerger;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="context">The player context.</param>
        /// <param name="entityMerger">Service for converting a BaseballPlayer to a PlayerEntity.</param>
        public PlayerUpdateService(IPlayerContext context, IPlayerEntityMergerService entityMerger) =>
            (_context, _entityMerger) = (context, entityMerger);

        /// <summary>Updates the given player.</summary>
        /// <param name="player">The player to update.</param>
        public async Task UpdatePlayer(BaseballPlayer player)
        {
            var existingPlayer = await _context.Players
                .Include(p => p.LeagueStatuses)
                .Include(p => p.PlayerTeam)
                .Include(p => p.Positions)
                .Include(p => p.BattingStats)
                .Include(p => p.PitchingStats)
                .FirstOrDefaultAsync(p => p.Id == player.Id);
            if (existingPlayer == null) throw new BadRequestException("This player does not exist");
            var updatedPlayer = await _entityMerger.MergePlayerEntity(player, existingPlayer);
            try
            {
                await _context.BeginTransaction();
                _context.Players.Update(updatedPlayer);
                await _context.Commit();
            }
            catch (Exception)
            {
                await _context.Rollback();
                throw;
            }
        }
    }
}