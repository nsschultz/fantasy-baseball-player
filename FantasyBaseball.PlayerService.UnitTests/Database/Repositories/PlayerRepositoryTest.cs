using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Database.Repositories;

public class PlayerRepositoryTest : IDisposable
{
  private static readonly Guid PlayerMatchingId = Guid.NewGuid();
  private static readonly Guid PlayerMissingId = Guid.NewGuid();
  private readonly PlayerContext _context;

  public PlayerRepositoryTest() => _context = CreateContext().Result;

  [Fact]
  public async Task AddPlayerTesExistingIdException()
  {
    var player = await _context.Players.FindAsync(PlayerMatchingId);
    await Assert.ThrowsAsync<ArgumentException>(async () => await new PlayerRepository(_context).AddPlayer(player));
    Assert.Equal(3, await _context.Players.CountAsync());
  }

  [Fact]
  public async Task AddPlayerTestValid()
  {
    var player = new PlayerEntity { MlbAmId = 100, Type = PlayerType.B, Team = "TB" };
    await new PlayerRepository(_context).AddPlayer(player);
    Assert.Equal(4, await _context.Players.CountAsync());
  }

  [Fact]
  public async Task DeleteAllPlayersTestValid()
  {
    await new PlayerRepository(_context).DeleteAllPlayers();
    Assert.Equal(0, await _context.Players.CountAsync());
    Assert.Equal(0, await _context.LeagueStatuses.CountAsync());
    Assert.Equal(0, await _context.BattingStats.CountAsync());
    Assert.Equal(0, await _context.PitchingStats.CountAsync());
    Assert.Equal(31, await _context.Teams.CountAsync());
  }

  [Fact]
  public async Task DeletePlayerTestMissingIdException()
  {
    var player = new PlayerEntity { Id = PlayerMissingId, MlbAmId = 1, Type = PlayerType.B, Team = "TB" };
    await Assert.ThrowsAsync<InvalidOperationException>(async () => await new PlayerRepository(_context).DeletePlayer(player));
    Assert.Equal(3, await _context.Players.CountAsync());
  }

  [Fact]
  public async Task DeletePlayerTestValid()
  {
    var player = await _context.Players.FindAsync(PlayerMatchingId);
    await new PlayerRepository(_context).DeletePlayer(player);
    Assert.Equal(2, await _context.Players.CountAsync());
  }

  [Fact] public async Task GetPlayerByBhqIdNull() => Assert.Null(await new PlayerRepository(_context).GetPlayerByMlbAmId(2, PlayerType.B));

  [Fact] public async Task GetPlayerByBhqIdValid() => Assert.Equal(2, (await new PlayerRepository(_context).GetPlayerByMlbAmId(2, PlayerType.P)).MlbAmId);

  [Fact] public async Task GetPlayerByIdNull() => Assert.Null(await new PlayerRepository(_context).GetPlayerById(PlayerMissingId));

  [Fact] public async Task GetPlayerByIdValid() => Assert.Equal(2, (await new PlayerRepository(_context).GetPlayerById(PlayerMatchingId)).MlbAmId);

  [Theory]
  [InlineData(PlayerType.B, 2)]
  [InlineData(PlayerType.P, 1)]
  [InlineData(PlayerType.U, 0)]
  [InlineData(null, 3)]
  public async Task GetPlayerEntitiesTest(PlayerType? type, int count)
  {
    var players = await new PlayerRepository(_context).GetPlayers(type);
    Assert.Equal(count, players.Count);
    players.ForEach(player =>
    {
      Assert.Equal(player.MlbAmId < 3 ? "Brewers" : "Rays", player.PlayerTeam.Nickname);
      Assert.Equal(player.MlbAmId, player.Type == PlayerType.B ? player.BattingStats[0].AtBats : player.PitchingStats[0].InningsPitched);
      Assert.Equal(player.MlbAmId, player.LeagueStatuses[0].LeagueId);
    });
  }

  [Fact]
  public async Task UpdatePlayerTestMissingIdException()
  {
    Assert.Equal("MIL", (await _context.Players.FindAsync(PlayerMatchingId)).Team);
    var player = new PlayerEntity { Id = PlayerMissingId, MlbAmId = 1, Type = PlayerType.B, Team = "TB" };
    await Assert.ThrowsAsync<InvalidOperationException>(async () => await new PlayerRepository(_context).UpdatePlayer(player));
    Assert.Equal("MIL", (await _context.Players.FindAsync(PlayerMatchingId)).Team);
  }

  [Fact]
  public async Task UpdatePlayerTestValid()
  {
    Assert.Equal("MIL", (await _context.Players.FindAsync(PlayerMatchingId)).Team);
    var player = await _context.Players.FindAsync(PlayerMatchingId);
    player.Team = "TB";
    await new PlayerRepository(_context).UpdatePlayer(player);
    Assert.Equal("TB", (await _context.Players.FindAsync(PlayerMatchingId)).Team);
  }

  [Fact]
  public async Task UpsertPlayersTestException()
  {
    var values = new List<PlayerEntity>
    {
      new() { MlbAmId = 1, Type = PlayerType.B, Team = "MIL" },
      new() { MlbAmId = 2, Type = PlayerType.B, Team = "MIL" },
      new() { MlbAmId = 4, Type = PlayerType.P, Team = "MIL" },
      new() { Id = PlayerMatchingId, MlbAmId = 5, Type = PlayerType.P, Team = "MIL" },
      new() { Id = PlayerMissingId, MlbAmId = 1, Type = PlayerType.B, Team = "MIL" },
    };
    await Assert.ThrowsAsync<InvalidOperationException>(async () => await new PlayerRepository(_context).UpsertPlayers(values));
    Assert.Equal(3, await _context.Players.CountAsync());
    Assert.Equal(3, await _context.LeagueStatuses.CountAsync());
    Assert.Equal(2, await _context.BattingStats.CountAsync());
    Assert.Equal(1, await _context.PitchingStats.CountAsync());
    Assert.Equal(31, await _context.Teams.CountAsync());
  }

  [Fact]
  public async Task UpsertPlayersTestValid()
  {
    var existingPlayer = await _context.Players.FindAsync(PlayerMatchingId);
    existingPlayer.BattingStats.Add(new BattingStatsEntity { StatsType = StatsType.YTD, AtBats = 2 });
    var values = new List<PlayerEntity>
    {
      existingPlayer,
      new()
      {
        MlbAmId = 4,
        Type = PlayerType.P,
        Team = "MIL",
        PitchingStats =
        [
          new() { StatsType = StatsType.YTD, InningsPitched = 2 },
          new() { StatsType = StatsType.PROJ, InningsPitched = 4 }
        ],
        LeagueStatuses = [new() { LeagueId = 2, LeagueStatus = LeagueStatus.R }]
      }
    };
    await new PlayerRepository(_context).UpsertPlayers(values);
    Assert.Equal(4, await _context.Players.CountAsync());
    Assert.Equal(4, await _context.LeagueStatuses.CountAsync());
    Assert.Equal(3, await _context.BattingStats.CountAsync());
    Assert.Equal(3, await _context.PitchingStats.CountAsync());
    Assert.Equal(31, await _context.Teams.CountAsync());
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
      .UseInMemoryDatabase(databaseName: "GetPlayersTest")
      .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
      .Options;
    var context = new PlayerContext(options);
    await context.Database.EnsureCreatedAsync();
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
        Id = PlayerMatchingId,
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
      }
    );
    await context.SaveChangesAsync();
    Assert.Equal(3, await context.Players.CountAsync());
    return context;
  }
}