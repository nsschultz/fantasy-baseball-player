using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services;

/// <summary>Service for adding a player.</summary>
public interface IAddPlayerService
{
  /// <summary>Adds the given player.</summary>
  /// <param name="player">The player to add.</param>
  /// <returns>The id of the newly created object.</returns>
  public Task<Guid> AddPlayer(BaseballPlayer player);
}