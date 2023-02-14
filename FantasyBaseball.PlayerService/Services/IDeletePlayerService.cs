using System;
using System.Threading.Tasks;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for deleting a player.</summary>
  public interface IDeletePlayerService
  {
    /// <summary>Deletes the given player from the data store.</summary>
    /// <param name="id">The guid of the player to delete.</param>
    Task DeletePlayer(Guid id);
  }
}