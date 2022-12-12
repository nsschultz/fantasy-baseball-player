using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Maps;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.Services.Mergers.UnitTests
{
  public class FullPlayerMergerTest
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

    [Fact]
    public void MergePlayerNullTest()
    {
      var existingPlayer = new PlayerEntity();
      Assert.Equal(existingPlayer, new FullPlayerMerger().MergePlayer(null, null, existingPlayer));
    }

    [Fact]
    public void MergePlayerValidTest()
    {
      var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
      var player = BuildPlayer();
      ValidatePlayer(player, new FullPlayerMerger().MergePlayer(mapper, player, new PlayerEntity()));
    }

    private static BattingStats BuildBattingStats(StatsType statsType) =>
      new BattingStats
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

    private static PitchingStats BuildPitchingStats(StatsType statsType) =>
      new PitchingStats
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

    private static BaseballPlayerV2 BuildPlayer() =>
      new BaseballPlayerV2
      {
        BhqId = 123,
        FirstName = "First",
        LastName = "Last",
        Age = 36,
        Type = PlayerType.U,
        Positions = BuildPositionList(new string[] { "OF", "1B" }),
        Team = new BaseballTeam { Code = "MIL" },
        Status = PlayerStatus.XX,
        DraftRank = 1,
        AverageDraftPick = 2,
        HighestPick = 3,
        DraftedPercentage = 4,
        MayberryMethod = 5,
        Reliability = 6,
        League1 = LeagueStatus.R,
        League2 = LeagueStatus.X,
        BattingStats = new List<BattingStats> { BuildBattingStats(StatsType.YTD), BuildBattingStats(StatsType.PROJ) },
        PitchingStats = new List<PitchingStats> { BuildPitchingStats(StatsType.YTD), BuildPitchingStats(StatsType.PROJ) }
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

    private static void ValidatePlayer(BaseballPlayerV2 expected, PlayerEntity actual)
    {
      Assert.Equal(expected.BhqId, actual.BhqId);
      Assert.Equal(expected.FirstName, actual.FirstName);
      Assert.Equal(expected.LastName, actual.LastName);
      Assert.Equal(expected.Age, actual.Age);
      Assert.Equal(expected.Type, actual.Type);
      Assert.Equal(BuildPositionString(expected.Positions), BuildPositionString(actual.Positions));
      Assert.Equal(expected.Team.Code, actual.Team);
      Assert.Equal(expected.Status, actual.Status);
      Assert.Equal(expected.DraftRank, actual.DraftRank);
      Assert.Equal(expected.AverageDraftPick, actual.AverageDraftPick);
      Assert.Equal(expected.HighestPick, actual.HighestPick);
      Assert.Equal(expected.DraftedPercentage, actual.DraftedPercentage);
      Assert.Equal(expected.MayberryMethod, actual.MayberryMethod);
      Assert.Equal(expected.Reliability, actual.Reliability);
      Assert.Equal(expected.League1, actual.LeagueStatuses.First(l => l.LeagueId == 1).LeagueStatus);
      Assert.Equal(expected.League2, actual.LeagueStatuses.First(l => l.LeagueId == 2).LeagueStatus);
      ValidatePlayerBattingStats(expected.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD), actual.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD));
      ValidatePlayerBattingStats(expected.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ), actual.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ));
      ValidatePlayerPitchingStats(expected.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD), actual.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD));
      ValidatePlayerPitchingStats(expected.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ), actual.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ));
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