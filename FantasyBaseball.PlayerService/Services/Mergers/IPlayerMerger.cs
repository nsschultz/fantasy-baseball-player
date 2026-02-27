using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services.Mergers;

/// <summary>Service for merging multiple types of player objects.</summary>
public interface IPlayerMerger
{
  /// <summary>Merges a BaseballPlayer into a PlayerEntity.</summary>
  /// <param name="mapper">Instance of the auto mapper.</param>
  /// <param name="incoming">The incoming player values.</param>
  /// <param name="existing">The existing player values.</param>
  /// <returns>An object that can be saved to the database.</returns>
  PlayerEntity MergePlayer(IMapper mapper, BaseballPlayer incoming, PlayerEntity existing);
}