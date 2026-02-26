using System;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Database.Repositories;

/// <summary>Repo for CRUD functionality regarding to batting stats.</summary>
/// <param name="context">The player context.</param>
public class BattingStatsRepository(IPlayerContext context) : IBattingStatsRepository
{
  /// <summary>Removes all of the stats of a given type from the database.</summary>
  /// <param name="statsType">The type of stats to remove.</param>
  public async Task DeleteAllBattingStats(StatsType statsType)
  {
    try
    {
      await context.BeginTransaction();
      context.BattingStats.RemoveRange(context.BattingStats.Where(b => b.StatsType == statsType));
      await context.Commit();
    }
    catch (Exception)
    {
      await context.Rollback();
      throw;
    }
  }
}