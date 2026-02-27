using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Database.Repositories;

/// <summary>Repo for CRUD functionality regarding to pitching stats.</summary>
public interface IPitchingStatsRepository
{

  /// <summary>Removes all of the stats of a given type from the database.</summary>
  /// <param name="statsType">The type of stats to remove.</param>
  Task DeleteAllPitchingStats(StatsType statsType);
}