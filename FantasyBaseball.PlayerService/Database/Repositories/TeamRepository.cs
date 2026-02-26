using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyBaseball.PlayerService.Database.Repositories;

/// <summary>Repo for CRUD functionality regarding to teams.</summary>
/// <param name="context">The player context.</param>
public class TeamRepository(IPlayerContext context) : ITeamRepository
{
  /// <summary>Gets all of the teams in the database.</summary>
  /// <returns>All of the teams in the database.</returns>
  public async Task<List<TeamEntity>> GetAllTeams() => await context.Teams.ToListAsync();
}