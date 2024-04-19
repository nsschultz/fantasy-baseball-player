using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Maps;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services.Mergers;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.UnitTests
{
  public class MergePlayerServiceTest
  {
    private static readonly Dictionary<int, string> EXPECTED_TEAMS = new() { { 10, "MIL" }, { 100, "TB" }, { 123, "" } };
    private static readonly IPlayerMerger MERGER = new FullPlayerMerger();
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
    private static readonly List<TeamEntity> TEAMS =
    [
      new() { Code = ""   , LeagueId = ""  , City = "Free Agent"   , Nickname = "Free Agent"                            },
      new() { Code = "BAL", LeagueId = "AL", City = "Baltimore"    , Nickname = "Orioles"                               },
      new() { Code = "BOS", LeagueId = "AL", City = "Boston"       , Nickname = "Red Sox"                               },
      new() { Code = "NYY", LeagueId = "AL", City = "New York"     , Nickname = "Yankees"                               },
      new() { Code = "TB" , LeagueId = "AL", City = "Tampa Bay"    , Nickname = "Rays"       , AlternativeCode = "TAM"  },
      new() { Code = "TOR", LeagueId = "AL", City = "Toronto"      , Nickname = "Blue Jays"                             },
      new() { Code = "CWS", LeagueId = "AL", City = "Chicago"      , Nickname = "White Sox"  , AlternativeCode = "CHW"  },
      new() { Code = "CLE", LeagueId = "AL", City = "Cleveland"    , Nickname = "Indians"                               },
      new() { Code = "DET", LeagueId = "AL", City = "Detriot"      , Nickname = "Tigers"                                },
      new() { Code = "KC" , LeagueId = "AL", City = "Kansas City"  , Nickname = "Royals"                                },
      new() { Code = "MIN", LeagueId = "AL", City = "Minnesota"    , Nickname = "Twins"                                 },
      new() { Code = "HOU", LeagueId = "AL", City = "Houston"      , Nickname = "Astros"                                },
      new() { Code = "LAA", LeagueId = "AL", City = "Los Angeles"  , Nickname = "Angels"                                },
      new() { Code = "OAK", LeagueId = "AL", City = "Oakland"      , Nickname = "Athletics"                             },
      new() { Code = "SEA", LeagueId = "AL", City = "Seattle"      , Nickname = "Mariners"                              },
      new() { Code = "TEX", LeagueId = "AL", City = "Texas"        , Nickname = "Rangers"                               },
      new() { Code = "ATL", LeagueId = "NL", City = "Atlanta"      , Nickname = "Braves"                                },
      new() { Code = "MIA", LeagueId = "NL", City = "Miami"        , Nickname = "Marlins"                               },
      new() { Code = "NYM", LeagueId = "NL", City = "New York"     , Nickname = "Mets"                                  },
      new() { Code = "PHI", LeagueId = "NL", City = "Philadelphia" , Nickname = "Phillies"                              },
      new() { Code = "WAS", LeagueId = "NL", City = "Washington"   , Nickname = "Nationals"                             },
      new() { Code = "CHC", LeagueId = "NL", City = "Chicago"      , Nickname = "Cubs"                                  },
      new() { Code = "CIN", LeagueId = "NL", City = "Cincinnati"   , Nickname = "Reds"                                  },
      new() { Code = "MIL", LeagueId = "NL", City = "Milwaukee"    , Nickname = "Brewers"                               },
      new() { Code = "PIT", LeagueId = "NL", City = "Pittsburgh"   , Nickname = "Pirates"                               },
      new() { Code = "STL", LeagueId = "NL", City = "St. Louis"    , Nickname = "Cardinals"                             },
      new() { Code = "ARZ", LeagueId = "NL", City = "Arizona"      , Nickname = "Diamondbacks", AlternativeCode = "ARI" },
      new() { Code = "COL", LeagueId = "NL", City = "Colorado"     , Nickname = "Rockies"                               },
      new() { Code = "LAD", LeagueId = "NL", City = "Los Angeles"  , Nickname = "Dodgers"     , AlternativeCode = "LA"  },
      new() { Code = "SD" , LeagueId = "NL", City = "San Diego"    , Nickname = "Padres"                                },
      new() { Code = "SF" , LeagueId = "NL", City = "San Francisco", Nickname = "Giants"                                }
    ];

    [Fact]
    public async Task MergePlayerEntityNullTest()
    {
      var existingPlayer = new PlayerEntity();
      Assert.Equal(existingPlayer, await BuildPlayerEntityMergerService().MergePlayer(MERGER, null, existingPlayer));
    }

    [Theory]
    [InlineData(10, PlayerType.B)]
    [InlineData(100, PlayerType.P)]
    [InlineData(123, PlayerType.U)]
    public async Task MergePlayerEntityMatchMissingEntriesTest(int value, PlayerType type)
    {
      var player = BuildPlayer(value, type);
      var otherEntity = await BuildPlayerEntityMergerService().MergePlayer(MERGER, BuildPlayer(value == 10 ? 100 : 10, PlayerType.U), null);
      ValidatePlayer(value, player, await BuildPlayerEntityMergerService().MergePlayer(MERGER, player, otherEntity));
    }

    [Theory]
    [InlineData(10, PlayerType.B)]
    [InlineData(100, PlayerType.P)]
    [InlineData(123, PlayerType.U)]
    public async Task MergePlayerEntityMatchSameEntriesTest(int value, PlayerType type)
    {
      var player = BuildPlayer(value, type);
      var otherEntity = await BuildPlayerEntityMergerService().MergePlayer(MERGER, BuildPlayer(value, type), null);
      ValidatePlayer(value, player, await BuildPlayerEntityMergerService().MergePlayer(MERGER, player, otherEntity));
    }

    [Theory]
    [InlineData(10, PlayerType.B)]
    [InlineData(100, PlayerType.P)]
    [InlineData(123, PlayerType.U)]
    public async Task MergePlayerEntityNoMatchTest(int value, PlayerType type)
    {
      var player = BuildPlayer(value, type);
      ValidatePlayer(value, player, await BuildPlayerEntityMergerService().MergePlayer(MERGER, player, null));
    }

    [Theory]
    [InlineData(10, PlayerType.B)]
    [InlineData(100, PlayerType.P)]
    [InlineData(123, PlayerType.U)]
    public async Task MergePlayerEntityStatsMismatchTest(int value, PlayerType type)
    {
      var player = BuildPlayer(value, type);
      var otherEntity = await BuildPlayerEntityMergerService().MergePlayer(MERGER, BuildPlayer(value, type, true), null);
      ValidatePlayer(value, player, await BuildPlayerEntityMergerService().MergePlayer(MERGER, player, otherEntity));
    }

    private static BattingStats BuildBattingStats(StatsType statsType) =>
      new()
      {
        StatsType = statsType,
        AtBats = 300,
        Runs = 75,
        Hits = 96,
        Doubles = 24,
        Triples = 6,
        HomeRuns = 12,
        RunsBattedIn = 48,
        BaseOnBalls = 30,
        StrikeOuts = 60,
        StolenBases = 9,
        CaughtStealing = 3,
        Power = 100,
        Speed = 61
      };

    private static MergePlayerService BuildPlayerEntityMergerService()
    {
      var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
      var positionService = new Mock<IGetPositionService>();
      positionService.Setup(o => o.GetPositions()).ReturnsAsync(POSITIONS);
      var teamService = new Mock<IGetTeamsService>();
      teamService.Setup(o => o.GetTeams()).ReturnsAsync(TEAMS);
      return new MergePlayerService(mapper, positionService.Object, teamService.Object);
    }

    private static PitchingStats BuildPitchingStats(StatsType statsType) =>
      new()
      {
        StatsType = statsType,
        Wins = 12,
        Losses = 6,
        QualityStarts = 18,
        Saves = 9,
        BlownSaves = 3,
        Holds = 15,
        InningsPitched = 60,
        HitsAllowed = 45,
        EarnedRuns = 24,
        HomeRunsAllowed = 1,
        BaseOnBallsAllowed = 30,
        StrikeOuts = 120,
        FlyBallRate = 0.2,
        GroundBallRate = 0.31
      };

    private static BaseballPlayer BuildPlayer(int value, PlayerType type, bool bothStats = false) =>
      new()
      {
        MlbAmId = value,
        FirstName = $"First-{value}",
        LastName = $"Last-{value}",
        Age = value,
        Type = type,
        Positions = type == PlayerType.B
          ? BuildPositionList(["XX", "OF", "1B"])
          : type == PlayerType.P ? BuildPositionList(["SP", "XX", "RP"]) : BuildPositionList(["XX"]),
        Team = new BaseballTeam { Code = type == PlayerType.B ? "MIL" : type == PlayerType.P ? "TB" : "XX" },
        Status = value == 10 ? PlayerStatus.XX : PlayerStatus.IL,
        AverageDraftPick = value + 2,
        AverageDraftPickMin = value + 1,
        AverageDraftPickMax = value + 4,
        MayberryMethod = value + 5,
        Reliability = value + 6,
        League1 = value == 10 ? LeagueStatus.R : LeagueStatus.A,
        League2 = value != 10 ? LeagueStatus.X : LeagueStatus.A,
        BattingStats = !bothStats && PlayerType.U == type ? [] :
        [
          bothStats || value == 10 ? BuildBattingStats(StatsType.YTD) : new BattingStats { StatsType = StatsType.YTD },
          bothStats || value != 10 ? BuildBattingStats(StatsType.PROJ) : new BattingStats { StatsType = StatsType.PROJ }
        ],
        PitchingStats = !bothStats && PlayerType.U == type ? [] :
        [
          bothStats || value == 10 ? BuildPitchingStats(StatsType.YTD) : new PitchingStats { StatsType = StatsType.YTD },
          bothStats || value != 10 ? BuildPitchingStats(StatsType.PROJ) : new PitchingStats { StatsType = StatsType.PROJ }
        ]
      };

    private static List<BaseballPosition> BuildPositionList(string[] positions) =>
      positions.SelectMany(p => POSITIONS.Where(pp => pp.Code == p)).ToList();

    private static string BuildPositionString(List<BaseballPosition> positions) =>
      string.Join("-", positions.OrderBy(p => p.SortOrder).Select(p => p.Code));

    private static string BuildPositionString(List<PlayerPositionEntity> positions) =>
      string.Join("-", positions
        .SelectMany(p => POSITIONS.Where(pp => pp.Code == p.PositionCode))
        .OrderBy(p => p.SortOrder)
        .Select(p => p.Code));

    private static void ValidatePlayer(int value, BaseballPlayer expected, PlayerEntity actual)
    {
      Assert.Equal(expected.MlbAmId, actual.MlbAmId);
      Assert.Equal(expected.FirstName, actual.FirstName);
      Assert.Equal(expected.LastName, actual.LastName);
      Assert.Equal(expected.Age, actual.Age);
      Assert.Equal(expected.Type, actual.Type);
      Assert.Equal(BuildPositionString(expected.Positions), BuildPositionString(actual.Positions));
      Assert.Equal(EXPECTED_TEAMS[value], actual.Team);
      Assert.Equal(expected.Status, actual.Status);
      Assert.Equal(expected.AverageDraftPick, actual.AverageDraftPick);
      Assert.Equal(expected.AverageDraftPickMax, actual.AverageDraftPickMax);
      Assert.Equal(expected.AverageDraftPickMin, actual.AverageDraftPickMin);
      Assert.Equal(expected.MayberryMethod, actual.MayberryMethod);
      Assert.Equal(expected.Reliability, actual.Reliability);
      Assert.Equal(expected.League1, actual.LeagueStatuses.First(l => l.LeagueId == 1).LeagueStatus);
      Assert.Equal(expected.League2, actual.LeagueStatuses.First(l => l.LeagueId == 2).LeagueStatus);
      if (expected.Type != PlayerType.U)
      {
        ValidatePlayerBattingStats(expected.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD), actual.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD));
        ValidatePlayerBattingStats(expected.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ), actual.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ));
        ValidatePlayerPitchingStats(expected.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD), actual.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD));
        ValidatePlayerPitchingStats(expected.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ), actual.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ));
      }
      else
      {
        Assert.Empty(actual.BattingStats);
        Assert.Empty(actual.PitchingStats);
      }
    }

    private static void ValidatePlayerBattingStats(BattingStats expected, BattingStatsEntity actual)
    {
      Assert.Equal(expected.AtBats, actual.AtBats);
      Assert.Equal(expected.Runs, actual.Runs);
      Assert.Equal(expected.Hits, actual.Hits);
      Assert.Equal(expected.Doubles, actual.Doubles);
      Assert.Equal(expected.Triples, actual.Triples);
      Assert.Equal(expected.HomeRuns, actual.HomeRuns);
      Assert.Equal(expected.RunsBattedIn, actual.RunsBattedIn);
      Assert.Equal(expected.BaseOnBalls, actual.BaseOnBalls);
      Assert.Equal(expected.StrikeOuts, actual.StrikeOuts);
      Assert.Equal(expected.StolenBases, actual.StolenBases);
      Assert.Equal(expected.CaughtStealing, actual.CaughtStealing);
      Assert.Equal(expected.Power, actual.Power);
      Assert.Equal(expected.Speed, actual.Speed);
    }

    private static void ValidatePlayerPitchingStats(PitchingStats expected, PitchingStatsEntity actual)
    {
      Assert.Equal(expected.Wins, actual.Wins);
      Assert.Equal(expected.Losses, actual.Losses);
      Assert.Equal(expected.QualityStarts, actual.QualityStarts);
      Assert.Equal(expected.Saves, actual.Saves);
      Assert.Equal(expected.BlownSaves, actual.BlownSaves);
      Assert.Equal(expected.Holds, actual.Holds);
      Assert.Equal(expected.InningsPitched, actual.InningsPitched);
      Assert.Equal(expected.HitsAllowed, actual.HitsAllowed);
      Assert.Equal(expected.EarnedRuns, actual.EarnedRuns);
      Assert.Equal(expected.HomeRunsAllowed, actual.HomeRunsAllowed);
      Assert.Equal(expected.BaseOnBallsAllowed, actual.BaseOnBallsAllowed);
      Assert.Equal(expected.StrikeOuts, actual.StrikeOuts);
      Assert.Equal(expected.FlyBallRate, actual.FlyBallRate);
      Assert.Equal(expected.GroundBallRate, actual.GroundBallRate);
    }
  }
}