using System;
using System.Collections.Generic;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Models
{
  /// <summary>All of the information that makes up a baseball player.</summary>
  public class BaseballPlayer
  {
    /// <summary>Max value for draft pick attributes.</summary>
    private const int MaxDraftPick = 9999;

    /// <summary>The player's ID.</summary>
    public Guid Id { get; set; }

    /// <summary>The player's MLB BAM ID.</summary>
    public int MlbAmId { get; set; }

    /// <summary>The player's BHQ ID.</summary>
    public int BhqId { get; set; }

    /// <summary>The player's type (B for Batter or P for Pitcher).</summary>
    public PlayerType Type { get; set; }

    /// <summary>The player's first name.</summary>
    public string FirstName { get; set; }

    /// <summary>The player's last name.</summary>
    public string LastName { get; set; }

    /// <summary>The player's age.</summary>
    public int Age { get; set; }

    /// <summary>The player's status.</summary>
    public PlayerStatus Status { get; set; }

    /// <summary>The rank of this player in the draft.</summary>
    [Obsolete("Use AvererageDraftPickMin instead.")] public int DraftRank { get; set; } = MaxDraftPick;

    /// <summary>The average draft position (ADP) for this player.</summary>
    public double AverageDraftPick { get; set; } = MaxDraftPick;

    /// <summary>The earliest pick used on this player.</summary>
    public int AverageDraftPickMin { get; set; } = MaxDraftPick;

    /// <summary>The latest pick used on this player.</summary>
    public int AverageDraftPickMax { get; set; } = MaxDraftPick;

    /// <summary>The highest pick that was used on this player.</summary>
    [Obsolete("Use AvererageDraftPickMin instead.")] public int HighestPick { get; set; } = MaxDraftPick;

    /// <summary>The percentage of time that this player was drafted.</summary>
    [Obsolete("Not being used anymore.")] public double DraftedPercentage { get; set; }

    /// <summary>The player's projected reliability.</summary>
    public double Reliability { get; set; }

    /// <summary>The player's Mayberry Method score.</summary>
    public int MayberryMethod { get; set; }

    /// <summary>The player's status for League #1.</summary>
    public LeagueStatus League1 { get; set; }

    /// <summary>The player's status for League #2.</summary>
    public LeagueStatus League2 { get; set; }

    /// <summary>Batting Stats (Year to Date, Projected and Combined) for a given player.</summary>
    public List<BattingStats> BattingStats { get; set; } = [];

    /// <summary>Pitching Stats (Year to Date, Projected and Combined) for a given player.</summary>
    public List<PitchingStats> PitchingStats { get; set; } = [];

    /// <summary>The player's team.</summary>
    public BaseballTeam Team { get; set; }

    /// <summary>The position(s) this player plays.</summary>
    public List<BaseballPosition> Positions { get; set; } = [];
  }
}