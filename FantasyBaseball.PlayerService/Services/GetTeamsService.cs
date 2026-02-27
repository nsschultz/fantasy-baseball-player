using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using LazyCache;

namespace FantasyBaseball.PlayerService.Services;

/// <summary>Service for getting teams.</summary>
/// <param name="cache">The in-memory cache for storing short-term items.</param>
/// <param name="teamRepo">Repo for CRUD functionality regarding to teams.</param>
public class GetTeamsService(IAppCache cache, ITeamRepository teamRepo) : IGetTeamsService
{
  /// <summary>Gets the teams from the underlying source.</summary>
  /// <returns>A list of the teams.</returns>
  public async Task<List<TeamEntity>> GetTeams() => await cache.GetOrAddAsync("teams", teamRepo.GetAllTeams);
}