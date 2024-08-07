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
  public class BhqPlayerMergerTest
  {
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
    public void MergePlayerNoExistingTest()
    {
      var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
      var player = BuildPlayer();
      ValidatePlayer(player, new BhqPlayerMerger().MergePlayer(mapper, player, null));
    }

    [Fact]
    public void MergePlayerNoIncomingTest()
    {
      var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
      var player = BuildPlayer();
      var entity = new BhqPlayerMerger().MergePlayer(mapper, player, null);
      ValidatePlayer(player, new BhqPlayerMerger().MergePlayer(mapper, new BaseballPlayer(), entity));
    }

    [Fact]
    public void MergePlayerMatchTest()
    {
      var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
      var player = BuildPlayer();
      var entity = new BhqPlayerMerger().MergePlayer(mapper, player, null);
      entity.MlbAmId = 1231243;
      entity.Age = 34563453;
      entity.Team = "xyasasdfasdf";
      entity.Reliability = 6745674567465;
      entity.MayberryMethod = 53451;
      entity.AverageDraftPick = 345;
      entity.AverageDraftPickMax = 654;
      entity.AverageDraftPickMin = 234;
      entity.BattingStats.Clear();
      entity.PitchingStats.Clear();
      ValidatePlayer(player, new BhqPlayerMerger().MergePlayer(mapper, player, entity));
    }

    [Fact]
    public void MergePlayerMatchDraftTest()
    {
      var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
      var player = BuildPlayer(true);
      var entity = new BhqPlayerMerger().MergePlayer(mapper, player, null);
      entity.MlbAmId = 1231243;
      entity.Age = 34563453;
      entity.Team = "xyasasdfasdf";
      entity.Reliability = 6745674567465;
      entity.MayberryMethod = 53451;
      entity.AverageDraftPick = 345;
      entity.AverageDraftPickMax = 654;
      entity.AverageDraftPickMin = 234;
      entity.BattingStats.Clear();
      entity.PitchingStats.Clear();
      ValidatePlayer(player, new BhqPlayerMerger().MergePlayer(mapper, player, entity), 345, 654, 234);
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

    private static BaseballPlayer BuildPlayer(bool maxDraft = false) =>
      new()
      {
        MlbAmId = 123,
        FirstName = "First",
        LastName = "Last",
        Age = 36,
        Type = PlayerType.U,
        Positions = BuildPositionList(["OF", "1B"]),
        Team = new BaseballTeam { Code = "MIL" },
        Status = PlayerStatus.XX,
        AverageDraftPick = maxDraft ? 9999 : 2,
        AverageDraftPickMin = maxDraft ? 9999 : 1,
        AverageDraftPickMax = maxDraft ? 9999 : 4,
        MayberryMethod = 5,
        Reliability = 6,
        League1 = LeagueStatus.R,
        League2 = LeagueStatus.X,
        BattingStats = [BuildBattingStats(StatsType.YTD), BuildBattingStats(StatsType.PROJ)],
        PitchingStats = [BuildPitchingStats(StatsType.YTD), BuildPitchingStats(StatsType.PROJ)]
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

    private static void ValidatePlayer(BaseballPlayer expected, PlayerEntity actual, double adp = 0, int maxPick = 0, int minPick = 0)
    {
      Assert.Equal(expected.MlbAmId, actual.MlbAmId);
      Assert.Equal(expected.FirstName, actual.FirstName);
      Assert.Equal(expected.LastName, actual.LastName);
      Assert.Equal(expected.Age, actual.Age);
      Assert.Equal(expected.Type, actual.Type);
      Assert.Equal(BuildPositionString(expected.Positions), BuildPositionString(actual.Positions));
      Assert.Equal(expected.Team.Code, actual.Team);
      Assert.Equal(expected.Status, actual.Status);
      Assert.Equal(adp > 0 && expected.AverageDraftPick == 9999 ? adp : expected.AverageDraftPick, actual.AverageDraftPick);
      Assert.Equal(maxPick > 0 && expected.AverageDraftPickMax == 9999 ? maxPick : expected.AverageDraftPickMax, actual.AverageDraftPickMax);
      Assert.Equal(minPick > 0 && expected.AverageDraftPickMin == 9999 ? minPick : expected.AverageDraftPickMin, actual.AverageDraftPickMin);
      Assert.Equal(expected.MayberryMethod, actual.MayberryMethod);
      Assert.Equal(expected.Reliability, actual.Reliability);
      Assert.Equal(expected.League1, actual.LeagueStatuses.First(l => l.LeagueId == 1).LeagueStatus);
      Assert.Equal(expected.League2, actual.LeagueStatuses.First(l => l.LeagueId == 2).LeagueStatus);
      Assert.Equal(expected.BattingStats.Count, actual.BattingStats.Count);
      if (expected.BattingStats.Count != 0)
      {
        ValidatePlayerBattingStats(expected.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD), actual.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD));
        ValidatePlayerBattingStats(expected.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ), actual.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ));
      }
      Assert.Equal(expected.PitchingStats.Count, actual.PitchingStats.Count);
      if (expected.PitchingStats.Count != 0)
      {
        ValidatePlayerPitchingStats(expected.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD), actual.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD));
        ValidatePlayerPitchingStats(expected.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ), actual.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ));
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