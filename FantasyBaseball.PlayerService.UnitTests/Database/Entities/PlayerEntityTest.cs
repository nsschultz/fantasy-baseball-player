using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.Database.Entities.UnitTests
{
  public class PlayerEntityTest
  {
    [Fact]
    public void DefaultsSetTest()
    {
      var obj = new PlayerEntity();
      Assert.Equal(default, obj.Id);
      Assert.Equal(0, obj.BhqId);
      Assert.Equal(0, obj.MlbAmId);
      Assert.Equal(PlayerType.U, obj.Type);
      Assert.Null(obj.FirstName);
      Assert.Null(obj.LastName);
      Assert.Equal(0, obj.Age);
      Assert.Null(obj.Team);
      Assert.Equal(PlayerStatus.XX, obj.Status);
      Assert.Equal(0, obj.AverageDraftPick);
      Assert.Equal(0, obj.AverageDraftPickMax);
      Assert.Equal(0, obj.AverageDraftPickMin);
      Assert.Equal(0, obj.Reliability);
      Assert.Equal(0, obj.MayberryMethod);
      Assert.Empty(obj.LeagueStatuses);
      Assert.Empty(obj.BattingStats);
      Assert.Empty(obj.PitchingStats);
      Assert.Empty(obj.Positions);
    }
  }
}