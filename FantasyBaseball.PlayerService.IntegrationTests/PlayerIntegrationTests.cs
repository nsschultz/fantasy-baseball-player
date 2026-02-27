using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models;
using Xunit;

namespace FantasyBaseball.PlayerService.IntegrationTests;

public class PlayerIntegrationTests(HttpClientFixture fixture) : IClassFixture<HttpClientFixture>
{
  private readonly HttpClientFixture _fixture = fixture;
  private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };

  [Theory]
  [InlineData("/api/v3/enum-map?enumType=LeagueStatus", 4)]
  [InlineData("/api/v3/enum-map?enumType=PlayerStatus", 4)]
  [InlineData("/api/v3/enum-map?enumType=PlayerType", 3)]
  [InlineData("/api/v3/enum-map?enumType=StatsType", 4)]
  public async Task GetEnumTest(string url, int count)
  {
    var repsonse = await _fixture.Client.GetAsync(url);
    Assert.Equal(HttpStatusCode.OK, repsonse.StatusCode);
    var values = await JsonSerializer.DeserializeAsync<Dictionary<int, string>>(
    await repsonse.Content.ReadAsStreamAsync(), _options);
    Assert.Equal(count, values.Count);
  }

  [Theory]
  [InlineData("/api/v3/player")]
  public async Task GetPlayersTest(string url)
  {
    var players = await GetCountTest<BaseballPlayer>(url, 87);
    ValidatePlayerStats(players);
  }


  [Theory]
  [InlineData("/api/health")]
  [InlineData("/api/v3/action/export")]
  [InlineData("/api/swagger/index.html")]
  public async Task GetSimpleTests(string url)
  {
    var httpResponse = await _fixture.Client.GetAsync(url);
    Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
  }

  [Theory]
  [InlineData("/api/v3/team")]
  public async Task GetTeamsTest(string url) => await GetCountTest<BaseballTeam>(url, 31);

  private async Task<List<T>> GetCountTest<T>(string url, int count)
  {
    var repsonse = await _fixture.Client.GetAsync(url);
    Assert.Equal(HttpStatusCode.OK, repsonse.StatusCode);
    var values = await JsonSerializer.DeserializeAsync<List<T>>(
    await repsonse.Content.ReadAsStreamAsync(), _options);
    Assert.Equal(count, values.Count);
    return values;
  }

  private static void ValidatePlayerStats<T>(List<T> players) where T : BaseballPlayer =>
    players.ForEach(p =>
    {
      Assert.Equal(3, p.BattingStats.Count);
      Assert.Equal(3, p.PitchingStats.Count);
    });
}