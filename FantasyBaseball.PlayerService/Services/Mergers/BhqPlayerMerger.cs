using System;
using System.Linq;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Utility;

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
      if (existing == null)
      {
        existing = mapper.Map<PlayerEntity>(incoming);
        existing.AverageDraftPick = 9999;
        existing.AverageDraftPickMax = 9999;
        existing.AverageDraftPickMin = 9999;
        existing.MayberryMethod = 0;
        existing.Reliability = 0;
        CorrectBhqFields(incoming, existing);
        return existing;
      }
      if (incoming.MlbAmId > 0)
      {
        existing.MlbAmId = incoming.MlbAmId;
        existing.Age = incoming.Age;
        existing.Team = incoming.Team.Code;
        CorrectBhqFields(incoming, existing);
        incoming.BattingStats.Select(mapper.Map<BattingStatsEntity>).ToList().ForEach(existing.BattingStats.Add);
        incoming.PitchingStats.Select(mapper.Map<PitchingStatsEntity>).ToList().ForEach(existing.PitchingStats.Add);
      }
      return existing;
    }

    private static void CorrectBhqFields(BaseballPlayer incoming, PlayerEntity existing)
    {
      existing.AverageDraftPick = GetAdp(incoming.AverageDraftPick, existing.AverageDraftPick);
      existing.AverageDraftPickMax = GetAdp(incoming.AverageDraftPickMax, existing.AverageDraftPickMax);
      existing.AverageDraftPickMin = GetAdp(incoming.AverageDraftPickMin, existing.AverageDraftPickMin);
      existing.MayberryMethod = incoming.MayberryMethod < 0 ? existing.MayberryMethod : incoming.MayberryMethod;
      existing.Reliability = incoming.Reliability < 0 ? existing.Reliability : incoming.Reliability;
    }

    private static double GetAdp(double newAdp) => MathHelper.IsEqual(newAdp, 0) ? MathHelper.MaxDraftPick : Math.Min(newAdp, MathHelper.MaxDraftPick);

    private static double GetAdp(double newAdp, double oldAdp) => newAdp < 0 ? oldAdp : GetAdp(newAdp);

    private static int GetAdp(int newAdp) => newAdp == 0 ? MathHelper.MaxDraftPick : Math.Min(newAdp, MathHelper.MaxDraftPick);

    private static int GetAdp(int newAdp, int oldAdp) => newAdp < 0 ? oldAdp : GetAdp(newAdp);
  }
}