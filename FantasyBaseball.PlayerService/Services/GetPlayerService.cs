using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for getting players.</summary>
    public class GetPlayersService : IGetPlayersService
    {
        private readonly IGetPositionService _positionsService;
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepo;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="mapper">Instance of the auto mapper.</param>
        /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
        /// <param name="positionsService">Service for getting players.</param>
        public GetPlayersService(IMapper mapper, IPlayerRepository playerRepo, IGetPositionService positionsService) =>
            (_mapper, _playerRepo, _positionsService) = (mapper, playerRepo, positionsService);

        /// <summary>Gets the players from the underlying source.</summary>
        /// <returns>A list of the players.</returns>
        public async Task<List<BaseballPlayerV2>> GetPlayers()
        {
            var positions = await _positionsService.GetPositions();
            var players = await _playerRepo.GetPlayers();
            var baseballPlayers = players.Select(player => _mapper.Map<PlayerEntity, BaseballPlayerV2>(player, opt =>
                opt.AfterMap((src, dest) => dest.Positions = BuildBaseballPositions(src, positions))));
            return SortPlayers(baseballPlayers.ToList());
        }

        private static List<BaseballPosition> BuildBaseballPositions(PlayerEntity player, List<BaseballPosition> positions) =>
            player.Positions.SelectMany(p => positions.Where(pp => pp.Code == p.PositionCode)).OrderBy(p => p.SortOrder).ToList();

        private static List<BaseballPlayerV2> SortPlayers(List<BaseballPlayerV2> players) =>
            players
                .OrderBy(p => p.Type)
                .ThenBy(p => p.LastName.ToUpper())
                .ThenBy(p => p.FirstName.ToUpper())
                .ThenBy(p => p.BhqId)
                .ToList();
    }
}