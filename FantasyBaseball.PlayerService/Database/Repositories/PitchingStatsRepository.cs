using System;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Database.Repositories
{
  /// <summary>Repo for CRUD functionality regarding to pitching stats.</summary>
  /// <remarks>Creates a new instance of the repository.</remarks>
  /// <param name="context">The player context.</param>
  public class PitchinStatsRepository(IPlayerContext context) : IPitchingStatsRepository
  {
    private readonly IPlayerContext _context = context;

    /// <summary>Removes all of the stats of a given type from the database.</summary>
    /// <param name="statsType">The type of stats to remove.</param>
    public async Task DeleteAllPitchingStats(StatsType statsType)
    {
      try
      {
        await _context.BeginTransaction();
        _context.PitchingStats.RemoveRange(_context.PitchingStats.Where(p => p.StatsType == statsType));
        await _context.Commit();
      }
      catch (Exception)
      {
        await _context.Rollback();
        throw;
      }
    }
  }
}