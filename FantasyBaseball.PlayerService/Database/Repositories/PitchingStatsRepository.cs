using System;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Database.Repositories;

/// <summary>Repo for CRUD functionality regarding to pitching stats.</summary>
/// <param name="context">The player context.</param>
public class PitchinStatsRepository(IPlayerContext context) : IPitchingStatsRepository
{
  /// <summary>Removes all of the stats of a given type from the database.</summary>
  /// <param name="statsType">The type of stats to remove.</param>
  public async Task DeleteAllPitchingStats(StatsType statsType)
  {
    try
    {
      await context.BeginTransaction();
      context.PitchingStats.RemoveRange(context.PitchingStats.Where(p => p.StatsType == statsType));
      await context.Commit();
    }
    catch (Exception)
    {
      await context.Rollback();
      throw;
    }
  }
}