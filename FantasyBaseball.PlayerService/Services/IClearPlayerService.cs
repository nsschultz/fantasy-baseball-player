using System.Threading.Tasks;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for removing all of the players from the database.</summary>
    public interface IClearPlayerService
    {
        /// <summary>Removes all of the players from the database.</summary>
        Task ClearAllPlayers();
    }
}