using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V3;

/// <summary>Endpoint for retrieving team data.</summary>
[Route("api/v3/team")]
[ApiController]
public class PlayerTeamController(IMapper mapper, IGetTeamsService getTeamsService) : ControllerBase
{
  /// <summary>Returns the given enum as a dictionary of the value and description.</summary>
  /// <returns>A dictionary of the values and descriptions for the given enum.</returns>
  [HttpGet]
  public async Task<List<BaseballTeam>> GetTeams()
  {
    var teams = await getTeamsService.GetTeams();
    return [.. teams.Select(mapper.Map<BaseballTeam>)];
  }
}