using System.Threading.Tasks;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;
using FantasyBaseball.PlayerService.Services.Mergers;

namespace FantasyBaseball.PlayerService.Services;

/// <summary>Service for updating a player.</summary>
/// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
/// <param name="mergeService">Service for converting a BaseballPlayer to a PlayerEntity.</param>
public class UpdatePlayerService(IPlayerRepository playerRepo, IMergePlayerService mergeService) : IUpdatePlayerService
{
  private static readonly IPlayerMerger Merger = new FullPlayerMerger();

  /// <summary>Updates the given player.</summary>
  /// <param name="player">The player to update.</param>
  public async Task UpdatePlayer(BaseballPlayer player)
  {
    var existingPlayer = await playerRepo.GetPlayerById(player.Id) ?? throw new BadRequestException("This player does not exist");
    if (existingPlayer.Type != player.Type) throw new BadRequestException("The player type cannot be changed");
    var updatedPlayer = await mergeService.MergePlayer(Merger, player, existingPlayer);
    await playerRepo.UpdatePlayer(updatedPlayer);
  }
}