using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
using LazyCache;
using Microsoft.Extensions.Configuration;

namespace FantasyBaseball.PlayerService.Services;

/// <summary>Service for getting positions.</summary>
/// <param name="configuration">The configuration for the application.</param>
/// <param name="cache">The in-memory cache for storing short-term items.</param>
public class GetPositionService(IConfiguration configuration, IAppCache cache) : IGetPositionService
{
  private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };

  /// <summary>Gets the positions from the underlying source.</summary>
  /// <returns>A list of the positions.</returns>
  public async Task<List<BaseballPosition>> GetPositions() => await cache.GetOrAddAsync("positions", () => RetrievePositions());

  private async Task<List<BaseballPosition>> RetrievePositions()
  {
    var url = configuration.GetValue<string>("ServiceUrls:PositionEndpoint");
    var response = await new HttpClient().GetAsync(url);
    if (!response.IsSuccessStatusCode) throw new ServiceException($"Unable to get {url}");
    return await JsonSerializer.DeserializeAsync<List<BaseballPosition>>(await response.Content.ReadAsStreamAsync(), _options);
  }
}