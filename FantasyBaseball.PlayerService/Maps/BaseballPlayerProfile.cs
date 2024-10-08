using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Builders;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Maps
{
  /// <summary>A new profile for the BaseballPlayer objects.</summary>
  public class BaseballPlayerProfile : Profile
  {
    /// <summary>Create a new instance of the profile.</summary>
    public BaseballPlayerProfile()
    {
      CreateMap<BattingStatsEntity, BattingStats>();
      CreateMap<PitchingStatsEntity, PitchingStats>();
      CreateMap<PlayerEntity, BaseballPlayer>()
        .ForMember(dest => dest.League1, opt => opt.MapFrom(src => GetLeagueStatus(src, 1)))
        .ForMember(dest => dest.League2, opt => opt.MapFrom(src => GetLeagueStatus(src, 2)))
        .ForMember(dest => dest.Positions, opt => opt.Ignore())
        .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.PlayerTeam))
        .AfterMap((src, dest) => BuildStats(dest));
      CreateMap<TeamEntity, BaseballTeam>();
    }

    private static void BuildStats(BaseballPlayer player)
    {
      ReplaceBattingStats(player.BattingStats, StatsType.YTD);
      ReplaceBattingStats(player.BattingStats, StatsType.PROJ);
      ReplaceBattingStats(player.BattingStats, StatsType.CMBD, new BattingStatsBuilder()
        .AddStats(player.BattingStats.Find(b => b.StatsType == StatsType.YTD))
        .AddStats(player.BattingStats.Find(b => b.StatsType == StatsType.PROJ))
        .SetStatsType(StatsType.CMBD)
        .Build());
      player.BattingStats = [.. player.BattingStats.OrderBy(p => p.StatsType)];
      ReplacePitchingStats(player.PitchingStats, StatsType.YTD);
      ReplacePitchingStats(player.PitchingStats, StatsType.PROJ);
      ReplacePitchingStats(player.PitchingStats, StatsType.CMBD, new PitchingStatsBuilder()
        .AddStats(player.PitchingStats.Find(p => p.StatsType == StatsType.YTD))
        .AddStats(player.PitchingStats.Find(p => p.StatsType == StatsType.PROJ))
        .SetStatsType(StatsType.CMBD)
        .Build());
      player.PitchingStats = [.. player.PitchingStats.OrderBy(p => p.StatsType)];
    }

    private static LeagueStatus GetLeagueStatus(PlayerEntity entity, int leagueId) =>
      entity.LeagueStatuses.Where(s => s.LeagueId == leagueId).Select(s => s.LeagueStatus).FirstOrDefault();

    private static void ReplaceBattingStats(List<BattingStats> stats, StatsType statsType, BattingStats value = null) =>
      ReplaceStats(stats, s => s.StatsType == statsType, s => value ?? new BattingStatsBuilder().AddStats(s).SetStatsType(statsType).Build());

    private static void ReplacePitchingStats(List<PitchingStats> stats, StatsType statsType, PitchingStats value = null) =>
      ReplaceStats(stats, s => s.StatsType == statsType, s => value ?? new PitchingStatsBuilder().AddStats(s).SetStatsType(statsType).Build());

    private static void ReplaceStats<T>(List<T> stats, Predicate<T> statsFinder, Func<T, T> builder)
    {
      var statLine = stats.Find(s => statsFinder(s));
      var index = stats.IndexOf(statLine);
      if (index != -1) stats[index] = builder(statLine);
      else stats.Add(builder(statLine));
    }
  }
}