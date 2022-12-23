using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V2
{
  /// <summary>Endpoint for retrieving team data.</summary>
  [Route("api/v2/team")]
  [ApiController]
  public class PlayerTeamController : ControllerBase
  {
    private readonly IGetTeamsService _getTeamsService;
    private readonly IMapper _mapper;

    /// <summary>Creates a new instance of the controller.</summary>
    /// <param name="mapper">Instance of the auto mapper.</param>
    /// <param name="getTeamsService">Service for getting teams.</param>
    public PlayerTeamController(IMapper mapper, IGetTeamsService getTeamsService) => (_mapper, _getTeamsService) = (mapper, getTeamsService);

    /// <summary>Returns the given enum as a dictionary of the value and description.</summary>
    /// <returns>A dictionary of the values and descriptions for the given enum.</returns>
    [HttpGet]
    public async Task<List<BaseballTeam>> GetTeams()
    {
      var teams = await _getTeamsService.GetTeams();
      return teams.Select(team => _mapper.Map<BaseballTeam>(team)).ToList();
    }
  }
}