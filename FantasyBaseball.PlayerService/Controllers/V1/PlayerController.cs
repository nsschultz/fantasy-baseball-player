using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerService.Controllers.V1
{
    /// <summary>Endpoint for retrieving player data.</summary>
    [Route("api/v1/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IGetPlayersService _getService;
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepo;
        private readonly IUpdatePlayerService _updateService;

        /// <summary>Creates a new instance of the controller.</summary>
        /// <param name="mapper">Instance of the auto mapper.</param>
        /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
        /// <param name="getService">Service for getting players.</param>
        /// <param name="updateService">Service for updating a player.</param>
        public PlayerController(IMapper mapper, IPlayerRepository playerRepo, IGetPlayersService getService, IUpdatePlayerService updateService) =>
            (_mapper, _playerRepo, _getService, _updateService) = (mapper, playerRepo, getService, updateService);

        /// <summary>Removes all of the players from the source.</summary>
        [HttpDelete] public async Task DeleteAllPlayers() => await _playerRepo.DeleteAllPlayers();

        /// <summary>Gets all of the players from the source.</summary>
        /// <returns>All of the players from the source.</returns>
        [HttpGet]
        public async Task<List<BaseballPlayerV1>> GetPlayers() =>
            (await _getService.GetPlayers()).Select(p => _mapper.Map<BaseballPlayerV1>(p)).ToList();

        /// <summary>Deprecated.</summary>
        [HttpPost]
        [HttpPost("api/v1/action/merge")]
        public void MergePlayers() => throw new BadRequestException("This method is deprecated. "
            + "Use api/v2/action/upload/projections/batter or api/v2/action/upload/projections/pitcher instead.");

        /// <summary>Gets all of the players from the source.</summary>
        /// <param name="id">The id of the player to change.</param>
        /// <param name="player">The object containing all of the player's data (non-changed data must be included as well).</param>
        [HttpPut("{id}")]
        public async Task UpdatePlayer([FromRoute] Guid id, [FromBody] BaseballPlayerV1 player)
        {
            if (player == null) throw new BadRequestException("Player not set");
            if (id == default) throw new BadRequestException("Invalid player id used");
            if (id != player.Id) throw new BadRequestException("The ids must match");
            var convertedPlayer = _mapper.Map<BaseballPlayerV2>(player);
            await _updateService.UpdatePlayer(convertedPlayer);
        }
    }
}