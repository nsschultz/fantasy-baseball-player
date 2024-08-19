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

namespace FantasyBaseball.PlayerService.UnitTests.Database.Repositories
{
  public class PlayerRepositoryTest : IDisposable
  {
    private readonly Guid PlayerMatchingId = Guid.NewGuid();
    private readonly Guid PlayerMissingId = Guid.NewGuid();
    private readonly PlayerContext _context;

    public PlayerRepositoryTest() => _context = CreateContext().Result;

    [Fact]
    public async void AddPlayerTesExistingIdException()
    {
      var player = _context.Players.Find(PlayerMatchingId);
      await Assert.ThrowsAsync<ArgumentException>(async () => await new PlayerRepository(_context).AddPlayer(player));
      Assert.Equal(3, _context.Players.Count());
    }

    [Fact]
    public async void AddPlayerTestValid()
    {
      var player = new PlayerEntity { MlbAmId = 100, Type = PlayerType.B, Team = "TB" };
      await new PlayerRepository(_context).AddPlayer(player);
      Assert.Equal(4, _context.Players.Count());
    }

    [Fact]
    public async void DeleteAllPlayersTestValid()
    {
      await new PlayerRepository(_context).DeleteAllPlayers();
      Assert.Equal(0, _context.Players.Count());
      Assert.Equal(0, _context.LeagueStatuses.Count());
      Assert.Equal(0, _context.BattingStats.Count());
      Assert.Equal(0, _context.PitchingStats.Count());
      Assert.Equal(31, _context.Teams.Count());
    }

    [Fact]
    public async void DeletePlayerTestMissingIdException()
    {
      var player = new PlayerEntity { Id = PlayerMissingId, MlbAmId = 1, Type = PlayerType.B, Team = "TB" };
      await Assert.ThrowsAsync<InvalidOperationException>(async () => await new PlayerRepository(_context).DeletePlayer(player));
      Assert.Equal(3, _context.Players.Count());
    }

    [Fact]
    public async void DeletePlayerTestValid()
    {
      var player = _context.Players.Find(PlayerMatchingId);
      await new PlayerRepository(_context).DeletePlayer(player);
      Assert.Equal(2, _context.Players.Count());
    }

    [Fact] public async void GetPlayerByBhqIdNull() => Assert.Null(await new PlayerRepository(_context).GetPlayerByMlbAmId(2, PlayerType.B));

    [Fact] public async void GetPlayerByBhqIdValid() => Assert.Equal(2, (await new PlayerRepository(_context).GetPlayerByMlbAmId(2, PlayerType.P)).MlbAmId);

    [Fact] public async void GetPlayerByIdNull() => Assert.Null(await new PlayerRepository(_context).GetPlayerById(PlayerMissingId));

    [Fact] public async void GetPlayerByIdValid() => Assert.Equal(2, (await new PlayerRepository(_context).GetPlayerById(PlayerMatchingId)).MlbAmId);

    [Theory]
    [InlineData(PlayerType.B, 2)]
    [InlineData(PlayerType.P, 1)]
    [InlineData(PlayerType.U, 0)]
    [InlineData(null, 3)]
    public async void GetPlayerEntitiesTest(PlayerType? type, int count)
    {
      var players = await new PlayerRepository(_context).GetPlayers(type);
      Assert.Equal(count, players.Count);
      players.ForEach(player =>
      {
        Assert.Equal(player.MlbAmId < 3 ? "Brewers" : "Rays", player.PlayerTeam.Nickname);
        Assert.Equal(player.MlbAmId, player.Type == PlayerType.B ? player.BattingStats.First().AtBats : player.PitchingStats.First().InningsPitched);
        Assert.Equal(player.MlbAmId, player.LeagueStatuses.First().LeagueId);
      });
    }

    [Fact]
    public async void UpdatePlayerTestMissingIdException()
    {
      Assert.Equal("MIL", _context.Players.Find(PlayerMatchingId).Team);
      var player = new PlayerEntity { Id = PlayerMissingId, MlbAmId = 1, Type = PlayerType.B, Team = "TB" };
      await Assert.ThrowsAsync<InvalidOperationException>(async () => await new PlayerRepository(_context).UpdatePlayer(player));
      Assert.Equal("MIL", _context.Players.Find(PlayerMatchingId).Team);
    }

    [Fact]
    public async void UpdatePlayerTestValid()
    {
      Assert.Equal("MIL", _context.Players.Find(PlayerMatchingId).Team);
      var player = _context.Players.Find(PlayerMatchingId);
      player.Team = "TB";
      await new PlayerRepository(_context).UpdatePlayer(player);
      Assert.Equal("TB", _context.Players.Find(PlayerMatchingId).Team);
    }

    [Fact]
    public async void UpsertPlayersTestException()
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
      Assert.Equal(3, _context.Players.Count());
      Assert.Equal(3, _context.LeagueStatuses.Count());
      Assert.Equal(2, _context.BattingStats.Count());
      Assert.Equal(1, _context.PitchingStats.Count());
      Assert.Equal(31, _context.Teams.Count());
    }

    [Fact]
    public async void UpsertPlayersTestValid()
    {
      var existingPlayer = _context.Players.Find(PlayerMatchingId);
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
      Assert.Equal(4, _context.Players.Count());
      Assert.Equal(4, _context.LeagueStatuses.Count());
      Assert.Equal(3, _context.BattingStats.Count());
      Assert.Equal(3, _context.PitchingStats.Count());
      Assert.Equal(31, _context.Teams.Count());
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

    private async Task<PlayerContext> CreateContext()
    {
      var options = new DbContextOptionsBuilder<PlayerContext>()
        .UseInMemoryDatabase(databaseName: "GetPlayersTest")
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
}