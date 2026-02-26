using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;

namespace FantasyBaseball.PlayerService.Services;

/// <summary>Service for getting teams.</summary>
public interface IGetTeamsService
{
  /// <summary>Gets the teams from the underlying source.</summary>
  /// <returns>A list of the teams.</returns>
  Task<List<TeamEntity>> GetTeams();
}