using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V3
{
  /// <summary>Endpoint for updating a player's data.</summary>
  /// <remarks>Creates a new instance of the controller.</remarks>
  /// <param name="updateService">Service for updating a player.</param>
  [Route("api/v3/player")]
  [ApiController]
  public class PlayerUpdateController(IUpdatePlayerService updateService) : ControllerBase
  {
    private readonly IUpdatePlayerService _updateService = updateService;

    /// <summary>Updates the given player.</summary>
    /// <param name="id">The id of the player to change.</param>
    /// <param name="player">The object containing all of the player's data (non-changed data must be included as well).</param>
    [HttpPut("{id}")]
    public async Task UpdatePlayer([FromRoute] Guid id, [FromBody] BaseballPlayer player)
    {
      if (player == null) throw new BadRequestException("Player not set");
      if (id == Guid.Empty) throw new BadRequestException("Invalid player id used");
      if (id != player.Id) throw new BadRequestException("The ids must match");
      await _updateService.UpdatePlayer(player);
    }
  }
}