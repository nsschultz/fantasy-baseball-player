using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FantasyBaseball.PlayerService.Database.Repositories;

/// <summary>Repo for CRUD functionality regarding to players.</summary>
/// <param name="context">The player context.</param>
public class PlayerRepository(IPlayerContext context) : IPlayerRepository
{
  /// <summary>Adds the given player to the database.</summary>
  /// <param name="player">The player data.</param>
  public async Task AddPlayer(PlayerEntity player)
  {
    try
    {
      await context.BeginTransaction();
      await context.Players.AddAsync(player);
      await context.Commit();
    }
    catch (Exception)
    {
      await context.Rollback();
      throw;
    }
  }

  /// <summary>Removes all of the players from the database.</summary>
  public async Task DeleteAllPlayers()
  {
    try
    {
      await context.BeginTransaction();
      context.Players.RemoveRange(context.Players);
      await context.Commit();
    }
    catch (Exception)
    {
      await context.Rollback();
      throw;
    }
  }

  /// <summary>Deletes the given player from the database.</summary>
  /// <param name="player">The player data.</param>
  public async Task DeletePlayer(PlayerEntity player)
  {
    try
    {
      await context.BeginTransaction();
      context.Players.Remove(player);
      await context.Commit();
    }
    catch (Exception)
    {
      await context.Rollback();
      throw;
    }
  }

  /// <summary>Finds a player matching the given values (which must be a uniqure combo in the db) or null if there is no match.</summary>
  /// <param name="mlbAmId">The id from the external system.</param>
  /// <param name="type">The type of the player (which makes the BHQ Id combo unique).</param>
  /// <returns>The player matching the given values.</returns>
  public async Task<PlayerEntity> GetPlayerByMlbAmId(int mlbAmId, PlayerType type) =>
    await GetQueryable().Where(p => p.MlbAmId == mlbAmId).Where(p => p.Type == type).FirstOrDefaultAsync();

  /// <summary>Finds a player matching the given id or null if there is no match.</summary>
  /// <param name="id">The guid of the player to find.</param>
  /// <returns>The player matching the given id.</returns>
  public async Task<PlayerEntity> GetPlayerById(Guid id) => await GetQueryable().FirstOrDefaultAsync(p => p.Id == id);

  /// <summary>Gets a list of player entities from the database.</summary>
  /// <param name="type">The type of player to return or all if this value is null.</param>
  /// <returns>A list of the players.</returns>
  public async Task<List<PlayerEntity>> GetPlayers(PlayerType? type = null) =>
    await GetQueryable().Where(p => type == null || p.Type == type).ToListAsync();

  /// <summary>Updates the given player.</summary>
  /// <param name="player">The player data.</param>
  public async Task UpdatePlayer(PlayerEntity player)
  {
    try
    {
      await context.BeginTransaction();
      context.Players.Update(player);
      await context.Commit();
    }
    catch (Exception)
    {
      await context.Rollback();
      throw;
    }
  }

  /// <summary>Takes a collection of players and updates or adds them to the database.</summary>
  /// <param name="entities">The collection of players.</param>
  public async Task UpsertPlayers(IEnumerable<PlayerEntity> entities)
  {
    try
    {
      await context.BeginTransaction();
      var splitEntities = SplitPlayers(entities);
      await context.Players.AddRangeAsync(splitEntities.Item1);
      context.Players.UpdateRange(splitEntities.Item2); await context.Commit();
    }
    catch (Exception)
    {
      await context.Rollback();
      throw;
    }
  }

  private IQueryable<PlayerEntity> GetQueryable() =>
      context.Players
        .Include(p => p.LeagueStatuses)
        .Include(p => p.PlayerTeam)
        .Include(p => p.Positions)
        .Include(p => p.BattingStats)
        .Include(p => p.PitchingStats);

  private static (IEnumerable<PlayerEntity>, IEnumerable<PlayerEntity>) SplitPlayers(IEnumerable<PlayerEntity> entities)
  {
    var newPlayers = new List<PlayerEntity>();
    var existingPlayers = new List<PlayerEntity>();
    entities.ToList().ForEach(p =>
    {
      if (p.Id == Guid.Empty) newPlayers.Add(p);
      else existingPlayers.Add(p);
    });
    return (newPlayers, existingPlayers);
  }
}