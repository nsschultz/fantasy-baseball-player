using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Maps;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTests
{
    public class GetPlayerServiceTest
    {
        private static readonly List<PlayerEntity> PLAYERS = new List<PlayerEntity>
        {
            new PlayerEntity
            {
                BhqId = 1,
                FirstName = "Christian",
                LastName = "Yelich",
                Type = PlayerType.B,
                PlayerTeam = new TeamEntity { Code = "MIL"},
                BattingStats = new List<BattingStatsEntity> { new BattingStatsEntity { StatsType = StatsType.YTD, AtBats = 1 } },
                LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 1, LeagueStatus = LeagueStatus.R } }
            },
            new PlayerEntity
            {
                BhqId = 2,
                FirstName = "Corbin",
                LastName = "Burnes",
                Type = PlayerType.P,
                PlayerTeam = new TeamEntity { Code = "MIL"},
                PitchingStats = new List<PitchingStatsEntity> { new PitchingStatsEntity { StatsType = StatsType.YTD, InningsPitched = 2 } },
                LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 2, LeagueStatus = LeagueStatus.R } }
            },
            new PlayerEntity
            {
                BhqId = 3,
                FirstName = "Wander",
                LastName = "Franco",
                Type = PlayerType.B,
                PlayerTeam = new TeamEntity { Code = "TB"},
                BattingStats = new List<BattingStatsEntity> { new BattingStatsEntity { StatsType = StatsType.PROJ, AtBats = 3 } },
                LeagueStatuses = new List<PlayerLeagueStatusEntity> { new PlayerLeagueStatusEntity { LeagueId = 1, LeagueStatus = LeagueStatus.R } }
            }
        };
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

        [Fact]
        public async void GetPlayersTest()
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new BaseballPlayerProfile())).CreateMapper();
            var positionService = new Mock<IGetPositionService>();
            positionService.Setup(o => o.GetPositions()).ReturnsAsync(POSITIONS);
            var playerRepo = new Mock<IPlayerRepository>();
            playerRepo.Setup(o => o.GetPlayers(It.IsAny<PlayerType?>())).ReturnsAsync(PLAYERS);
            var players = await new GetPlayersService(mapper, playerRepo.Object, positionService.Object).GetPlayers();
            Assert.Equal(3, players.Count);
            players.ForEach(player =>
            {
                Assert.Equal(player.BhqId < 3 ? "MIL" : "TB", player.Team.Code);
                Assert.Equal(player.BhqId, player.Type == PlayerType.B ? player.BattingStats.First().AtBats : player.PitchingStats.First().InningsPitched);
                Assert.Equal(player.BhqId % 2 == 0 ? LeagueStatus.A : LeagueStatus.R, player.League1);
                Assert.Equal(player.BhqId % 2 == 0 ? LeagueStatus.R : LeagueStatus.A, player.League2);
            });
        }
    }
}