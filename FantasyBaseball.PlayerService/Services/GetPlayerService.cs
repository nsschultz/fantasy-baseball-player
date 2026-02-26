using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Database.Repositories;
using FantasyBaseball.PlayerService.Exceptions;
using FantasyBaseball.PlayerService.Models;

namespace FantasyBaseball.PlayerService.Services;

/// <summary>Service for getting players.</summary>
/// <param name="mapper">Instance of the auto mapper.</param>
/// <param name="playerRepo">Repo for CRUD functionality regarding to players.</param>
/// <param name="positionsService">Service for getting players.</param>
public class GetPlayerService(IMapper mapper, IPlayerRepository playerRepo, IGetPositionService positionsService) : IGetPlayerService
{
  /// <summary>Gets the players from the underlying source.</summary>
  /// <param name="id">The guid of the player to return.</param>
  /// <returns>The player matching the given id.</returns>
  public async Task<BaseballPlayer> GetPlayer(Guid id)
  {
    var positions = await positionsService.GetPositions();
    var player = await playerRepo.GetPlayerById(id) ?? throw new BadRequestException("This player does not exist");
    return mapper.Map<PlayerEntity, BaseballPlayer>(player, opt => opt.AfterMap((src, dest) => dest.Positions = BuildBaseballPositions(src, positions)));
  }

  /// <summary>Gets the players from the underlying source.</summary>
  /// <returns>A list of the players.</returns>
  public async Task<List<BaseballPlayer>> GetPlayers()
  {
    var positions = await positionsService.GetPositions();
    var players = await playerRepo.GetPlayers();
    var baseballPlayers = players.Select(player => mapper.Map<PlayerEntity, BaseballPlayer>(player, opt =>
      opt.AfterMap((src, dest) => dest.Positions = BuildBaseballPositions(src, positions))));
    return SortPlayers([.. baseballPlayers]);
  }

  private static List<BaseballPosition> BuildBaseballPositions(PlayerEntity player, List<BaseballPosition> positions) =>
    [.. player.Positions.SelectMany(p => positions.Where(pp => pp.Code == p.PositionCode)).OrderBy(p => p.SortOrder)];

  private static List<BaseballPlayer> SortPlayers(List<BaseballPlayer> players) =>
    [.. players
      .OrderBy(p => p.Type)
      .ThenBy(p => p.LastName.ToUpper())
      .ThenBy(p => p.FirstName.ToUpper())
      .ThenBy(p => p.MlbAmId)];
}