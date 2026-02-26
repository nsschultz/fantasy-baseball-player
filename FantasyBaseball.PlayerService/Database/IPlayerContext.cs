using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyBaseball.PlayerService.Database;

/// <summary>The context object for players and their related entities.</summary>
public interface IPlayerContext
{
  /// <summary>A collection of batting stats.</summary>
  DbSet<BattingStatsEntity> BattingStats { get; set; }

  /// <summary>A collection of league statuses.</summary>
  DbSet<PlayerLeagueStatusEntity> LeagueStatuses { get; set; }

  /// <summary>A collection of pitching stats.</summary>
  DbSet<PitchingStatsEntity> PitchingStats { get; set; }

  /// <summary>A collection of players.</summary>
  DbSet<PlayerEntity> Players { get; set; }

  /// <summary>A collection of teams the player can belong to.</summary>
  DbSet<TeamEntity> Teams { get; set; }

  /// <summary>Starts a new database transaction.</summary>
  Task BeginTransaction();

  /// <summary>Commits the database transaction.</summary>
  Task Commit();

  /// <summary>Rolls the database transaction back.</summary>
  Task Rollback();
}