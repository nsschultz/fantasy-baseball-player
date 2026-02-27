using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Database.Repositories;

public class PitchingStatsRepositoryTest : IDisposable
{
  private readonly PlayerContext _context;

  public PitchingStatsRepositoryTest() => _context = CreateContext().Result;

  public Guid PlayerMatchingId { get; }

  [Fact]
  public async Task DeleteAllPitchingStatsTest()
  {
    var repo = new PitchinStatsRepository(_context);
    Assert.Equal(4, await _context.PitchingStats.CountAsync());
    Assert.Equal(3, await _context.PitchingStats.CountAsync(b => b.StatsType == StatsType.PROJ));
    Assert.Equal(2, await _context.BattingStats.CountAsync());
    Assert.Equal(6, await _context.Players.CountAsync());
    await repo.DeleteAllPitchingStats(StatsType.PROJ);
    Assert.Equal(1, await _context.PitchingStats.CountAsync());
    Assert.Equal(0, await _context.PitchingStats.CountAsync(b => b.StatsType == StatsType.PROJ));
    Assert.Equal(2, await _context.BattingStats.CountAsync());
    Assert.Equal(6, await _context.Players.CountAsync());
  }

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing) return;
    _context.Database.EnsureDeleted();
    _context.Dispose();
  }

  private static async Task<PlayerContext> CreateContext()
  {
    var options = new DbContextOptionsBuilder<PlayerContext>()
      .UseInMemoryDatabase(databaseName: "DeleteAllPitchingStatsTest")
      .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
      .Options;
    var context = new PlayerContext(options);
    await context.Database.EnsureCreatedAsync();
    Assert.Equal(31, await context.Teams.CountAsync());
    await context.AddRangeAsync(
      new PlayerEntity
      {
        MlbAmId = 1,
        Type = PlayerType.P,
        Team = "MIL",
        PitchingStats = [new() { StatsType = StatsType.YTD, InningsPitched = 1 }],
        LeagueStatuses = [new() { LeagueId = 1, LeagueStatus = LeagueStatus.R }]
      },
      new PlayerEntity
      {
        MlbAmId = 2,
        Type = PlayerType.B,
        Team = "MIL",
        BattingStats = [new() { StatsType = StatsType.YTD, AtBats = 2 }],
        LeagueStatuses = [new() { LeagueId = 2, LeagueStatus = LeagueStatus.R }]
      },
      new PlayerEntity
      {
        MlbAmId = 3,
        Type = PlayerType.P,
        Team = "TB",
        PitchingStats = [new() { StatsType = StatsType.PROJ, InningsPitched = 3 }],
        LeagueStatuses = [new() { LeagueId = 3, LeagueStatus = LeagueStatus.R }]
      },
      new PlayerEntity
      {
        MlbAmId = 4,
        Type = PlayerType.P,
        Team = "MIL",
        PitchingStats = [new() { StatsType = StatsType.PROJ, InningsPitched = 1 }],
        LeagueStatuses = [new() { LeagueId = 1, LeagueStatus = LeagueStatus.R }]
      },
      new PlayerEntity
      {
        MlbAmId = 5,
        Type = PlayerType.B,
        Team = "MIL",
        BattingStats = [new() { StatsType = StatsType.YTD, AtBats = 2 }],
        LeagueStatuses = [new() { LeagueId = 2, LeagueStatus = LeagueStatus.R }]
      },
      new PlayerEntity
      {
        MlbAmId = 6,
        Type = PlayerType.P,
        Team = "TB",
        PitchingStats = [new() { StatsType = StatsType.PROJ, InningsPitched = 3 }],
        LeagueStatuses = [new() { LeagueId = 3, LeagueStatus = LeagueStatus.R }]
      }
    );
    await context.SaveChangesAsync();
    Assert.Equal(6, await context.Players.CountAsync());
    return context;
  }
}