using System.Linq;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services.Mergers
{
    /// <summary>Service for merging just a subset of fields that BHQ can modify.</summary>
    public class BhqPlayerMerger : IPlayerMerger
    {
        /// <summary>Merges a BaseballPlayer into a PlayerEntity.</summary>
        /// <param name="mapper">Instance of the auto mapper.</param>
        /// <param name="incoming">The incoming player values.</param>
        /// <param name="existing">The existing player values.</param>
        /// <returns>An object that can be saved to the database.</returns>
        public PlayerEntity MergePlayer(IMapper mapper, BaseballPlayerV2 incoming, PlayerEntity existing)
        {
            if (existing == null) return mapper.Map<PlayerEntity>(incoming);
            if (incoming.BhqId > 0)
            {
                existing.BhqId = incoming.BhqId;
                existing.Age = incoming.Age;
                existing.Team = incoming.Team.Code;
                existing.Reliability = incoming.Reliability;
                existing.MayberryMethod = incoming.MayberryMethod;
            }
            existing.BattingStats = incoming.BattingStats.Select(b => mapper.Map<BattingStatsEntity>(b)).ToList();
            existing.PitchingStats = incoming.PitchingStats.Select(p => mapper.Map<PitchingStatsEntity>(p)).ToList();
            return existing;
        }
    }
}