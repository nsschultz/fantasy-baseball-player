using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services.Mergers;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for converting a BaseballPlayer to a PlayerEntity.</summary>
  public interface IMergePlayerService
  {
    /// <summary>Merges a BaseballPlayer into a PlayerEntity.</summary>
    /// <param name="merger">Function for merging</param>
    /// <param name="incoming">The incoming player values.</param>
    /// <param name="existing">The existing player values.</param>
    /// <returns>An object that can be saved to the database.</returns>
    Task<PlayerEntity> MergePlayer(IPlayerMerger merger, BaseballPlayer incoming, PlayerEntity existing);
  }
}