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
    public PlayerEntity MergePlayer(IMapper mapper, BaseballPlayer incoming, PlayerEntity existing)
    {
      if (existing == null) return mapper.Map<PlayerEntity>(incoming);
      if (incoming.MlbAmId > 0)
      {
        existing.MlbAmId = incoming.MlbAmId;
        existing.Age = incoming.Age;
        existing.Team = incoming.Team.Code;
        existing.Reliability = incoming.Reliability;
        existing.MayberryMethod = incoming.MayberryMethod;
        existing.AverageDraftPick = incoming.AverageDraftPick;
        existing.AverageDraftPickMax = incoming.AverageDraftPickMax;
        existing.AverageDraftPickMin = incoming.AverageDraftPickMin;
      }
      incoming.BattingStats.Select(mapper.Map<BattingStatsEntity>).ToList().ForEach(existing.BattingStats.Add);
      incoming.PitchingStats.Select(mapper.Map<PitchingStatsEntity>).ToList().ForEach(existing.PitchingStats.Add);
      return existing;
    }
  }
}