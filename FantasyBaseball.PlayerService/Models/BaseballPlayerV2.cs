using System.Collections.Generic;

namespace FantasyBaseball.PlayerService.Models
{
    /// <summary>All of the information that makes up a baseball player.</summary>
    public class BaseballPlayerV2 : BaseballPlayer
    {
        /// <summary>The player's team.</summary>
        public BaseballTeam Team { get; set; }

        /// <summary>The position(s) this player plays.</summary>
        public List<BaseballPosition> Positions { get; set; } = new List<BaseballPosition>();
    }
}