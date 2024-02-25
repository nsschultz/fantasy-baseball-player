using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
using LazyCache;
using Microsoft.Extensions.Configuration;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for getting positions.</summary>
  public class GetPositionService : IGetPositionService
  {
    private readonly IAppCache _cache;
    private readonly string _url;

    /// <summary>Creates a new instance of the service.</summary>
    /// <param name="configuration">The configuration for the application.</param>
    /// <param name="cache">The in-memory cache for storing short-term items.</param>
    public GetPositionService(IConfiguration configuration, IAppCache cache) =>
      (_cache, _url) = (cache, configuration.GetValue<string>("ServiceUrls:PositionEndpoint"));

    /// <summary>Gets the positions from the underlying source.</summary>
    /// <returns>A list of the positions.</returns>
    public async Task<List<BaseballPosition>> GetPositions() => await _cache.GetOrAddAsync("positions", () => RetrievePositions());

    private async Task<List<BaseballPosition>> RetrievePositions()
    {
      var response = await new HttpClient().GetAsync(_url);
      if (!response.IsSuccessStatusCode) throw new ServiceException($"Unable to get {_url}");
      return await JsonSerializer.DeserializeAsync<List<BaseballPosition>>(
        await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
  }
}