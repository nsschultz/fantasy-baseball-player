using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database;
using FantasyBaseball.PlayerService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for upsert players.</summary>
    public class UpsertPlayersService : IUpsertPlayersService
    {
        private readonly IPlayerContext _context;
        private readonly IPlayerEntityMergerService _entityMerger;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="context">The player context.</param>
        /// <param name="entityMerger">Service for converting a BaseballPlayer to a PlayerEntity.</param>
        public UpsertPlayersService(IPlayerContext context, IPlayerEntityMergerService entityMerger) =>
            (_context, _entityMerger) = (context, entityMerger);

        /// <summary>Gets the players from the underlying source.</summary>
        /// <param name="players">All of the players to upsert into the source.</param>
        public async Task UpsertPlayers(List<BaseballPlayer> players)
        {
            try
            {
                await _context.BeginTransaction();
                var mergedPlayers = players.Select(p => _entityMerger.MergePlayerEntity(p, FindEntity(p)));
                await UpsertPlayers(await Task.WhenAll(mergedPlayers));
                await _context.Commit();
            }
            catch (Exception)
            {
                await _context.Rollback();
                throw;
            }
        }

        private PlayerEntity FindEntity(BaseballPlayer player) =>
            player.Id != default
                ? _context.Players
                    .Include(p => p.LeagueStatuses)
                    .Include(p => p.PlayerTeam)
                    .Include(p => p.Positions)
                    .Include(p => p.BattingStats)
                    .Include(p => p.PitchingStats)
                    .FirstOrDefault(p => p.Id == player.Id)
                : _context.Players.AsQueryable()
                    .Include(p => p.LeagueStatuses)
                    .Include(p => p.PlayerTeam)
                    .Include(p => p.Positions)
                    .Include(p => p.BattingStats)
                    .Include(p => p.PitchingStats)
                    .Where(p => p.BhqId == player.BhqId)
                    .Where(p => p.Type == player.Type)
                    .FirstOrDefault();

        private static (IEnumerable<PlayerEntity>, IEnumerable<PlayerEntity>) SplitPlayers(IEnumerable<PlayerEntity> entities)
        {
            var newPlayers = new List<PlayerEntity>();
            var existingPlayers = new List<PlayerEntity>();
            entities.ToList().ForEach(p =>
            {
                if (p.Id == default) newPlayers.Add(p);
                else existingPlayers.Add(p);
            });
            return (newPlayers, existingPlayers);
        }

        private async Task UpsertPlayers(IEnumerable<PlayerEntity> entities)
        {
            var splitEntities = SplitPlayers(entities);
            await _context.Players.AddRangeAsync(splitEntities.Item1);
            _context.Players.UpdateRange(splitEntities.Item2);
        }
    }
}