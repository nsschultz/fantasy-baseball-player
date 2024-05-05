using System;
using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.Models.UnitTests
{
  public class BaseballPlayerTest
  {
    [Fact]
    public void DefaultsSetTest()
    {
      var obj = new BaseballPlayer();
      Assert.Equal(Guid.Empty, obj.Id);
      Assert.Equal(0, obj.MlbAmId);
      Assert.Equal(0, obj.BhqId);
      Assert.Null(obj.FirstName);
      Assert.Null(obj.LastName);
      Assert.Equal(0, obj.Age);
      Assert.Equal(PlayerType.U, obj.Type);
      Assert.Empty(obj.Positions);
      Assert.Null(obj.Team);
      Assert.Equal(PlayerStatus.XX, obj.Status);
      Assert.Equal(LeagueStatus.A, obj.League1);
      Assert.Equal(LeagueStatus.A, obj.League2);
      Assert.Equal(9999, obj.AverageDraftPick);
      Assert.Equal(9999, obj.AverageDraftPickMax);
      Assert.Equal(9999, obj.AverageDraftPickMin);
      Assert.Equal(0, obj.Reliability);
      Assert.Equal(0, obj.MayberryMethod);
      Assert.Empty(obj.BattingStats);
      Assert.Empty(obj.PitchingStats);
    }
  }
}