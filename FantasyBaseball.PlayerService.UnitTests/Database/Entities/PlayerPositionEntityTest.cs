using System;
using FantasyBaseball.PlayerService.Database.Entities;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Database.Entities;

public class PlayerPositionEntityTest
{
  [Fact]
  public void DefaultsSetTest()
  {
    var obj = new PlayerPositionEntity();
    Assert.Null(obj.PositionCode);
    Assert.Equal(Guid.Empty, obj.PlayerId);
    Assert.Null(obj.Player);
  }
}