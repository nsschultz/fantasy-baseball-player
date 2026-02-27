using System;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services;

/// <summary>Service for adding a player.</summary>
/// <param name="mapper">Instance of the auto mapper.</param>
/// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
public class AddPlayerService(IMapper mapper, IPlayerRepository playerRepo) : IAddPlayerService
{
  /// <summary>Adds the given player.</summary>
  /// <param name="player">The player to add.</param>
  /// <returns>The id of the newly created object.</returns>
  public async Task<Guid> AddPlayer(BaseballPlayer player)
  {
    var existingPlayer = await playerRepo.GetPlayerByMlbAmId(player.MlbAmId, player.Type);
    if (existingPlayer != null) throw new BadRequestException("This player already exists");
    var entity = mapper.Map<PlayerEntity>(player);
    await playerRepo.AddPlayer(entity);
    return entity.Id;
  }
}