using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.PlayerService.Services;
using Xunit;

namespace FantasyBaseball.PlayerService.UnitTests.Services;

public class GetPlayerEnumMapServiceTest
{
    private static readonly Dictionary<string, Dictionary<int, string>> VALUES = new()
    {
        { "LEAGUESTATUS", new() { { 0, "Available" }, { 1, "Rostered" }, { 2, "Unavailable" }, { 3, "Scouted" } } },
        { "PLAYERSTATUS", new() { { 0, "" }, { 1, "Injured List" }, { 2, "Not Available" }, { 3, "New Entry" } } },
        { "PLAYERTYPE", new() { { 0, "Unknown" }, { 1, "Batter" }, { 2, "Pitcher" } } },
        { "STATSTYPE", new() { { 0, "Unknown" }, { 1, "Year to Date" }, { 2, "Projected" }, { 3, "Combined" } } },
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

    [Fact]
    public void GetPlayerEnumMapLeagueStatusReturnsValidDictionary()
    {
        var service = new GetPlayerEnumMapService();
        var result = service.GetPlayerEnumMap("LeagueStatus");

        Assert.NotNull(result);
        Assert.Equal(VALUES["LEAGUESTATUS"], result);
        Assert.Equal(4, result.Count);
        Assert.Contains((int)LeagueStatus.A, result.Keys);
        Assert.Contains((int)LeagueStatus.R, result.Keys);
        Assert.Contains((int)LeagueStatus.S, result.Keys);
    }

    [Fact]
    public void GetPlayerEnumMapPlayerStatusReturnsValidDictionary()
    {
        var service = new GetPlayerEnumMapService();
        var result = service.GetPlayerEnumMap("PlayerStatus");

        Assert.NotNull(result);
        Assert.Equal(VALUES["PLAYERSTATUS"], result);
        Assert.Equal(4, result.Count);
        Assert.Contains((int)PlayerStatus.IL, result.Keys);
        Assert.Contains((int)PlayerStatus.NA, result.Keys);
        Assert.Contains((int)PlayerStatus.NE, result.Keys);
        Assert.Contains((int)PlayerStatus.XX, result.Keys);
    }

    [Fact]
    public void GetPlayerEnumMapPlayerTypeReturnsValidDictionary()
    {
        var service = new GetPlayerEnumMapService();
        var result = service.GetPlayerEnumMap("PlayerType");

        Assert.NotNull(result);
        Assert.Equal(VALUES["PLAYERTYPE"], result);
        Assert.Equal(3, result.Count);
        Assert.Contains((int)PlayerType.B, result.Keys);
        Assert.Contains((int)PlayerType.P, result.Keys);
    }

    [Fact]
    public void GetPlayerEnumMapStatsTypeReturnsValidDictionary()
    {
        var service = new GetPlayerEnumMapService();
        var result = service.GetPlayerEnumMap("StatsType");

        Assert.NotNull(result);
        Assert.Equal(VALUES["STATSTYPE"], result);
        Assert.Equal(4, result.Count);
        Assert.Contains((int)StatsType.YTD, result.Keys);
        Assert.Contains((int)StatsType.PROJ, result.Keys);
        Assert.Contains((int)StatsType.CMBD, result.Keys);
    }

    [Fact]
    public void GetPlayerEnumMapWithInvalidEnumTypeReturnsEmptyDictionary()
    {
        var service = new GetPlayerEnumMapService();
        var result = service.GetPlayerEnumMap("InvalidEnum");

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void GetPlayerEnumMapWithEmptyStringReturnsEmptyDictionary()
    {
        var service = new GetPlayerEnumMapService();
        var result = service.GetPlayerEnumMap("");

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void GetPlayerEnumMapWithNullReturnsEmptyDictionary()
    {
        var service = new GetPlayerEnumMapService();
        var result = service.GetPlayerEnumMap(null);

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void GetPlayerEnumMapIsCaseInsensitive()
    {
        var service = new GetPlayerEnumMapService();
        var lowerCase = service.GetPlayerEnumMap("leaguestatus");
        var upperCase = service.GetPlayerEnumMap("LEAGUESTATUS");
        var mixedCase = service.GetPlayerEnumMap("LeagueStatus");

        Assert.Equal(lowerCase, upperCase);
        Assert.Equal(lowerCase, mixedCase);
        Assert.Equal(VALUES["LEAGUESTATUS"], lowerCase);
    }

    [Fact]
    public void GetPlayerEnumMapReturnsConsistentResults()
    {
        var service = new GetPlayerEnumMapService();
        var result1 = service.GetPlayerEnumMap("PlayerType");
        var result2 = service.GetPlayerEnumMap("PlayerType");

        Assert.Equal(result1, result2);
    }

    [Theory]
    [InlineData("LEAGUESTATUS")]
    [InlineData("PLAYERSTATUS")]
    [InlineData("PLAYERTYPE")]
    [InlineData("STATSTYPE")]
    public void GetPlayerEnumMapReturnsNonEmptyDictionaryForValidEnums(string enumType)
    {
        var service = new GetPlayerEnumMapService();
        var result = service.GetPlayerEnumMap(enumType);

        Assert.NotEmpty(result);
        Assert.True(result.Values.Any(v => !string.IsNullOrEmpty(v)), "Enum should contain non-empty descriptions");
    }
}