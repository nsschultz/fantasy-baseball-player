using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;

namespace FantasyBaseball.PlayerService.Database.Repositories
{
    /// <summary>Repo for CRUD functionality regarding to teams.</summary>
    public interface ITeamRepository
    {
        /// <summary>Gets all of the teams in the database.</summary>
        /// <returns>All of the teams in the database.</returns>
        Task<List<TeamEntity>> GetAllTeams();
    }
}