using System.Threading.Tasks;
using FantasyBaseball.Common.Models;

namespace FantasyBaseball.PlayerService.Services;

/// <summary>Service for updating a player.</summary>
public interface IUpdatePlayerService
{
  /// <summary>Updates the given player.</summary>
  /// <param name="player">The player to update.</param>
  Task UpdatePlayer(Player player);
}