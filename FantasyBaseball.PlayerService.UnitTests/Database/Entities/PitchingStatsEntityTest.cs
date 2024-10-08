using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Database.Entities
{
  public class PitchingStatsEntityTest
  {
    [Fact]
    public void DefaultsSetTest()
    {
      var obj = new PitchingStatsEntity();
      Assert.Equal(default, obj.PlayerId);
      Assert.Equal(StatsType.UNKN, obj.StatsType);
      Assert.Equal(0, obj.Wins);
      Assert.Equal(0, obj.Losses);
      Assert.Equal(0, obj.QualityStarts);
      Assert.Equal(0, obj.Saves);
      Assert.Equal(0, obj.BlownSaves);
      Assert.Equal(0, obj.Holds);
      Assert.Equal(0, obj.InningsPitched);
      Assert.Equal(0, obj.HitsAllowed);
      Assert.Equal(0, obj.EarnedRuns);
      Assert.Equal(0, obj.HomeRunsAllowed);
      Assert.Equal(0, obj.BaseOnBallsAllowed);
      Assert.Equal(0, obj.StrikeOuts);
      Assert.Equal(0, obj.FlyBallRate);
      Assert.Equal(0, obj.GroundBallRate);
      Assert.Null(obj.Player);
    }
  }
}