using System.Collections.Generic;

namespace FantasyBaseball.PlayerService.Models
{
    /// <summary>Info for a given baseball team.</summary>
    public class BaseballTeam
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
    }
}