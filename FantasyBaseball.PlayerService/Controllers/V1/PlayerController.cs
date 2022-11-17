using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
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
        private readonly IClearPlayerService _clearPlayerService;
        private readonly IGetPlayersService _getService;
        private readonly IMapper _mapper;
        private readonly IPlayerUpdateService _updateService;
        private readonly IUpsertPlayersService _upsertService;

        /// <summary>Creates a new instance of the controller.</summary>
        /// <param name="mapper">Instance of the auto mapper.</param>
        /// <param name="clearPlayerService">Service for removing all of the players from the database.</param>
        /// <param name="getService">Service for getting players.</param>
        /// <param name="updateService">Service for updating a player.</param>
        /// <param name="upsertService">Service for upserting players.</param>
        public PlayerController(IMapper mapper,
                                IClearPlayerService clearPlayerService,
                                IGetPlayersService getService,
                                IPlayerUpdateService updateService,
                                IUpsertPlayersService upsertService)
        {
            _mapper = mapper;
            _clearPlayerService = clearPlayerService;
            _getService = getService;
            _updateService = updateService;
            _upsertService = upsertService;
        }

        /// <summary>Removes all of the players from the source.</summary>
        [HttpDelete] public async Task DeleteAllPlayers() => await _clearPlayerService.ClearAllPlayers();

        /// <summary>Gets all of the players from the source.</summary>
        /// <returns>All of the players from the source.</returns>
        [HttpGet]
        public async Task<List<BaseballPlayerV1>> GetPlayers() =>
            (await _getService.GetPlayers()).Select(p => _mapper.Map<BaseballPlayerV1>(p)).ToList();


        /// <summary>Gets all of the players from the source.</summary>
        /// <param name="id">The id of the player to change.</param>
        /// <param name="player">The object containing all of the player's data (non-changed data must be included as well).</param>
        [HttpPut("{id}")]
        public async Task UpdatePlayer([FromRoute] Guid id, [FromBody] BaseballPlayerV1 player)
        {
            if (player == null) throw new BadRequestException("Player not set");
            if (id == default) throw new BadRequestException("Invalid player id used");
            if (id != player.Id) throw new BadRequestException("The ids must match");
            var convertedPlayer = _mapper.Map<BaseballPlayer>(player);
            await _updateService.UpdatePlayer(convertedPlayer);
        }

        /// <summary>Upserts all of the players into the source.</summary>
        /// <param name="players">All of the players to upsert into the source.</param>
        [HttpPost]
        public async Task UpsertPlayers([FromBody] List<BaseballPlayerV1> players)
        {
            if (players == null) throw new BadRequestException("Players not set");
            var convertedPlayers = players.Select(p => _mapper.Map<BaseballPlayer>(p)).ToList();
            await _upsertService.UpsertPlayers(convertedPlayers);
        }
    }
}