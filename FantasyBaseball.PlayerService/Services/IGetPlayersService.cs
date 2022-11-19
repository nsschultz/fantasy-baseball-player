using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for getting players.</summary>
    public interface IGetPlayersService
    {
        /// <summary>Gets the players from the underlying source.</summary>
        /// <returns>A list of the players.</returns>
        Task<List<BaseballPlayerV2>> GetPlayers();
    }
}