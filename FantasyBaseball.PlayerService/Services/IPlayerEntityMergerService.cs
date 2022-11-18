using System.Threading.Tasks;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database.Entities;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for converting a BaseballPlayer to a PlayerEntity.</summary>
    public interface IPlayerEntityMergerService
    {
        /// <summary>Merges a BaseballPlayer into a PlayerEntity.</summary>
        /// <param name="incoming">The incoming player values.</param>
        /// <param name="existing">The existing player values.</param>
        /// <returns>An object that can be saved to the database.</returns>
        Task<PlayerEntity> MergePlayerEntity(BaseballPlayer incoming, PlayerEntity existing);
    }
}