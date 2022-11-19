using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Database.Repositories
{
    /// <summary>Repo for CRUD functionality regarding to players.</summary>
    public interface IPlayerRepository
    {
        /// <summary>Removes all of the players from the database.</summary>
        Task DeleteAllPlayers();

        /// <summary>Finds a player matching the given values (which must be a uniqure combo in the db) or null if there is no match.</summary>
        /// <param name="bhqId">The id from the external system.</param>
        /// <param name="type">The type of the player (which makes the BHQ Id combo unique).</param>
        /// <returns>The player matching the given values.</returns>
        Task<PlayerEntity> GetPlayerByBhqId(int bhqId, PlayerType type);

        /// <summary>Finds a player matching the given id or null if there is no match.</summary>
        /// <param name="id">The guid of the player to find.</param>
        /// <returns>The player matching the given id.</returns>
        Task<PlayerEntity> GetPlayerById(Guid id);

        /// <summary>Gets a list of player entities from the database.</summary>
        /// <param name="type">The type of player to return or all if this value is null.</param>
        /// <returns>A list of the players.</returns>
        Task<List<PlayerEntity>> GetPlayers(PlayerType? type = null);

        /// <summary>Updates the given player.</summary>
        /// <param name="player">The player data.</param>
        Task UpdatePlayer(PlayerEntity player);

        /// <summary>Takes a collection of players and updates or adds them to the database.</summary>
        /// <param name="entities">The collection of players.</param>
        Task UpsertPlayers(IEnumerable<PlayerEntity> entities);
    }
}