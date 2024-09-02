using Xunit;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Database;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using FantasyBaseball.PlayerService.Database.Entities;
using System;

namespace FantasyBaseball.PlayerService.UnitTests.Database.Repositories
{
  public class BattingStatsRepositoryTest : IDisposable
  {
    private readonly PlayerContext _context;

    public BattingStatsRepositoryTest() => _context = CreateContext().Result;

    public Guid PlayerMatchingId { get; private set; }

    [Fact]
    public async void DeleteAllBattingStatsTest()
    {
      var repo = new BattingStatsRepository(_context);
      Assert.Equal(4, await _context.BattingStats.CountAsync());
      Assert.Equal(3, await _context.BattingStats.CountAsync(b => b.StatsType == StatsType.PROJ));
      Assert.Equal(2, await _context.PitchingStats.CountAsync());
      Assert.Equal(6, await _context.Players.CountAsync());
      await repo.DeleteAllBattingStats(StatsType.PROJ);
      Assert.Equal(1, await _context.BattingStats.CountAsync());
      Assert.Equal(0, await _context.BattingStats.CountAsync(b => b.StatsType == StatsType.PROJ));
      Assert.Equal(2, await _context.PitchingStats.CountAsync());
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
        .UseInMemoryDatabase(databaseName: "DeleteAllBattingStatsTest")
        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
        .Options;
      var context = new PlayerContext(options);
      context.Database.EnsureCreated();
      Assert.Equal(31, await context.Teams.CountAsync());
      await context.AddRangeAsync(
        new PlayerEntity
        {
          MlbAmId = 1,
          Type = PlayerType.B,
          Team = "MIL",
          BattingStats = [new() { StatsType = StatsType.YTD, AtBats = 1 }],
          LeagueStatuses = [new() { LeagueId = 1, LeagueStatus = LeagueStatus.R }]
        },
        new PlayerEntity
        {
          MlbAmId = 2,
          Type = PlayerType.P,
          Team = "MIL",
          PitchingStats = [new() { StatsType = StatsType.YTD, InningsPitched = 2 }],
          LeagueStatuses = [new() { LeagueId = 2, LeagueStatus = LeagueStatus.R }]
        },
        new PlayerEntity
        {
          MlbAmId = 3,
          Type = PlayerType.B,
          Team = "TB",
          BattingStats = [new() { StatsType = StatsType.PROJ, AtBats = 3 }],
          LeagueStatuses = [new() { LeagueId = 3, LeagueStatus = LeagueStatus.R }]
        },
        new PlayerEntity
        {
          MlbAmId = 4,
          Type = PlayerType.B,
          Team = "MIL",
          BattingStats = [new() { StatsType = StatsType.PROJ, AtBats = 1 }],
          LeagueStatuses = [new() { LeagueId = 1, LeagueStatus = LeagueStatus.R }]
        },
        new PlayerEntity
        {
          MlbAmId = 5,
          Type = PlayerType.P,
          Team = "MIL",
          PitchingStats = [new() { StatsType = StatsType.YTD, InningsPitched = 2 }],
          LeagueStatuses = [new() { LeagueId = 2, LeagueStatus = LeagueStatus.R }]
        },
        new PlayerEntity
        {
          MlbAmId = 6,
          Type = PlayerType.B,
          Team = "TB",
          BattingStats = [new() { StatsType = StatsType.PROJ, AtBats = 3 }],
          LeagueStatuses = [new() { LeagueId = 3, LeagueStatus = LeagueStatus.R }]
        }
      );
      await context.SaveChangesAsync();
      Assert.Equal(6, await context.Players.CountAsync());
      return context;
    }
  }
}