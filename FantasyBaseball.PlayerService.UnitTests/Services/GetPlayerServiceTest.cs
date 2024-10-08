using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Maps;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Services
{
  public class GetPlayerServiceTest
  {
    private static readonly List<PlayerEntity> PLAYERS =
    [
      new()
      {
        MlbAmId = 1,
        FirstName = "Christian",
        LastName = "Yelich",
        Type = PlayerType.B,
        PlayerTeam = new TeamEntity { Code = "MIL"},
        BattingStats = [new() { StatsType = StatsType.YTD, AtBats = 1 }],
        LeagueStatuses = [new() { LeagueId = 1, LeagueStatus = LeagueStatus.R }]
      },
      new()
      {
        MlbAmId = 2,
        FirstName = "Corbin",
        LastName = "Burnes",
        Type = PlayerType.P,
        PlayerTeam = new TeamEntity { Code = "MIL"},
        PitchingStats = [new() { StatsType = StatsType.YTD, InningsPitched = 2 }],
        LeagueStatuses = [new() { LeagueId = 2, LeagueStatus = LeagueStatus.R }]
      },
      new()
      {
        MlbAmId = 3,
        FirstName = "Wander",
        LastName = "Franco",
        Type = PlayerType.B,
        PlayerTeam = new TeamEntity { Code = "TB"},
        BattingStats = [new() { StatsType = StatsType.PROJ, AtBats = 3 },new() { StatsType = StatsType.CMBD, AtBats = 13 }],
        LeagueStatuses = [new() { LeagueId = 1, LeagueStatus = LeagueStatus.R }]
      }
    ];
    private static readonly List<BaseballPosition> POSITIONS =
    [
      new() { Code = ""    , FullName = "Unknown"          , PlayerType = PlayerType.U, SortOrder = int.MaxValue },
      new() { Code = "C"   , FullName = "Catcher"          , PlayerType = PlayerType.B, SortOrder = 0            },
      new() { Code = "1B"  , FullName = "First Baseman"    , PlayerType = PlayerType.B, SortOrder = 1            },
      new() { Code = "2B"  , FullName = "Second Baseman"   , PlayerType = PlayerType.B, SortOrder = 2            },
      new() { Code = "3B"  , FullName = "Third Baseman"    , PlayerType = PlayerType.B, SortOrder = 3            },
      new() { Code = "SS"  , FullName = "Shortstop"        , PlayerType = PlayerType.B, SortOrder = 4            },
      new() { Code = "CIF" , FullName = "Corner Infielder" , PlayerType = PlayerType.B, SortOrder = 5            },
      new() { Code = "MIF" , FullName = "Middle Infielder" , PlayerType = PlayerType.B, SortOrder = 6            },
      new() { Code = "IF"  , FullName = "Infielder"        , PlayerType = PlayerType.B, SortOrder = 7            },
      new() { Code = "LF"  , FullName = "Left Fielder"     , PlayerType = PlayerType.B, SortOrder = 8            },
      new() { Code = "CF"  , FullName = "Center Feilder"   , PlayerType = PlayerType.B, SortOrder = 9            },
      new() { Code = "RF"  , FullName = "Right Fielder"    , PlayerType = PlayerType.B, SortOrder = 10           },
      new() { Code = "OF"  , FullName = "Outfielder"       , PlayerType = PlayerType.B, SortOrder = 11           },
      new() { Code = "DH"  , FullName = "Designated Hitter", PlayerType = PlayerType.B, SortOrder = 12           },
      new() { Code = "UTIL", FullName = "Utility"          , PlayerType = PlayerType.B, SortOrder = 13           },
      new() { Code = "SP"  , FullName = "Starting Pitcher" , PlayerType = PlayerType.P, SortOrder = 100          },
      new() { Code = "RP"  , FullName = "Relief Pitcher"   , PlayerType = PlayerType.P, SortOrder = 101          },
      new() { Code = "P"   , FullName = "Pitcher"          , PlayerType = PlayerType.P, SortOrder = 102          }
    ];

    [Fact]
    public async void GetPlayerTestMissingIdException()
    {
      var positionService = new Mock<IGetPositionService>();
      positionService.Setup(o => o.GetPositions()).ReturnsAsync(POSITIONS);
      var playerRepo = new Mock<IPlayerRepository>();
      playerRepo.Setup(o => o.GetPlayerById(It.IsAny<Guid>())).ReturnsAsync((PlayerEntity)null);
      await Assert.ThrowsAsync<BadRequestException>(async () =>
        await new GetPlayerService(null, playerRepo.Object, positionService.Object).GetPlayer(Guid.NewGuid()));
    }

    [Fact]
    public async void GetPlayerTestValid()
    {
      var id = Guid.NewGuid();
      var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new BaseballPlayerProfile())).CreateMapper();
      var positionService = new Mock<IGetPositionService>();
      positionService.Setup(o => o.GetPositions()).ReturnsAsync(POSITIONS);
      var playerRepo = new Mock<IPlayerRepository>();
      playerRepo.Setup(o => o.GetPlayerById(It.Is<Guid>((i) => i == id))).ReturnsAsync(PLAYERS[0]);
      var player = await new GetPlayerService(mapper, playerRepo.Object, positionService.Object).GetPlayer(id);
      Assert.Equal("MIL", player.Team.Code);
      Assert.Equal(player.MlbAmId, player.BattingStats.First(p => p.StatsType == StatsType.CMBD).AtBats);
      Assert.Equal(LeagueStatus.R, player.League1);
      Assert.Equal(LeagueStatus.A, player.League2);
    }

    [Fact]
    public async void GetPlayersTest()
    {
      var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new BaseballPlayerProfile())).CreateMapper();
      var positionService = new Mock<IGetPositionService>();
      positionService.Setup(o => o.GetPositions()).ReturnsAsync(POSITIONS);
      var playerRepo = new Mock<IPlayerRepository>();
      playerRepo.Setup(o => o.GetPlayers(It.IsAny<PlayerType?>())).ReturnsAsync(PLAYERS);
      var players = await new GetPlayerService(mapper, playerRepo.Object, positionService.Object).GetPlayers();
      Assert.Equal(3, players.Count);
      players.ForEach(player =>
      {
        Assert.Equal(player.MlbAmId < 3 ? "MIL" : "TB", player.Team.Code);
        Assert.Equal(player.MlbAmId, player.Type == PlayerType.B
          ? player.BattingStats.First(p => p.StatsType == StatsType.CMBD).AtBats
          : player.PitchingStats.First(p => p.StatsType == StatsType.CMBD).InningsPitched);
        Assert.Equal(player.MlbAmId % 2 == 0 ? LeagueStatus.A : LeagueStatus.R, player.League1);
        Assert.Equal(player.MlbAmId % 2 == 0 ? LeagueStatus.R : LeagueStatus.A, player.League2);
      });
    }
  }
}