using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models;
using Xunit;

namespace FantasyBaseball.PlayerService.IntegrationTests
{
  public class PlayerIntegrationTests : IClassFixture<HttpClientFixture>
  {
    private HttpClientFixture _fixture;

    public PlayerIntegrationTests(HttpClientFixture fixture) => _fixture = fixture;

    [Theory]
    [InlineData("/api/v1/player/enum-map?enumType=LeagueStatus", 4)]
    [InlineData("/api/v1/player/enum-map?enumType=PlayerStatus", 4)]
    [InlineData("/api/v1/player/enum-map?enumType=PlayerType", 3)]
    [InlineData("/api/v1/player/enum-map?enumType=StatsType", 4)]
    [InlineData("/api/v2/enum-map?enumType=LeagueStatus", 4)]
    [InlineData("/api/v2/enum-map?enumType=PlayerStatus", 4)]
    [InlineData("/api/v2/enum-map?enumType=PlayerType", 3)]
    [InlineData("/api/v2/enum-map?enumType=StatsType", 4)]
    public async void GetEnumTest(string url, int count)
    {
      var repsonse = await _fixture.Client.GetAsync(url);
      Assert.Equal(HttpStatusCode.OK, repsonse.StatusCode);
      var values = await JsonSerializer.DeserializeAsync<Dictionary<int, string>>(
      await repsonse.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
      Assert.Equal(count, values.Count);
    }

    [Fact]
    public async void GetPlayersV1Test()
    {
      var players = await GetCountTest<BaseballPlayerV1>("/api/v1/player", 92);
      ValidatePlayerStats(players);
    }

    [Fact]
    public async void GetPlayersV2Test()
    {
      var players = await GetCountTest<BaseballPlayerV2>("/api/v2/player", 92);
      ValidatePlayerStats(players);
    }

    [Theory]
    [InlineData("/api/health")]
    [InlineData("/api/v1/action/export")]
    [InlineData("/api/v2/action/export")]
    [InlineData("/api/v2/swagger/index.html")]
    public async void GetSimpleTests(string url)
    {
      var httpResponse = await _fixture.Client.GetAsync(url);
      Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
    }

    [Fact] public async void GetTeams2Test() => await GetCountTest<BaseballTeam>("/api/v2/team", 31);

    private async Task<List<T>> GetCountTest<T>(string url, int count)
    {
      var repsonse = await _fixture.Client.GetAsync(url);
      Assert.Equal(HttpStatusCode.OK, repsonse.StatusCode);
      var values = await JsonSerializer.DeserializeAsync<List<T>>(
      await repsonse.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
      Assert.Equal(count, values.Count);
      return values;
    }

    private void ValidatePlayerStats<T>(List<T> players) where T : BaseballPlayer =>
      players.ForEach(p =>
      {
        Assert.Equal(3, p.BattingStats.Count);
        Assert.Equal(3, p.PitchingStats.Count);
      });
  }
}