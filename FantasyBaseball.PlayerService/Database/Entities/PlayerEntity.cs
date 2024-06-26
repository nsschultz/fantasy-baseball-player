using System;
using System.Collections.Generic;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Database.Entities
{
  /// <summary>Entity for saving/retrieving a Player.</summary>
  public class PlayerEntity
  {
    /// <summary>The player's age.</summary>
    public int Age { get; set; }

    /// <summary>The average draft position (ADP) for this player.</summary>
    public double AverageDraftPick { get; set; }

    /// <summary>The latest pick used on this player.</summary>
    public int AverageDraftPickMax { get; set; }

    /// <summary>The earliest pick used on this player.</summary>
    public int AverageDraftPickMin { get; set; }

    /// <summary>The player's first name.</summary>
    public string FirstName { get; set; }

    /// <summary>The player's ID.</summary>
    public Guid Id { get; set; }

    /// <summary>The player's last name.</summary>
    public string LastName { get; set; }

    /// <summary>The player's Mayberry Method score.</summary>
    public int MayberryMethod { get; set; }

    /// <summary>The player's MLB BAM ID.</summary>
    public int MlbAmId { get; set; }

    /// <summary>The player's projected reliability.</summary>
    public double Reliability { get; set; }

    /// <summary>The player's status.</summary>
    public PlayerStatus Status { get; set; }

    /// <summary>The player's team.</summary>
    public string Team { get; set; }

    /// <summary>The player's type (B for Batter or P for Pitcher).</summary>
    public PlayerType Type { get; set; }

    /// <summary>Collection of Batting Stats for a given player.</summary>
    public List<BattingStatsEntity> BattingStats { get; set; } = [];

    /// <summary>League statuses for a given Player.</summary>
    public List<PlayerLeagueStatusEntity> LeagueStatuses { get; set; } = [];

    /// <summary>Collection of Pitching Stats for a given player.</summary>
    public List<PitchingStatsEntity> PitchingStats { get; set; } = [];

    /// <summary>The team that the player is a part of.</summary>
    public TeamEntity PlayerTeam { get; set; }

    /// <summary>Collection of positions that this player plays.</summary>
    public List<PlayerPositionEntity> Positions { get; set; } = [];
  }
}