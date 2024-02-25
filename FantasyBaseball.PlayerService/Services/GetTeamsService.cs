using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using LazyCache;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for getting teams.</summary>
  public class GetTeamsService : IGetTeamsService
  {
    private readonly IAppCache _cache;
    private readonly ITeamRepository _teamRepo;

    /// <summary>Creates a new instance of the service.</summary>
    /// <param name="cache">The in-memory cache for storing short-term items.</param>
    /// <param name="teamRepo">Repo for CRUD functionality regarding to teams.</param>
    public GetTeamsService(IAppCache cache, ITeamRepository teamRepo) => (_cache, _teamRepo) = (cache, teamRepo);

    /// <summary>Gets the teams from the underlying source.</summary>
    /// <returns>A list of the teams.</returns>
    public async Task<List<TeamEntity>> GetTeams() => await _cache.GetOrAddAsync("teams", () => _teamRepo.GetAllTeams());
  }
}