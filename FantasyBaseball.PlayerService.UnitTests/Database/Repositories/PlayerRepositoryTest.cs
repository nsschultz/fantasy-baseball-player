using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace FantasyBaseball.PlayerService.Database.Repositories.UnitTests
{
  public class PlayerRepositoryTest : IDisposable
  {
    private readonly Guid PlayerMatchingId = Guid.NewGuid();
    private readonly Guid PlayerMissingId = Guid.NewGuid();
    private PlayerContext _context;

    public PlayerRepositoryTest() => _context = CreateContext().Result;

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

    [Fact] public async void GetPlayerByBhqIdNull() => Assert.Null(await new PlayerRepository(_context).GetPlayerByBhqId(2, PlayerType.B));

    [Fact] public async void GetPlayerByBhqIdValid() => Assert.Equal(2, (await new PlayerRepository(_context).GetPlayerByBhqId(2, PlayerType.P)).BhqId);

    [Fact] public async void GetPlayerByIdNull() => Assert.Null(await new PlayerRepository(_context).GetPlayerById(PlayerMissingId));

    [Fact] public async void GetPlayerByIdValid() => Assert.Equal(2, (await new PlayerRepository(_context).GetPlayerById(PlayerMatchingId)).BhqId);

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
        Assert.Equal(player.BhqId < 3 ? "Brewers" : "Rays", player.PlayerTeam.Nickname);
        Assert.Equal(player.BhqId, player.Type == PlayerType.B ? player.BattingStats.First().AtBats : player.PitchingStats.First().InningsPitched);
        Assert.Equal(player.BhqId, player.LeagueStatuses.First().LeagueId);
      });
    }

    [Fact]
    public async void UpdatePlayerTestMissingIdException()
    {
      Assert.Equal("MIL", _context.Players.Find(PlayerMatchingId).Team);
      var player = new PlayerEntity { Id = PlayerMissingId, BhqId = 1, Type = PlayerType.B, Team = "TB" };
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
        new PlayerEntity { BhqId = 1, Type = PlayerType.B, Team = "MIL" },
        new PlayerEntity { BhqId = 2, Type = PlayerType.B, Team = "MIL" },
        new PlayerEntity { BhqId = 4, Type = PlayerType.P, Team = "MIL" },
        new PlayerEntity { Id = PlayerMatchingId, BhqId = 5, Type = PlayerType.P, Team = "MIL" },
        new PlayerEntity { Id = PlayerMissingId, BhqId = 1, Type = PlayerType.B, Team = "MIL" },
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
        new PlayerEntity
        {
          BhqId = 4,
          Type = PlayerType.P,
          Team = "MIL",
          PitchingStats = new List<PitchingStatsEntity>
          {
            new PitchingStatsEntity { StatsType = StatsType.YTD, InningsPitched = 2 },
            new PitchingStatsEntity { StatsType = StatsType.PROJ, InningsPitched = 4 }
          },
          LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 2, LeagueStatus = LeagueStatus.R } }
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
          BhqId = 1,
          Type = PlayerType.B,
          Team = "MIL",
          BattingStats = new List<BattingStatsEntity> { new BattingStatsEntity { StatsType = StatsType.YTD, AtBats = 1 } },
          LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 1, LeagueStatus = LeagueStatus.R } }
        },
        new PlayerEntity
        {
          Id = PlayerMatchingId,
          BhqId = 2,
          Type = PlayerType.P,
          Team = "MIL",
          PitchingStats = new List<PitchingStatsEntity> { new PitchingStatsEntity { StatsType = StatsType.YTD, InningsPitched = 2 } },
          LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 2, LeagueStatus = LeagueStatus.R } }
        },
        new PlayerEntity
        {
          BhqId = 3,
          Type = PlayerType.B,
          Team = "TB",
          BattingStats = new List<BattingStatsEntity> { new BattingStatsEntity { StatsType = StatsType.PROJ, AtBats = 3 } },
          LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 3, LeagueStatus = LeagueStatus.R } }
        }
      );
      await context.SaveChangesAsync();
      Assert.Equal(3, await context.Players.CountAsync());
      return context;
    }
  }
}