using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for converting a BaseballPlayer to a PlayerEntity.</summary>
    public class PlayerEntityMergerService : IPlayerEntityMergerService
    {
        private static readonly List<StatsType> ExpectedStats = new List<StatsType> { StatsType.YTD, StatsType.PROJ };
        private readonly IGetPositionService _positionsService;
        private readonly IGetTeamsService _teamsService;
        private readonly IMapper _mapper;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="mapper">Instance of the auto mapper.</param>
        /// <param name="positionsService">Service for getting players.</param>
        /// <param name="teamsService">Service for getting teams.</param>
        public PlayerEntityMergerService(IMapper mapper, IGetPositionService positionsService, IGetTeamsService teamsService) =>
            (_mapper, _positionsService, _teamsService) = (mapper, positionsService, teamsService);

        /// <summary>Merges a BaseballPlayer into a PlayerEntity.</summary>
        /// <param name="incoming">The incoming player values.</param>
        /// <param name="existing">The existing player values.</param>
        /// <returns>An object that can be saved to the database.</returns>
        public async Task<PlayerEntity> MergePlayerEntity(BaseballPlayerV2 incoming, PlayerEntity existing)
        {
            if (incoming == null) return existing;
            var positions = await _positionsService.GetPositions();
            var teams = await _teamsService.GetTeams();
            var entity = _mapper.Map(incoming, existing);
            MergePositions(incoming.Positions, positions, entity);
            MergeTeam(incoming.Team, teams, entity);
            return entity;
        }

        private static PlayerPositionEntity FindDefaultPosition(List<BaseballPosition> positions, PlayerEntity existing)
        {
            var max = positions.Where(p => p.PlayerType == existing.Type).Max(p => p.SortOrder);
            return new PlayerPositionEntity { PositionCode = positions.First(p => p.SortOrder == max).Code };
        }

        private static void MergePositions(List<BaseballPosition> incomingPostions, List<BaseballPosition> fullPositionList, PlayerEntity entity)
        {
            if (fullPositionList == null) return;
            entity.Positions.Clear();
            var positionSet = fullPositionList.Select(p => p.Code).ToHashSet();
            var positionCodes = incomingPostions != null ? incomingPostions.Select(p => p.Code) : Array.Empty<string>();
            entity.Positions.AddRange(positionCodes
                .Select(p => p.Trim().ToUpper())
                .Where(p => positionSet.Contains(p))
                .Select(p => new PlayerPositionEntity { PositionCode = p }));
            if (!entity.Positions.Any()) entity.Positions.Add(FindDefaultPosition(fullPositionList, entity));
        }

        private static void MergeTeam(BaseballTeam incomingTeam, List<TeamEntity> fullTeamList, PlayerEntity entity)
        {
            if (fullTeamList == null) return;
            var incomingCode = string.IsNullOrWhiteSpace(incomingTeam?.Code) ? string.Empty : incomingTeam.Code.Trim().ToUpper();
            var team = fullTeamList
                .FirstOrDefault(t => t.Code == incomingCode || (!string.IsNullOrWhiteSpace(t.AlternativeCode) && t.AlternativeCode == incomingCode));
            team = team ?? fullTeamList.FirstOrDefault(t => t.Code == string.Empty);
            entity.PlayerTeam = team;
            entity.Team = team.Code;
        }
    }
}