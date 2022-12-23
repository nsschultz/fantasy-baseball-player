namespace FantasyBaseball.PlayerService.Models
{
  /// <summary>All of the information that makes up a baseball player.</summary>
  public class BaseballPlayerV1 : BaseballPlayer
  {
    /// <summary>The player's team.</summary>
    public string Team { get; set; }

    /// <summary>The position(s) this player plays.</summary>
    public string Positions { get; set; }
  }
}