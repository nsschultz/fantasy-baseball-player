using System;
using System.Threading.Tasks;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for deleting a player.</summary>
  public interface IDeletePlayerService
  {
    /// <summary>Removes all of the players from the source.</summary>
    Task DeleteAllPlayers();

    /// <summary>Deletes the given player from the data store.</summary>
    /// <param name="id">The guid of the player to delete.</param>
    Task DeletePlayer(Guid id);
  }
}