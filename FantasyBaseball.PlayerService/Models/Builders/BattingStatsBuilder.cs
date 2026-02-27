using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Utility;

namespace FantasyBaseball.PlayerService.Models.Builders;

/// <summary>Builds a new instance of a <c>BattingStats</c> from one or more instances.</summary>
public class BattingStatsBuilder
{
  private static readonly double MinimumContractRate = .75;
  private static readonly int MinimumPowerAndSpeed = 80;
  private static readonly double MinimumWalkRate = .05;
  private static readonly int WeightContractRate = 400;
  private static readonly double WeightPower = .8;
  private static readonly double WeightSpeed = .3;
  private static readonly int WeightWalkRate = 200;
  private readonly List<BattingStats> statsList = [];
  private StatsType statsType = StatsType.UNKN;

  /// <summary>Set the output <c>StatsType</c> for the <c>BattingStats</c> being creatd</summary>
  /// <param name="stats">The type of stats.</param>
  /// <returns>The instance of the builder.</returns>
  public BattingStatsBuilder AddStats(BattingStats stats)
  {
    if (stats != null) statsList.Add(stats);
    return this;
  }

  /// <summary>Adds another instance of <c>BattingStats</c> to the list.</summary>
  /// <param name="stats">The collection of <c>BattingStats</c> to add to the list.</param>
  /// <returns>The instance of the builder.</returns>
  public BattingStatsBuilder AddStats(IEnumerable<BattingStats> stats)
  {
    if (stats != null) statsList.AddRange(stats.Where(s => s != null));
    return this;
  }

  /// <summary>Creates a new instance of <c>BattingStats</c> from the given data.</summary>
  /// <returns>A new instance of <c>BattingStats</c> from the given data.</returns>
  public BattingStats Build() => Calculate(Sum());

  /// <summary>Adds another instance of <c>BattingStats</c> to the list.</summary>
  /// <param name="type">The collection of <c>BattingStats</c> to add to the list.</param>
  /// <returns>The instance of the builder.</returns>
  public BattingStatsBuilder SetStatsType(StatsType type)
  {
    statsType = type;
    return this;
  }

  private BattingStats Calculate(BattingStats stats)
  {
    stats.TotalBases = stats.Hits - stats.Doubles - stats.Triples - stats.HomeRuns
      + stats.Doubles * 2 + stats.Triples * 3 + stats.HomeRuns * 4;
    stats.BattingAverage = MathHelper.Divide(stats.Hits, stats.AtBats);
    stats.OnBasePercentage = MathHelper.Divide(stats.Hits + stats.BaseOnBalls, stats.AtBats + stats.BaseOnBalls);
    stats.SluggingPercentage = MathHelper.Divide(stats.TotalBases, stats.AtBats);
    stats.OnBasePlusSlugging = stats.OnBasePercentage + stats.SluggingPercentage;
    stats.ContractRate = MathHelper.Divide(stats.AtBats - stats.StrikeOuts, stats.AtBats);
    stats.Power = MathHelper.Divide(statsList.Sum(s => s.AtBats * s.Power), stats.AtBats);
    stats.WalkRate = MathHelper.Divide(stats.BaseOnBalls, stats.AtBats + stats.BaseOnBalls);
    stats.Speed = MathHelper.Divide(statsList.Sum(s => s.AtBats * s.Speed), stats.AtBats);
    stats.BasePerformanceValue = stats.AtBats + stats.BaseOnBalls > 0
      ? (stats.WalkRate - MinimumWalkRate) * WeightWalkRate
        + (stats.ContractRate - MinimumContractRate) * WeightContractRate
        + (stats.Power - MinimumPowerAndSpeed) * WeightPower
        + (stats.Speed - MinimumPowerAndSpeed) * WeightSpeed
      : 0;
    return stats;
  }

  private BattingStats Sum() =>
    new()
    {
      StatsType = statsType,
      AtBats = statsList.Sum(s => s.AtBats),
      Runs = statsList.Sum(s => s.Runs),
      Hits = statsList.Sum(s => s.Hits),
      Doubles = statsList.Sum(s => s.Doubles),
      Triples = statsList.Sum(s => s.Triples),
      HomeRuns = statsList.Sum(s => s.HomeRuns),
      RunsBattedIn = statsList.Sum(s => s.RunsBattedIn),
      BaseOnBalls = statsList.Sum(s => s.BaseOnBalls),
      StrikeOuts = statsList.Sum(s => s.StrikeOuts),
      StolenBases = statsList.Sum(s => s.StolenBases),
      CaughtStealing = statsList.Sum(s => s.CaughtStealing)
    };
}