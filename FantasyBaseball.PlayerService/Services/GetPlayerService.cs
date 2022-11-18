using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database;
using FantasyBaseball.PlayerService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for getting players.</summary>
    public class GetPlayersService : IGetPlayersService
    {
        private readonly IGetPositionService _positionsService;
        private readonly IMapper _mapper;
        private readonly IPlayerContext _context;
        private readonly ISortService _sortService;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="context">The player context.</param>
        /// <param name="mapper">Instance of the auto mapper.</param>
        /// <param name="positionsService">Service for getting players.</param>
        /// <param name="sortService">The service for sorting the players.</param>
        public GetPlayersService(IPlayerContext context,
                                 IMapper mapper,
                                 IGetPositionService positionsService,
                                 ISortService sortService) =>
            (_context, _mapper, _positionsService, _sortService) = (context, mapper, positionsService, sortService);

        /// <summary>Gets the players from the underlying source.</summary>
        /// <returns>A list of the players.</returns>
        public async Task<List<BaseballPlayer>> GetPlayers()
        {
            var positions = await _positionsService.GetPositions();
            var players = await _context.Players
                .Include(p => p.LeagueStatuses)
                .Include(p => p.PlayerTeam)
                .Include(p => p.Positions)
                .Include(p => p.BattingStats)
                .Include(p => p.PitchingStats)
                .ToListAsync();
            var baseballPlayers = players.Select(player => _mapper.Map<PlayerEntity, BaseballPlayer>(player, opt =>
                opt.AfterMap((src, dest) => dest.Positions = BuildBaseballPositions(src, positions))));
            return _sortService.SortPlayers(baseballPlayers.ToList());
        }

        private static List<BaseballPosition> BuildBaseballPositions(PlayerEntity player, List<BaseballPosition> positions) =>
            player.Positions.SelectMany(p => positions.Where(pp => pp.Code == p.PositionCode)).OrderBy(p => p.SortOrder).ToList();
    }
}