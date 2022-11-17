using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database;
using FantasyBaseball.PlayerService.Entities;
using LazyCache;
using Microsoft.EntityFrameworkCore;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for getting teams.</summary>
    public class GetTeamsService : IGetTeamsService
    {
        private readonly IAppCache _cache;
        private readonly IPlayerContext _context;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="context">The player context.</param>
        /// <param name="cache">The in-memory cache for storing short-term items.</param>
        public GetTeamsService(IPlayerContext context, IAppCache cache) => (_cache, _context) = (cache, context);

        /// <summary>Gets the teams from the underlying source.</summary>
        /// <returns>A list of the teams.</returns>
        public async Task<List<TeamEntity>> GetTeams() =>
            await _cache.GetOrAddAsync<List<TeamEntity>>("teams", () => _context.Teams.ToListAsync());
    }
}