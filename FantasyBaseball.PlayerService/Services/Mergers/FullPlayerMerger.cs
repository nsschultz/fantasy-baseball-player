using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services.Mergers
{
  /// <summary>Service for taking all of the incoming fields and applying to them to the existing entity.</summary>
  public class FullPlayerMerger : IPlayerMerger
  {
    /// <summary>Merges a BaseballPlayer into a PlayerEntity.</summary>
    /// <param name="mapper">Instance of the auto mapper.</param>
    /// <param name="incoming">The incoming player values.</param>
    /// <param name="existing">The existing player values.</param>
    /// <returns>An object that can be saved to the database.</returns>
    public PlayerEntity MergePlayer(IMapper mapper, BaseballPlayerV2 incoming, PlayerEntity existing) =>
      incoming != null ? mapper.Map(incoming, existing) : existing;
  }
}