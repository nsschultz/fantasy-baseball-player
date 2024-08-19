using CsvHelper;
using FantasyBaseball.PlayerService.Maps.Converters;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Maps.Converters
{
  public class AtBatsConverterTest
  {
    [Theory]
    [InlineData(0, "0", "10", "5", "0")]
    [InlineData(15, "20", "0", "5", "0")]
    [InlineData(5, "20", "5", "5", "0")]
    [InlineData(7, "10", "3", "3", "0.429")]
    public void ConvertFromStringTest(int expected, string pa, string h, string bb, string avg)
    {
      var row = new Mock<IReaderRow>();
      row.Setup(o => o.GetField("H")).Returns(h);
      row.Setup(o => o.GetField("BB")).Returns(bb);
      row.Setup(o => o.GetField("AVG")).Returns(avg);
      Assert.Equal(expected, new AtBatsConverter().ConvertFromString(pa, row.Object, null));
    }

    [Theory]
    [InlineData(3, "3")]
    [InlineData(0, "0")]
    [InlineData(-5, "-5")]
    public void ConvertToStringTest(int input, string expected) =>
      Assert.Equal(expected, new AtBatsConverter().ConvertToString(input, null, null));
  }
}
