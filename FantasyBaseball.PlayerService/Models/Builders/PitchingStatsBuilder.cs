using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Utility;

namespace FantasyBaseball.PlayerService.Models.Builders;

/// <summary>Builds a new instance of a <c>PitchingStats</c> from one or more instances.</summary>
public class PitchingStatsBuilder
{
  private static readonly double BabipMultiplier = 2.82;
  private static readonly int MaxiumumControl = 4;
  private static readonly int MinimumDominance = 5;
  private static readonly double MinimumGroundBallRate = .4;
  private static readonly int WeightControl = 27;
  private static readonly int WeightGroundBallRate = 100;
  private static readonly int WeightDominance = 18;
  private readonly List<PitchingStats> statsList = [];
  private StatsType statsType = StatsType.UNKN;

  /// <summary>Adds another instance of <c>PitchingStats</c> to the list.</summary>
  /// <param name="stats">The <c>PitchingStats</c> to add to the list.</param>
  /// <returns>The instance of the builder.</returns>
  public PitchingStatsBuilder AddStats(PitchingStats stats)
  {
    if (stats != null) statsList.Add(stats);
    return this;
  }

  /// <summary>Adds another instance of <c>PitchingStats</c> to the list.</summary>
  /// <param name="stats">The collection of <c>PitchingStats</c> to add to the list.</param>
  /// <returns>The instance of the builder.</returns>
  public PitchingStatsBuilder AddStats(IEnumerable<PitchingStats> stats)
  {
    if (stats != null) statsList.AddRange(stats.Where(s => s != null));
    return this;
  }

  /// <summary>Creates a new instance of <c>PitchingStats</c> from the given data.</summary>
  /// <returns>A new instance of <c>PitchingStats</c> from the given data.</returns>
  public PitchingStats Build() => Calculate(Sum());

  /// <summary>Adds another instance of <c>BattingStats</c> to the list.</summary>
  /// <param name="type">The collection of <c>BattingStats</c> to add to the list.</param>
  /// <returns>The instance of the builder.</returns>
  public PitchingStatsBuilder SetStatsType(StatsType type)
  {
    statsType = type;
    return this;
  }

  private PitchingStats Calculate(PitchingStats stats)
  {
    stats.FlyBallRate = MathHelper.Divide(statsList.Sum(s => s.InningsPitched * s.FlyBallRate), stats.InningsPitched);
    stats.GroundBallRate = MathHelper.Divide(statsList.Sum(s => s.InningsPitched * s.GroundBallRate), stats.InningsPitched);
    stats.EarnedRunAverage = MathHelper.Divide(stats.EarnedRuns, stats.InningsPitched / 9);
    stats.WalksAndHitsPerInningPitched = MathHelper.Divide(stats.HitsAllowed + stats.BaseOnBallsAllowed, stats.InningsPitched);
    stats.BattingAverageOnBallsInPlay = MathHelper.Divide(stats.HitsAllowed - stats.HomeRunsAllowed,
      stats.InningsPitched * BabipMultiplier + stats.HitsAllowed - stats.StrikeOuts - stats.HomeRunsAllowed);
    stats.StrandRate = MathHelper.Divide(stats.HitsAllowed + stats.BaseOnBallsAllowed - stats.EarnedRuns,
      stats.HitsAllowed + stats.BaseOnBallsAllowed - stats.HomeRunsAllowed);
    stats.Dominance = MathHelper.Divide(stats.StrikeOuts, stats.InningsPitched / 9);
    stats.Control = MathHelper.Divide(stats.BaseOnBallsAllowed, stats.InningsPitched / 9);
    stats.Command = MathHelper.Divide(stats.Dominance, stats.Control);
    stats.GroundBallToFlyBallRate = MathHelper.Divide(stats.GroundBallRate, stats.FlyBallRate);
    stats.BasePerformanceValue = stats.InningsPitched > 0
      ? (stats.Dominance - MinimumDominance) * WeightDominance
        + (MaxiumumControl - stats.Control) * WeightControl
        + (stats.GroundBallRate - MinimumGroundBallRate) * WeightGroundBallRate
      : 0;
    return stats;
  }

  private PitchingStats Sum() =>
    new()
    {
      StatsType = statsType,
      Wins = statsList.Sum(s => s.Wins),
      Losses = statsList.Sum(s => s.Losses),
      QualityStarts = statsList.Sum(s => s.QualityStarts),
      Saves = statsList.Sum(s => s.Saves),
      BlownSaves = statsList.Sum(s => s.BlownSaves),
      Holds = statsList.Sum(s => s.Holds),
      InningsPitched = statsList.Sum(s => s.InningsPitched),
      HitsAllowed = statsList.Sum(s => s.HitsAllowed),
      EarnedRuns = statsList.Sum(s => s.EarnedRuns),
      HomeRunsAllowed = statsList.Sum(s => s.HomeRunsAllowed),
      BaseOnBallsAllowed = statsList.Sum(s => s.BaseOnBallsAllowed),
      StrikeOuts = statsList.Sum(s => s.StrikeOuts)
    };
}