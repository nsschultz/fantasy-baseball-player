using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V3
{
  /// <summary>Endpoint for retrieving player data.</summary>
  /// <remarks>Creates a new instance of the controller.</remarks>
  /// <param name="getService">Service for getting players.</param>
  [Route("api/v2/player")]
  [Route("api/v3/player")]
  [ApiController]
  public class PlayerGetController(IGetPlayerService getService) : ControllerBase
  {
    private readonly IGetPlayerService _getService = getService;

    /// <summary>Gets the given player.</summary>
    /// <param name="id">The id of the player to retrieve.</param>
    /// <returns>The player matching the given id.</returns>
    [HttpGet("{id}")] public async Task<BaseballPlayer> GetPlayer([FromRoute] Guid id) => await _getService.GetPlayer(id);

    /// <summary>Gets all of the players from the source.</summary>
    /// <returns>All of the players from the source.</returns>
    [HttpGet] public async Task<List<BaseballPlayer>> GetPlayers() => await _getService.GetPlayers();
  }
}