using System;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Models
{
  public class CsvBaseballPlayerTest
  {
    [Fact]
    public void DefaultsSetTest()
    {
      var obj = new CsvBaseballPlayer();
      Assert.Equal(Guid.Empty, obj.Id);
      Assert.Equal(0, obj.MlbAmId);
      Assert.Null(obj.FirstName);
      Assert.Null(obj.LastName);
      Assert.Equal(0, obj.Age);
      Assert.Equal(PlayerType.U, obj.Type);
      Assert.Empty(obj.Positions);
      Assert.Null(obj.Team);
      Assert.Equal(PlayerStatus.XX, obj.Status);
      Assert.Equal(LeagueStatus.A, obj.League1);
      Assert.Equal(LeagueStatus.A, obj.League2);
      Assert.Equal(0, obj.AverageDraftPick);
      Assert.Equal(0, obj.AverageDraftPickMax);
      Assert.Equal(0, obj.AverageDraftPickMin);
      Assert.Equal(0, obj.Reliability);
      Assert.Equal(0, obj.MayberryMethod);
      Assert.Empty(obj.BattingStats);
      Assert.Empty(obj.PitchingStats);
    }

    [Fact]
    public void FullNameTest()
    {
      var player = new CsvBaseballPlayer { FirstName = "John", LastName = "Doe" };
      Assert.Equal("Doe, John", player.FullName);
      player = new CsvBaseballPlayer { LastName = "Doe" };
      Assert.Equal("Doe", player.FullName);
      player = new CsvBaseballPlayer();
      Assert.Null(player.FullName);
      player = new CsvBaseballPlayer { FullName = "Smith, Jane" };
      Assert.Equal("Smith", player.LastName);
      Assert.Equal("Jane", player.FirstName);
      player = new CsvBaseballPlayer { FullName = "Ichiro" };
      Assert.Equal("Ichiro", player.LastName);
      Assert.Null(player.FirstName);
      player = new CsvBaseballPlayer { FullName = "" };
      Assert.Null(player.LastName);
      Assert.Null(player.FirstName);
    }

    [Fact]
    public void CombinedBattingStatsTest()
    {
      var player = new CsvBaseballPlayer();
      AssertStats(player.CombinedBattingStats, 0, 0, 0);
      player.CombinedBattingStats.AtBats = 100;
      player.CombinedBattingStats.BaseOnBalls = 50;
      AssertStats(player.CombinedBattingStats, 100, 50, 0);
      player.CombinedBattingStats = new BattingStats { HomeRuns = 25 };
      AssertStats(player.CombinedBattingStats, 0, 0, 25);
    }

    [Fact]
    public void ProjectedBattingStatsTest()
    {
      var player = new CsvBaseballPlayer();
      AssertStats(player.ProjectedBattingStats, 0, 0, 0);
      player.ProjectedBattingStats.AtBats = 100;
      player.ProjectedBattingStats.BaseOnBalls = 50;
      AssertStats(player.ProjectedBattingStats, 100, 50, 0);
      player.ProjectedBattingStats = new BattingStats { HomeRuns = 25 };
      AssertStats(player.ProjectedBattingStats, 0, 0, 25);
    }

    [Fact]
    public void YearToDateBattingStatsTest()
    {
      var player = new CsvBaseballPlayer();
      AssertStats(player.YearToDateBattingStats, 0, 0, 0);
      player.YearToDateBattingStats.AtBats = 100;
      player.YearToDateBattingStats.BaseOnBalls = 50;
      AssertStats(player.YearToDateBattingStats, 100, 50, 0);
      player.YearToDateBattingStats = new BattingStats { HomeRuns = 25 };
      AssertStats(player.YearToDateBattingStats, 0, 0, 25);
    }

    [Fact]
    public void CombinedPitchingStatsTest()
    {
      var player = new CsvBaseballPlayer();
      AssertStats(player.CombinedPitchingStats, 0, 0, 0);
      player.CombinedPitchingStats.InningsPitched = 100;
      player.CombinedPitchingStats.EarnedRuns = 50;
      AssertStats(player.CombinedPitchingStats, 100, 50, 0);
      player.CombinedPitchingStats = new PitchingStats { StrikeOuts = 25 };
      AssertStats(player.CombinedPitchingStats, 0, 0, 25);
    }

    [Fact]
    public void ProjectedPitchingStatsTest()
    {
      var player = new CsvBaseballPlayer();
      AssertStats(player.ProjectedPitchingStats, 0, 0, 0);
      player.ProjectedPitchingStats.InningsPitched = 100;
      player.ProjectedPitchingStats.EarnedRuns = 50;
      AssertStats(player.ProjectedPitchingStats, 100, 50, 0);
      player.ProjectedPitchingStats = new PitchingStats { StrikeOuts = 25 };
      AssertStats(player.ProjectedPitchingStats, 0, 0, 25);
    }

    [Fact]
    public void YearToDatePitchingStatsTest()
    {
      var player = new CsvBaseballPlayer();
      AssertStats(player.YearToDatePitchingStats, 0, 0, 0);
      player.YearToDatePitchingStats.InningsPitched = 100;
      player.YearToDatePitchingStats.EarnedRuns = 50;
      AssertStats(player.YearToDatePitchingStats, 100, 50, 0);
      player.YearToDatePitchingStats = new PitchingStats { StrikeOuts = 25 };
      AssertStats(player.YearToDatePitchingStats, 0, 0, 25);
    }

    private static void AssertStats(BattingStats battingStats, int abs, int bbs, int hrs)
    {
      Assert.Equal(abs, battingStats.AtBats);
      Assert.Equal(bbs, battingStats.BaseOnBalls);
      Assert.Equal(hrs, battingStats.HomeRuns);
    }

    private static void AssertStats(PitchingStats PitchingStats, int ips, int ers, int ks)
    {
      Assert.Equal(ips, PitchingStats.InningsPitched);
      Assert.Equal(ers, PitchingStats.EarnedRuns);
      Assert.Equal(ks, PitchingStats.StrikeOuts);
    }
  }
}