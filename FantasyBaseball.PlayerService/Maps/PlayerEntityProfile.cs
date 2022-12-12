using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Maps
{
  /// <summary>A new profile for the PlayerEntity objects.</summary>
  public class PlayerEntityProfile : Profile
  {
    /// <summary>Create a new instance of the profile.</summary>
    public PlayerEntityProfile()
    {
      CreateMap<BaseballPlayerV2, PlayerEntity>()
        .ForMember(dest => dest.LeagueStatuses, opt => opt.MapFrom(src => GetLeagueStatuses(src)))
        .ForMember(dest => dest.Positions, opt => opt.MapFrom(src => GetPositionEntities(src)))
        .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.Team.Code));
      CreateMap<BattingStats, BattingStatsEntity>();
      CreateMap<PitchingStats, PitchingStatsEntity>();
    }

    private static List<PlayerLeagueStatusEntity> GetLeagueStatuses(BaseballPlayerV2 player) =>
      new List<PlayerLeagueStatusEntity>
      {
        new PlayerLeagueStatusEntity { PlayerId = player.Id, LeagueId = 1, LeagueStatus = player.League1 },
        new PlayerLeagueStatusEntity { PlayerId = player.Id, LeagueId = 2, LeagueStatus = player.League2 }
      };

    private static List<PlayerPositionEntity> GetPositionEntities(BaseballPlayerV2 player) =>
      player.Positions.Select(p => new PlayerPositionEntity { PlayerId = player.Id, PositionCode = p.Code }).ToList();
  }
}