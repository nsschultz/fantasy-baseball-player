using System;
using Xunit;

namespace FantasyBaseball.PlayerService.Database.Entities.UnitTests
{
  public class PlayerPositionEntityTest
  {
    [Fact]
    public void DefaultsSetTest()
    {
      var obj = new PlayerPositionEntity();
      Assert.Null(obj.PositionCode);
      Assert.Equal((Guid)default, obj.PlayerId);
      Assert.Null(obj.Player);
    }
  }
}