using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Models;

/// <summary>All of the information that makes up a baseball player.</summary>
public class BaseballPlayer
{
  /// <summary>The player's ID.</summary>
  [JsonRequired] public Guid Id { get; set; }

  /// <summary>The player's MLB BAM ID.</summary>
  [JsonRequired] public int MlbAmId { get; set; }

  /// <summary>The player's type (B for Batter or P for Pitcher).</summary>
  [JsonRequired] public PlayerType Type { get; set; }

  /// <summary>The player's first name.</summary>
  public string FirstName { get; set; }

  /// <summary>The player's last name.</summary>
  public string LastName { get; set; }

  /// <summary>The player's age.</summary>
  [JsonRequired] public int Age { get; set; }

  /// <summary>The player's status.</summary>
  [JsonRequired] public PlayerStatus Status { get; set; }

  /// <summary>The average draft position (ADP) for this player.</summary>
  [JsonRequired] public double AverageDraftPick { get; set; }

  /// <summary>The earliest pick used on this player.</summary>
  [JsonRequired] public int AverageDraftPickMin { get; set; }

  /// <summary>The latest pick used on this player.</summary>
  [JsonRequired] public int AverageDraftPickMax { get; set; }

  /// <summary>The player's projected reliability.</summary>
  [JsonRequired] public double Reliability { get; set; }

  /// <summary>The player's Mayberry Method score.</summary>
  [JsonRequired] public int MayberryMethod { get; set; }

  /// <summary>The player's status for League #1.</summary>
  [JsonRequired] public LeagueStatus League1 { get; set; }

  /// <summary>The player's status for League #2.</summary>
  [JsonRequired] public LeagueStatus League2 { get; set; }

  /// <summary>Batting Stats (Year to Date, Projected and Combined) for a given player.</summary>
  public List<BattingStats> BattingStats { get; set; } = [];

  /// <summary>Pitching Stats (Year to Date, Projected and Combined) for a given player.</summary>
  public List<PitchingStats> PitchingStats { get; set; } = [];

  /// <summary>The player's team.</summary>
  public BaseballTeam Team { get; set; }

  /// <summary>The position(s) this player plays.</summary>
  public List<BaseballPosition> Positions { get; set; } = [];
}