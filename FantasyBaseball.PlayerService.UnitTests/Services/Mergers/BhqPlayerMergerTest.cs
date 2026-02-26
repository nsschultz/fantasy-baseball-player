using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Maps;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using FantasyBaseball.PlayerService.Services.Mergers;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Services.Mergers;

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
    ValidatePlayer(new BhqPlayerMerger().MergePlayer(mapper, player, null));
  }

  [Fact]
  public void MergePlayerNoExistingEmptyAdpTest()
  {
    var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
    var player = BuildPlayer();
    player.AverageDraftPick = -1;
    player.AverageDraftPickMin = -1;
    player.AverageDraftPickMax = -1;
    player.MayberryMethod = -1;
    player.Reliability = -1;
    ValidatePlayer(new BhqPlayerMerger().MergePlayer(mapper, player, null), true, true);
  }

  [Fact]
  public void MergePlayerNoIncomingTest()
  {
    var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
    var player = BuildPlayer();
    var entity = new BhqPlayerMerger().MergePlayer(mapper, player, null);
    ValidatePlayer(new BhqPlayerMerger().MergePlayer(mapper, new BaseballPlayer(), entity));
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
    ValidatePlayer(new BhqPlayerMerger().MergePlayer(mapper, player, entity));
  }

  [Fact]
  public void MergePlayerMatchBhqTest()
  {
    var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
    var player = BuildPlayer();
    player.AverageDraftPick = -1;
    player.AverageDraftPickMin = -1;
    player.AverageDraftPickMax = -1;
    player.MayberryMethod = -1;
    player.Reliability = -1;
    var entity = new BhqPlayerMerger().MergePlayer(mapper, player, null);
    entity.MlbAmId = 1231243;
    entity.Age = 34563453;
    entity.Team = "xyasasdfasdf";
    entity.AverageDraftPick = 2;
    entity.AverageDraftPickMin = 1;
    entity.AverageDraftPickMax = 4;
    entity.MayberryMethod = 5;
    entity.Reliability = 6;
    entity.BattingStats.Clear();
    entity.PitchingStats.Clear();
    ValidatePlayer(new BhqPlayerMerger().MergePlayer(mapper, player, entity));
  }

  [Fact]
  public void MergePlayerMatcEmptyAdpTest()
  {
    var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlayerEntityProfile())).CreateMapper();
    var player = BuildPlayer();
    player.AverageDraftPick = 0;
    player.AverageDraftPickMin = 0;
    player.AverageDraftPickMax = 0;
    var entity = new BhqPlayerMerger().MergePlayer(mapper, player, null);
    entity.MlbAmId = 1231243;
    entity.Age = 34563453;
    entity.Team = "xyasasdfasdf";
    entity.AverageDraftPick = 2;
    entity.AverageDraftPickMin = 1;
    entity.AverageDraftPickMax = 4;
    entity.MayberryMethod = 5;
    entity.Reliability = 6;
    entity.BattingStats.Clear();
    entity.PitchingStats.Clear();
    ValidatePlayer(new BhqPlayerMerger().MergePlayer(mapper, player, entity), true);
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

  private static BaseballPlayer BuildPlayer() =>
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
      AverageDraftPick = 2,
      AverageDraftPickMin = 1,
      AverageDraftPickMax = 4,
      MayberryMethod = 5,
      Reliability = 6,
      League1 = LeagueStatus.R,
      League2 = LeagueStatus.X,
      BattingStats = [BuildBattingStats(StatsType.YTD), BuildBattingStats(StatsType.PROJ)],
      PitchingStats = [BuildPitchingStats(StatsType.YTD), BuildPitchingStats(StatsType.PROJ)]
    };

  private static List<BaseballPosition> BuildPositionList(string[] positions) =>
    positions.SelectMany(p => POSITIONS.Where(pp => pp.Code == p)).ToList();

  private static string BuildPositionString(List<PlayerPositionEntity> positions) =>
    string.Join("-", positions
      .SelectMany(p => POSITIONS.Where(pp => pp.Code == p.PositionCode))
      .OrderBy(p => p.SortOrder)
      .Select(p => p.Code));

  private static void ValidatePlayer(PlayerEntity actual, bool noAdp = false, bool noMM = false)
  {
    Assert.Equal(123, actual.MlbAmId);
    Assert.Equal("First", actual.FirstName);
    Assert.Equal("Last", actual.LastName);
    Assert.Equal(36, actual.Age);
    Assert.Equal(PlayerType.U, actual.Type);
    Assert.Equal("1B-OF", BuildPositionString(actual.Positions));
    Assert.Equal("MIL", actual.Team);
    Assert.Equal(PlayerStatus.XX, actual.Status);
    Assert.Equal(noAdp ? 9999 : 2, actual.AverageDraftPick);
    Assert.Equal(noAdp ? 9999 : 4, actual.AverageDraftPickMax);
    Assert.Equal(noAdp ? 9999 : 1, actual.AverageDraftPickMin);
    Assert.Equal(noMM ? 0 : 5, actual.MayberryMethod);
    Assert.Equal(noMM ? 0 : 6, actual.Reliability);
    Assert.Equal(LeagueStatus.R, actual.LeagueStatuses.First(l => l.LeagueId == 1).LeagueStatus);
    Assert.Equal(LeagueStatus.X, actual.LeagueStatuses.First(l => l.LeagueId == 2).LeagueStatus);
    Assert.Equal(2, actual.BattingStats.Count);
    ValidatePlayerBattingStats(actual.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD));
    ValidatePlayerBattingStats(actual.BattingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ));
    Assert.Equal(2, actual.PitchingStats.Count);
    ValidatePlayerPitchingStats(actual.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.YTD));
    ValidatePlayerPitchingStats(actual.PitchingStats.FirstOrDefault(s => s.StatsType == StatsType.PROJ));
  }

  private static void ValidatePlayerBattingStats(BattingStatsEntity actual)
  {
    Assert.Equal(300, actual.AtBats);
    Assert.Equal(75, actual.Runs);
    Assert.Equal(96, actual.Hits);
    Assert.Equal(24, actual.Doubles);
    Assert.Equal(6, actual.Triples);
    Assert.Equal(12, actual.HomeRuns);
    Assert.Equal(48, actual.RunsBattedIn);
    Assert.Equal(30, actual.BaseOnBalls);
    Assert.Equal(60, actual.StrikeOuts);
    Assert.Equal(9, actual.StolenBases);
    Assert.Equal(3, actual.CaughtStealing);
    Assert.Equal(100, actual.Power);
    Assert.Equal(61, actual.Speed);
  }

  private static void ValidatePlayerPitchingStats(PitchingStatsEntity actual)
  {
    Assert.Equal(12, actual.Wins);
    Assert.Equal(6, actual.Losses);
    Assert.Equal(18, actual.QualityStarts);
    Assert.Equal(9, actual.Saves);
    Assert.Equal(3, actual.BlownSaves);
    Assert.Equal(15, actual.Holds);
    Assert.Equal(60, actual.InningsPitched);
    Assert.Equal(45, actual.HitsAllowed);
    Assert.Equal(24, actual.EarnedRuns);
    Assert.Equal(1, actual.HomeRunsAllowed);
    Assert.Equal(30, actual.BaseOnBallsAllowed);
    Assert.Equal(120, actual.StrikeOuts);
    Assert.Equal(0.2, actual.FlyBallRate);
    Assert.Equal(0.31, actual.GroundBallRate);
  }
}