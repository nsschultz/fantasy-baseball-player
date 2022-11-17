using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V2
{
    /// <summary>Endpoint for retrieving player data.</summary>
    [Route("api/v2/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IClearPlayerService _clearPlayerService;
        private readonly IGetPlayersService _getService;
        private readonly IPlayerUpdateService _updateService;
        private readonly IUpsertPlayersService _upsertService;

        /// <summary>Creates a new instance of the controller.</summary>
        /// <param name="clearPlayerService">Service for removing all of the players from the database.</param>
        /// <param name="getService">Service for getting players.</param>
        /// <param name="updateService">Service for updating a player.</param>
        /// <param name="upsertService">Service for upserting players.</param>
        public PlayerController(IClearPlayerService clearPlayerService,
                                IGetPlayersService getService,
                                IPlayerUpdateService updateService,
                                IUpsertPlayersService upsertService) =>
            (_clearPlayerService, _getService, _updateService, _upsertService) = (clearPlayerService, getService, updateService, upsertService);

        /// <summary>Removes all of the players from the source.</summary>
        [HttpDelete] public async Task DeleteAllPlayers() => await _clearPlayerService.ClearAllPlayers();

        /// <summary>Gets all of the players from the source.</summary>
        /// <returns>All of the players from the source.</returns>
        [HttpGet]
        public async Task<List<BaseballPlayer>> GetPlayers() => await _getService.GetPlayers();

        /// <summary>Gets all of the players from the source.</summary>
        /// <param name="id">The id of the player to change.</param>
        /// <param name="player">The object containing all of the player's data (non-changed data must be included as well).</param>
        [HttpPut("{id}")]
        public async Task UpdatePlayer([FromRoute] Guid id, [FromBody] BaseballPlayer player)
        {
            if (player == null) throw new BadRequestException("Player not set");
            if (id == default) throw new BadRequestException("Invalid player id used");
            if (id != player.Id) throw new BadRequestException("The ids must match");
            await _updateService.UpdatePlayer(player);
        }

        /// <summary>Upserts all of the players into the source.</summary>
        /// <param name="players">All of the players to upsert into the source.</param>
        [HttpPost]
        public async Task UpsertPlayers([FromBody] List<BaseballPlayer> players)
        {
            if (players == null) throw new BadRequestException("Players not set");
            await _upsertService.UpsertPlayers(players);
        }
    }
}