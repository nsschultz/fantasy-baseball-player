using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Models
{
  public class BaseballPositionTest
  {
    [Fact]
    public void DefaultsSetTest()
    {
      var obj = new BaseballPosition();
      Assert.Null(obj.Code);
      Assert.Null(obj.FullName);
      Assert.Equal(PlayerType.U, obj.PlayerType);
      Assert.Equal(0, obj.SortOrder);
      Assert.Empty(obj.AdditionalPositions);
    }
  }
}