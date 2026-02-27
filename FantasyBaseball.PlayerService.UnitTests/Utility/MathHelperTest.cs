using FantasyBaseball.PlayerService.Utility;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Utility;

public class MathHelperTests
{
  [Theory]
  [InlineData(0, 0, 5)]
  [InlineData(0, 10, 0)]
  [InlineData(2, 10, 5)]
  public void DivideTests(double result, double divided, double divisor) => Assert.Equal(result, MathHelper.Divide(divided, divisor));

  [Theory]
  [InlineData(true, 10, 10)]
  [InlineData(true, 10.0000001, 10)]
  [InlineData(true, 10, 10.0000001)]
  [InlineData(false, 10, 10.1)]
  public void IsEqualtTests(bool result, double value1, double value2) => Assert.Equal(result, MathHelper.IsEqual(value1, value2));
}