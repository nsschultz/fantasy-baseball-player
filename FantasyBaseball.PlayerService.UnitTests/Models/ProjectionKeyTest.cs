using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Models.Enums;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Models
{
  public class ProjectionKeyTest
  {
    private static readonly ProjectionKey BaseTestObj = new ProjectionKey(10, PlayerType.B);

    [Fact] public void EqualsDifferentIdTest() => Assert.False(BaseTestObj.Equals(new ProjectionKey(100, PlayerType.B)));

    [Fact] public void EqualsDifferentTypeTest() => Assert.False(BaseTestObj.Equals(new ProjectionKey(10, PlayerType.P)));

    [Fact] public void EqualsNullTest() => Assert.False(BaseTestObj.Equals(null));

    [Fact] public void EqualsOtherClassTest() => Assert.False(BaseTestObj.Equals(""));

    [Fact] public void EqualsSameTest() => Assert.True(BaseTestObj.Equals(new ProjectionKey(10, PlayerType.B)));

    [Fact] public void GetHashCodeEqualsTest() => Assert.Equal(BaseTestObj.GetHashCode(), new ProjectionKey(10, PlayerType.B).GetHashCode());

    [Fact] public void GetHashCodeNotEqualsTest() => Assert.NotEqual(BaseTestObj.GetHashCode(), new ProjectionKey(1, PlayerType.P).GetHashCode());
  }
}