using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V3
{
  /// <summary>Endpoint for deleting player data.</summary>
  /// <remarks>Creates a new instance of the controller.</remarks>
  /// <param name="deleteService">Service for deleting a player.</param>
  [Route("api/v2/player")]
  [Route("api/v3/player")]
  [ApiController]
  public class PlayerDeleteController(IDeletePlayerService deleteService) : ControllerBase
  {
    private readonly IDeletePlayerService _deleteService = deleteService;
    private readonly IPlayerRepository _playerRepo;

    /// <summary>Deletes the given player.</summary>
    /// <param name="id">The id of the player to change.</param>
    [HttpDelete("{id}")] public async Task DeletePlayer([FromRoute] Guid id) => await _deleteService.DeletePlayer(id);

    /// <summary>Removes all of the players from the source.</summary>
    [HttpDelete] public async Task DeleteAllPlayers() => await _deleteService.DeleteAllPlayers();
  }
}