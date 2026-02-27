using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V3;

/// <summary>Endpoint for adding a player's data.</summary>
/// <param name="addService">Service for adding a player.</param>
[Route("api/v3/player")]
[ApiController]
public class PlayerAddController(IAddPlayerService addService) : ControllerBase
{
  /// <summary>Adds the given player.</summary>
  /// <param name="player">The object containing all of the player's data (non-changed data must be included as well).</param>
  /// <returns>The id of the newly created object.</returns>
  [HttpPost]
  public async Task<Guid> AddPlayer([FromBody] BaseballPlayer player)
  {
    if (player == null) throw new BadRequestException("Player not set");
    if (player.Id != Guid.Empty) throw new BadRequestException("The id should not be set");
    return await addService.AddPlayer(player);
  }
}