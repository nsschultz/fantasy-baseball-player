using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for deleting a player.</summary>
  public class DeletePlayerService : IDeletePlayerService
  {
    private readonly IPlayerRepository _playerRepo;

    /// <summary>Creates a new instance of the service.</summary>
    /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
    public DeletePlayerService(IPlayerRepository playerRepo) => _playerRepo = playerRepo;

    /// <summary>Deletes the given player from the data store.</summary>
    /// <param name="id">The guid of the player to delete.</param>
    public async Task DeletePlayer(Guid id)

    {
      var existingPlayer = await _playerRepo.GetPlayerById(id);
      if (existingPlayer == null) throw new BadRequestException("This player does not exist");
      await _playerRepo.DeletePlayer(existingPlayer);
    }
  }
}