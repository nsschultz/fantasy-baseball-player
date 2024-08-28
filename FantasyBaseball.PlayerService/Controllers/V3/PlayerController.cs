using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V3
{
  /// <summary>Endpoint for retrieving player data.</summary>
  [Route("api/v2/player")]
  [Route("api/v3/player")]
  [ApiController]
  public class PlayerController : ControllerBase
  {
    private readonly IAddPlayerService _addService;
    private readonly IDeletePlayerService _deleteService;
    private readonly IGetPlayerService _getService;
    private readonly IPlayerRepository _playerRepo;
    private readonly IUpdatePlayerService _updateService;

    /// <summary>Creates a new instance of the controller.</summary>
    /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
    /// <param name="addService">Service for adding a player.</param>
    /// <param name="deleteService">Service for deleting a player.</param>
    /// <param name="getService">Service for getting players.</param>
    /// <param name="updateService">Service for updating a player.</param>
    public PlayerController(IPlayerRepository playerRepo,
                            IAddPlayerService addService,
                            IDeletePlayerService deleteService,
                            IGetPlayerService getService,
                            IUpdatePlayerService updateService) =>
      (_playerRepo, _addService, _deleteService, _getService, _updateService) = (playerRepo, addService, deleteService, getService, updateService);

    /// <summary>Adds the given player.</summary>
    /// <param name="player">The object containing all of the player's data (non-changed data must be included as well).</param>
    /// <returns>The id of the newly created object.</returns>
    [HttpPost]
    public async Task<Guid> AddPlayer([FromBody] BaseballPlayer player)
    {
      if (player == null) throw new BadRequestException("Player not set");
      if (player.Id != Guid.Empty) throw new BadRequestException("The id should not be set");
      return await _addService.AddPlayer(player);
    }

    /// <summary>Deletes the given player.</summary>
    /// <param name="id">The id of the player to change.</param>
    [HttpDelete("{id}")] public async Task DeletePlayer([FromRoute] Guid id) => await _deleteService.DeletePlayer(id);

    /// <summary>Removes all of the players from the source.</summary>
    [HttpDelete] public async Task DeleteAllPlayers() => await _playerRepo.DeleteAllPlayers();

    /// <summary>Gets the given player.</summary>
    /// <param name="id">The id of the player to retrieve.</param>
    /// <returns>The player matching the given id.</returns>
    [HttpGet("{id}")] public async Task<BaseballPlayer> GetPlayer([FromRoute] Guid id) => await _getService.GetPlayer(id);

    /// <summary>Gets all of the players from the source.</summary>
    /// <returns>All of the players from the source.</returns>
    [HttpGet] public async Task<List<BaseballPlayer>> GetPlayers() => await _getService.GetPlayers();

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