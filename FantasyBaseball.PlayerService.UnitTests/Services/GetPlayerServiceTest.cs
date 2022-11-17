using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database;
using FantasyBaseball.PlayerService.Entities;
using FantasyBaseball.PlayerService.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTests
{
    public class GetPlayerServiceTest : IDisposable
    {
        private static readonly List<BaseballPosition> POSITIONS = new List<BaseballPosition>
        {
            new BaseballPosition { Code = ""    , FullName = "Unknown"          , PlayerType = PlayerType.U, SortOrder = int.MaxValue },
            new BaseballPosition { Code = "C"   , FullName = "Catcher"          , PlayerType = PlayerType.B, SortOrder = 0            },
            new BaseballPosition { Code = "1B"  , FullName = "First Baseman"    , PlayerType = PlayerType.B, SortOrder = 1            },
            new BaseballPosition { Code = "2B"  , FullName = "Second Baseman"   , PlayerType = PlayerType.B, SortOrder = 2            },
            new BaseballPosition { Code = "3B"  , FullName = "Third Baseman"    , PlayerType = PlayerType.B, SortOrder = 3            },
            new BaseballPosition { Code = "SS"  , FullName = "Shortstop"        , PlayerType = PlayerType.B, SortOrder = 4            },
            new BaseballPosition { Code = "CIF" , FullName = "Corner Infielder" , PlayerType = PlayerType.B, SortOrder = 5            },
            new BaseballPosition { Code = "MIF" , FullName = "Middle Infielder" , PlayerType = PlayerType.B, SortOrder = 6            },
            new BaseballPosition { Code = "IF"  , FullName = "Infielder"        , PlayerType = PlayerType.B, SortOrder = 7            },
            new BaseballPosition { Code = "LF"  , FullName = "Left Fielder"     , PlayerType = PlayerType.B, SortOrder = 8            },
            new BaseballPosition { Code = "CF"  , FullName = "Center Feilder"   , PlayerType = PlayerType.B, SortOrder = 9            },
            new BaseballPosition { Code = "RF"  , FullName = "Right Fielder"    , PlayerType = PlayerType.B, SortOrder = 10           },
            new BaseballPosition { Code = "OF"  , FullName = "Outfielder"       , PlayerType = PlayerType.B, SortOrder = 11           },
            new BaseballPosition { Code = "DH"  , FullName = "Designated Hitter", PlayerType = PlayerType.B, SortOrder = 12           },
            new BaseballPosition { Code = "UTIL", FullName = "Utility"          , PlayerType = PlayerType.B, SortOrder = 13           },
            new BaseballPosition { Code = "SP"  , FullName = "Starting Pitcher" , PlayerType = PlayerType.P, SortOrder = 100          },
            new BaseballPosition { Code = "RP"  , FullName = "Relief Pitcher"   , PlayerType = PlayerType.P, SortOrder = 101          },
            new BaseballPosition { Code = "P"   , FullName = "Pitcher"          , PlayerType = PlayerType.P, SortOrder = 102          }
        };

        private PlayerContext _context;

        public GetPlayerServiceTest() => _context = CreateContext().Result;

        [Fact]
        public async void GetPlayersTest()
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new BaseballPlayerProfile())).CreateMapper();
            var positionService = new Mock<IGetPositionService>();
            positionService.Setup(o => o.GetPositions()).Returns(Task.FromResult(POSITIONS));
            var sortService = new Mock<ISortService>();
            sortService.Setup(o => o.SortPlayers(It.IsAny<List<BaseballPlayer>>())).Returns((List<BaseballPlayer> players) => players);
            var players = await new GetPlayersService(_context, mapper, positionService.Object, sortService.Object).GetPlayers();
            Assert.Equal(3, players.Count);
            players.ForEach(player =>
            {
                Assert.Equal(player.BhqId < 3 ? "Brewers" : "Rays", player.Team.Nickname);
                Assert.Equal(player.BhqId, player.Type == PlayerType.B ? player.BattingStats.First().AtBats : player.PitchingStats.First().InningsPitched);
                Assert.Equal(player.BhqId % 2 == 0 ? LeagueStatus.A : LeagueStatus.R, player.League1);
                Assert.Equal(player.BhqId % 2 == 0 ? LeagueStatus.R : LeagueStatus.A, player.League2);
            });
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
                    LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 1, LeagueStatus = LeagueStatus.R } }
                }
            );
            await context.SaveChangesAsync();
            Assert.Equal(3, await context.Players.CountAsync());
            return context;
        }
    }
}