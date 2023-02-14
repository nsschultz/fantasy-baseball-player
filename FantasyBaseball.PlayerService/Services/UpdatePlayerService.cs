using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services.Mergers;

namespace FantasyBaseball.PlayerService.Services
{
  /// <summary>Service for updating a player.</summary>
  public class UpdatePlayerService : IUpdatePlayerService
  {
    private static readonly IPlayerMerger Merger = new FullPlayerMerger();
    private readonly IMergePlayerService _mergeService;
    private readonly IPlayerRepository _playerRepo;

    /// <summary>Creates a new instance of the service.</summary>
    /// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
    /// <param name="mergeService">Service for converting a BaseballPlayer to a PlayerEntity.</param>
    public UpdatePlayerService(IPlayerRepository playerRepo, IMergePlayerService mergeService) => (_playerRepo, _mergeService) = (playerRepo, mergeService);

    /// <summary>Updates the given player.</summary>
    /// <param name="player">The player to update.</param>
    public async Task UpdatePlayer(BaseballPlayer player)
    {
      var existingPlayer = await _playerRepo.GetPlayerById(player.Id);
      if (existingPlayer == null) throw new BadRequestException("This player does not exist");
      if (existingPlayer.Type != player.Type) throw new BadRequestException("The player type cannot be changed");
      var updatedPlayer = await _mergeService.MergePlayer(Merger, player, existingPlayer);
      await _playerRepo.UpdatePlayer(updatedPlayer);
    }
  }
}