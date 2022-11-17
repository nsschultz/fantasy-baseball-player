using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Models;
using Xunit;

namespace FantasyBaseball.PlayerService.IntegrationTests
{
    public class PlayerDatabaseIntegrationTests : IClassFixture<HttpClientFixture>
    {
        private HttpClientFixture _fixture;

        public PlayerDatabaseIntegrationTests(HttpClientFixture fixture) => _fixture = fixture;

        [Fact] public async void GetPlayersV1Test() => await GetCountTest<BaseballPlayerV1>("/api/v1/player", 92);

        [Fact] public async void GetPlayersV2Test() => await GetCountTest<BaseballPlayer>("/api/v2/player", 92);

        [Theory]
        [InlineData("/api/health")]
        [InlineData("/api/v1/action/export")]
        [InlineData("/api/v2/action/export")]
        [InlineData("/api/v1/player/enum-map?enumType=LeagueStatus")]
        [InlineData("/api/v2/player/enum-map?enumType=LeagueStatus")]
        [InlineData("/api/v2/player/swagger/index.html")]
        public async void GetSimpleTests(string url)
        {
            var httpResponse = await _fixture.Client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact] public async void GetTeams2Test() => await GetCountTest<BaseballTeam>("/api/v2/player/team", 31);

        private async Task GetCountTest<T>(string url, int count)
        {
            var repsonse = await _fixture.Client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, repsonse.StatusCode);
            var values = await JsonSerializer.DeserializeAsync<List<T>>(
                await repsonse.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Assert.Equal(count, values.Count);
        }
    }
}