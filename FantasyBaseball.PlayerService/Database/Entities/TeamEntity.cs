using System.Collections.Generic;

namespace FantasyBaseball.PlayerService.Database.Entities
{
    /// <summary>Info for a given team.</summary>
    public class TeamEntity
    {
        /// <summary>The team's main code.</summary>
        public string Code { get; set; }

        /// <summary>The team's alternative code.</summary>
        public string AlternativeCode { get; set; }

        /// <summary>The league a team belongs to.</summary>
        public string LeagueId { get; set; }

        /// <summary>The team's city.</summary>
        public string City { get; set; }

        /// <summary>The team's nickname.</summary>
        public string Nickname { get; set; }

        /// <summary>Collection of player's that belong to this team.</summary>
        public List<PlayerEntity> Players { get; set; } = new List<PlayerEntity>();
    }
}