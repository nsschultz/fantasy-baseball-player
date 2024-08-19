using System.Collections.Generic;
using FantasyBaseball.PlayerService.Services;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Services
{
  public class GetPlayerEnumMapServiceTest
  {
    private static readonly Dictionary<string, Dictionary<int, string>> VALUES = new Dictionary<string, Dictionary<int, string>>()
    {
      { "LEAGUESTATUS", new Dictionary<int, string>() { { 0, "Available" }, { 1, "Rostered" }, { 2, "Unavailable" }, { 3, "Scouted" } } },
      { "PLAYERSTATUS", new Dictionary<int, string>() { { 0, "" }, { 1, "Injured List" }, { 2, "Not Available" }, { 3, "New Entry" } } },
      { "PLAYERTYPE", new Dictionary<int, string>() { { 0, "Unknown" }, { 1, "Batter" }, { 2, "Pitcher" } } },
      { "STATSTYPE", new Dictionary<int, string>() { { 0, "Unknown" }, { 1, "Year to Date" }, { 2, "Projected" }, { 3, "Combined" } } },
    };

    [Theory]
    [InlineData("LeagueStatus")]
    [InlineData("PLAYERSTATUS")]
    [InlineData("PlayerType")]
    [InlineData("statstype")]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData(null)]
    public void GetPlayerEnumMapTest(string enumType)
    {
      var key = enumType?.ToUpper();
      var expectedValue = key != null && VALUES.TryGetValue(key, out Dictionary<int, string> value) ? value : [];
      Assert.Equal(expectedValue, new GetPlayerEnumMapService().GetPlayerEnumMap(enumType));
    }
  }
}