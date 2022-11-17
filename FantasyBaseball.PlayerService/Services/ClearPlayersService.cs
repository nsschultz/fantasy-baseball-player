using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for removing all of the players from the database.</summary>
    public class ClearPlayerService : IClearPlayerService
    {
        private readonly IPlayerContext _context;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="context">The player context.</param>
        public ClearPlayerService(IPlayerContext context) => _context = context;

        /// <summary>Removes all of the players from the database.</summary>
        public async Task ClearAllPlayers()
        {
            try
            {
                await _context.BeginTransaction();
                _context.Players.RemoveRange(_context.Players);
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