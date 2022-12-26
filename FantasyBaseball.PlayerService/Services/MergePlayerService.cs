using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services.Mergers;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for converting a BaseballPlayer to a PlayerEntity.</summary>
  public class MergePlayerService : IMergePlayerService
  {
    private static readonly List<StatsType> ExpectedStats = new List<StatsType> { StatsType.YTD, StatsType.PROJ };
    private readonly IGetPositionService _positionsService;
    private readonly IGetTeamsService _teamsService;
    private readonly IMapper _mapper;

    /// <summary>Creates a new instance of the service.</summary>
    /// <param name="mapper">Instance of the auto mapper.</param>
    /// <param name="positionsService">Service for getting players.</param>
    /// <param name="teamsService">Service for getting teams.</param>
    public MergePlayerService(IMapper mapper, IGetPositionService positionsService, IGetTeamsService teamsService) =>
        (_mapper, _positionsService, _teamsService) = (mapper, positionsService, teamsService);

    /// <summary>Merges a BaseballPlayer into a PlayerEntity.</summary>
    /// <param name="merger">Function for merging</param>
    /// <param name="incoming">The incoming player values.</param>
    /// <param name="existing">The existing player values.</param>
    /// <returns>An object that can be saved to the database.</returns>
    public async Task<PlayerEntity> MergePlayer(IPlayerMerger merger, BaseballPlayer incoming, PlayerEntity existing)
    {
      var positions = await _positionsService.GetPositions();
      var teams = await _teamsService.GetTeams();
      var entity = merger.MergePlayer(_mapper, incoming, existing);
      ValidateStats(entity);
      ValidatePositions(positions, entity);
      ValidateTeam(teams, entity);
      return entity;
    }

    private static PlayerPositionEntity FindDefaultPosition(List<BaseballPosition> positions, PlayerEntity existing)
    {
      var max = positions.Where(p => p.PlayerType == existing.Type).Max(p => p.SortOrder);
      return new PlayerPositionEntity { PositionCode = positions.First(p => p.SortOrder == max).Code };
    }

    private static void ValidatePositions(List<BaseballPosition> positions, PlayerEntity entity)
    {
      if (positions == null) return;
      var positionSet = positions.Select(p => p.Code).ToHashSet();
      entity.Positions = entity.Positions.Where(p => positionSet.Contains(p.PositionCode.Trim().ToUpper())).ToList();
      if (!entity.Positions.Any()) entity.Positions.Add(FindDefaultPosition(positions, entity));
    }

    private static void ValidateStats(PlayerEntity entity)
    {
      entity.BattingStats = entity.BattingStats != null
        ? entity.BattingStats.Where(b => ExpectedStats.Contains(b.StatsType)).ToList()
        : new List<BattingStatsEntity>();
      entity.PitchingStats = entity.PitchingStats != null
        ? entity.PitchingStats.Where(b => ExpectedStats.Contains(b.StatsType)).ToList()
        : new List<PitchingStatsEntity>();
    }

    private static void ValidateTeam(List<TeamEntity> teams, PlayerEntity entity)
    {
      if (teams == null) return;
      var teamCode = string.IsNullOrWhiteSpace(entity.Team) ? string.Empty : entity.Team.Trim().ToUpper();
      var team = teams.FirstOrDefault(t => t.Code == teamCode || (!string.IsNullOrWhiteSpace(t.AlternativeCode) && t.AlternativeCode == teamCode));
      team = team ?? teams.FirstOrDefault(t => t.Code == string.Empty);
      entity.Team = team.Code;
    }
  }
}