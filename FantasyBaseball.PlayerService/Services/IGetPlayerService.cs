using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for getting players.</summary>
  public interface IGetPlayerService
  {
    /// <summary>Gets the players from the underlying source.</summary>
    /// <param name="id">The guid of the player to return.</param>
    /// <returns>The player matching the given id.</returns>
    Task<BaseballPlayer> GetPlayer(Guid id);

    /// <summary>Gets the players from the underlying source.</summary>
    /// <returns>A list of the players.</returns>
    Task<List<BaseballPlayer>> GetPlayers();
  }
}