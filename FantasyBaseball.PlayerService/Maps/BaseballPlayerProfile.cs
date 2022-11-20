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
            CreateMap<PlayerEntity, BaseballPlayerV2>()
                .ForMember(dest => dest.League1, opt => opt.MapFrom(src => GetLeagueStatus(src, 1)))
                .ForMember(dest => dest.League2, opt => opt.MapFrom(src => GetLeagueStatus(src, 2)))
                .ForMember(dest => dest.Positions, opt => opt.Ignore())
                .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.PlayerTeam))
                .AfterMap((src, dest) => BuildStats(dest));
            CreateMap<TeamEntity, BaseballTeam>();
        }

        private static void BuildStats(BaseballPlayerV2 player)
        {
            ReplaceBattingStats(player.BattingStats, StatsType.YTD);
            ReplaceBattingStats(player.BattingStats, StatsType.PROJ);
            player.BattingStats.Add(new BattingStatsBuilder()
                .AddStats(player.BattingStats.FirstOrDefault(b => b.StatsType == StatsType.YTD))
                .AddStats(player.BattingStats.FirstOrDefault(b => b.StatsType == StatsType.PROJ))
                .SetStatsType(StatsType.CMBD)
                .Build());
            ReplacePitchingStats(player.PitchingStats, StatsType.YTD);
            ReplacePitchingStats(player.PitchingStats, StatsType.PROJ);
            player.PitchingStats.Add(new PitchingStatsBuilder()
                .AddStats(player.PitchingStats.FirstOrDefault(p => p.StatsType == StatsType.YTD))
                .AddStats(player.PitchingStats.FirstOrDefault(p => p.StatsType == StatsType.PROJ))
                .SetStatsType(StatsType.CMBD)
                .Build());
        }

        private static LeagueStatus GetLeagueStatus(PlayerEntity entity, int leagueId) =>
            entity.LeagueStatuses.Where(s => s.LeagueId == leagueId).Select(s => s.LeagueStatus).FirstOrDefault();

        private static void ReplaceBattingStats(List<BattingStats> stats, StatsType statsType) =>
            ReplaceStats(stats, s => s.StatsType == statsType, s => new BattingStatsBuilder().AddStats(s).SetStatsType(statsType).Build());

        private static void ReplacePitchingStats(List<PitchingStats> stats, StatsType statsType) =>
            ReplaceStats(stats, s => s.StatsType == statsType, s => new PitchingStatsBuilder().AddStats(s).SetStatsType(statsType).Build());

        private static void ReplaceStats<T>(List<T> stats, Predicate<T> statsFinder, Func<T, T> builder)
        {
            var statLine = stats.FirstOrDefault(s => statsFinder(s));
            var index = stats.IndexOf(statLine);
            if (index != -1) stats[index] = builder(statLine);
            else stats.Add(builder(statLine));
        }
    }
}