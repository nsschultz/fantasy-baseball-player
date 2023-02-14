using System;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for adding a player.</summary>
  public class AddPlayerService : IAddPlayerService
  {
    private readonly IMapper _mapper;
    private readonly IPlayerRepository _playerRepo;

    /// <summary>Creates a new instance of the service.</summary>
    /// <param name="mapper">Instance of the auto mapper.</param>
    /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
    public AddPlayerService(IMapper mapper, IPlayerRepository playerRepo) => (_mapper, _playerRepo) = (mapper, playerRepo);

    /// <summary>Adds the given player.</summary>
    /// <param name="player">The player to add.</param>
    /// <returns>The id of the newly created object.</returns>
    public async Task<Guid> AddPlayer(BaseballPlayer player)
    {
      var existingPlayer = await _playerRepo.GetPlayerByBhqId(player.BhqId, player.Type);
      if (existingPlayer != null) throw new BadRequestException("This player already exists");
      var entity = _mapper.Map<PlayerEntity>(player);
      await _playerRepo.AddPlayer(entity);
      return entity.Id;
    }
  }
}