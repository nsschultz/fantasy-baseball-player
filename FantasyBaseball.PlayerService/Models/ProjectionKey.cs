using System;
using FantasyBaseball.PlayerService.Models.Enums;

namespace FantasyBaseball.PlayerService.Models;

/// <summary>A simple object for matching up players. Using type to distinguish two way players.</summary>
public sealed class ProjectionKey
{
  /// <summary>Create a new immutable instance of the key.</summary>
  /// <param name="id">The player's ID.</param>
  /// <param name="type">The player's type (B for Batter or P for Pitcher).</param>
  public ProjectionKey(int id, PlayerType type) => (Id, Type) = (id, type);

  /// <summary>The player's ID.</summary>
  public int Id { get; private set; }

  /// <summary>The player's type (Batter or Pitcher).</summary>
  public PlayerType Type { get; private set; }

  /// <summary>Determines whether the specified object is equal to the current object.</summary>
  /// <param name="obj">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
  public override bool Equals(object obj) => Equals(obj as ProjectionKey);

  /// <summary>Serves as the default hash function.</summary>
  /// <returns>A hash code for the current object.</returns>
  public override int GetHashCode() => HashCode.Combine(Id, Type);

  private bool Equals(ProjectionKey obj) => obj != null && Id == obj.Id && Type == obj.Type;
}