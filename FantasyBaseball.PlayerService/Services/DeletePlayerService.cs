using System;
using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for deleting a player.</summary>
  /// <remarks>Creates a new instance of the service.</remarks>
  /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
  public class DeletePlayerService(IPlayerRepository playerRepo) : IDeletePlayerService
  {
    private readonly IPlayerRepository _playerRepo = playerRepo;

    /// <summary>Removes all of the players from the source.</summary>
    public async Task DeleteAllPlayers() => await _playerRepo.DeleteAllPlayers();

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