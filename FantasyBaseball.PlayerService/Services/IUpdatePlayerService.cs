using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for updaing a player.</summary>
  public interface IUpdatePlayerService
  {
    /// <summary>Updates the given player.</summary>
    /// <param name="player">The player to update.</param>
    Task UpdatePlayer(BaseballPlayerV2 player);
  }
}