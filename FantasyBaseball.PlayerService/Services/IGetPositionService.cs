using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for getting positions.</summary>
    public interface IGetPositionService
    {
        /// <summary>Gets the positions from the underlying source.</summary>
        /// <returns>A list of the positions.</returns>
        Task<List<BaseballPosition>> GetPositions();
    }
}