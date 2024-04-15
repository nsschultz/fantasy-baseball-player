using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Database.Repositories
{
  /// <summary>Repo for CRUD functionality regarding to batting stats.</summary>
  public interface IBattingStatsRepository
  {

    /// <summary>Removes all of the stats of a given type from the database.</summary>
    /// <param name="statsType">The type of stats to remove.</param>
    Task DeleteAllBattingStats(StatsType statsType);
  }
}