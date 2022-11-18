using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database.Entities;

namespace FantasyBaseball.PlayerService.Services
{
    /// <summary>Service for converting a BaseballPlayer to a PlayerEntity.</summary>
    public class PlayerEntityMergerService : IPlayerEntityMergerService
    {
        private static readonly List<StatsType> ExpectedStats = new List<StatsType> { StatsType.YTD, StatsType.PROJ };
        private readonly IGetPositionService _positionsService;
        private readonly IGetTeamsService _teamsService;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="positionsService">Service for getting players.</param>
        /// <param name="teamsService">Service for getting teams.</param>
        public PlayerEntityMergerService(IGetPositionService positionsService, IGetTeamsService teamsService) =>
            (_positionsService, _teamsService) = (positionsService, teamsService);

        /// <summary>Merges a BaseballPlayer into a PlayerEntity.</summary>
        /// <param name="incoming">The incoming player values.</param>
        /// <param name="existing">The existing player values.</param>
        /// <returns>An object that can be saved to the database.</returns>
        public async Task<PlayerEntity> MergePlayerEntity(BaseballPlayer incoming, PlayerEntity existing)
        {
            if (incoming == null) return existing;
            var positions = await _positionsService.GetPositions();
            var teams = await _teamsService.GetTeams();
            var entity = MergePlayerValues(incoming, existing);
            MergeBattingStats(incoming, entity);
            MergePitchingStats(incoming, entity);
            MergeLeagueStatus(incoming.League1, 1, entity);
            MergeLeagueStatus(incoming.League2, 2, entity);
            MergePositions(incoming.Positions, positions, entity);
            MergeTeam(incoming.Team, teams, entity);
            return entity;
        }

        private static PlayerPositionEntity FindDefaultPosition(List<BaseballPosition> positions, PlayerEntity existing)
        {
            var max = positions.Where(p => p.PlayerType == existing.Type).Max(p => p.SortOrder);
            return new PlayerPositionEntity { PositionCode = positions.First(p => p.SortOrder == max).Code };
        }

        private static bool IsValidBattingStats(BattingStats stats) => stats != null && stats.AtBats + stats.BaseOnBalls > 0;

        private static bool IsValidPitchingStats(PitchingStats stats) =>
            stats != null && stats.InningsPitched + stats.GroundBallRate + stats.FlyBallRate + stats.BaseOnBallsAllowed > 0;

        private static void MergeBattingStats(BaseballPlayer player, PlayerEntity entity)
        {
            if (player.BattingStats.Any()) ExpectedStats.ForEach(s => MergeBattingStats(player, entity, s));
            else entity.BattingStats.Clear();
        }

        private static void MergeBattingStats(BattingStats stats, BattingStatsEntity entity)
        {
            entity.AtBats = stats.AtBats;
            entity.Runs = stats.Runs;
            entity.Hits = stats.Hits;
            entity.Doubles = stats.Doubles;
            entity.Triples = stats.Triples;
            entity.HomeRuns = stats.HomeRuns;
            entity.RunsBattedIn = stats.RunsBattedIn;
            entity.BaseOnBalls = stats.BaseOnBalls;
            entity.StrikeOuts = stats.StrikeOuts;
            entity.StolenBases = stats.StolenBases;
            entity.CaughtStealing = stats.CaughtStealing;
            entity.Power = stats.Power;
            entity.Speed = stats.Speed;
        }

        private static void MergeBattingStats(BaseballPlayer player, PlayerEntity entity, StatsType type)
        {
            var stats = player.BattingStats.FirstOrDefault(s => s.StatsType == type);
            var statsEntity = entity.BattingStats.FirstOrDefault(s => s.StatsType == type);
            if (IsValidBattingStats(stats)) MergeBattingStats(stats, statsEntity == null ? SetupBattingStats(entity, stats.StatsType) : statsEntity);
            else if (statsEntity != null) entity.BattingStats.Remove(statsEntity);
        }

        private static void MergeLeagueStatus(LeagueStatus status, int leagueId, PlayerEntity entity)
        {
            var statusEntity = entity.LeagueStatuses.FirstOrDefault(s => s.LeagueId == leagueId);
            if (LeagueStatus.A != status) (statusEntity == null ? SetupLeagueStatus(entity, leagueId) : statusEntity).LeagueStatus = status;
            else if (statusEntity != null) entity.LeagueStatuses.Remove(statusEntity);
        }

        private static void MergePitchingStats(BaseballPlayer player, PlayerEntity entity)
        {
            if (player.PitchingStats.Any()) ExpectedStats.ForEach(s => MergePitchingStats(player, entity, s));
            else entity.PitchingStats.Clear();
        }

        private static void MergePitchingStats(PitchingStats stats, PitchingStatsEntity entity)
        {
            entity.Wins = stats.Wins;
            entity.Losses = stats.Losses;
            entity.QualityStarts = stats.QualityStarts;
            entity.Saves = stats.Saves;
            entity.BlownSaves = stats.BlownSaves;
            entity.Holds = stats.Holds;
            entity.InningsPitched = stats.InningsPitched;
            entity.HitsAllowed = stats.HitsAllowed;
            entity.EarnedRuns = stats.EarnedRuns;
            entity.HomeRunsAllowed = stats.HomeRunsAllowed;
            entity.BaseOnBallsAllowed = stats.BaseOnBallsAllowed;
            entity.StrikeOuts = stats.StrikeOuts;
            entity.FlyBallRate = stats.FlyBallRate;
            entity.GroundBallRate = stats.GroundBallRate;
        }

        private static void MergePitchingStats(BaseballPlayer player, PlayerEntity entity, StatsType type)
        {
            var stats = player.PitchingStats.FirstOrDefault(s => s.StatsType == type);
            var statsEntity = entity.PitchingStats.FirstOrDefault(s => s.StatsType == type);
            if (IsValidPitchingStats(stats)) MergePitchingStats(stats, statsEntity == null ? SetupPitchingStats(entity, stats.StatsType) : statsEntity);
            else if (statsEntity != null) entity.PitchingStats.Remove(statsEntity);
        }

        private static PlayerEntity MergePlayerValues(BaseballPlayer incoming, PlayerEntity entity)
        {
            if (entity == null) entity = new PlayerEntity();
            entity.BhqId = incoming.BhqId;
            entity.Type = incoming.Type;
            entity.FirstName = incoming.FirstName;
            entity.LastName = incoming.LastName;
            entity.Age = incoming.Age;
            entity.Status = incoming.Status;
            entity.DraftRank = incoming.DraftRank;
            entity.AverageDraftPick = incoming.AverageDraftPick;
            entity.HighestPick = incoming.HighestPick;
            entity.DraftedPercentage = incoming.DraftedPercentage;
            entity.Reliability = incoming.Reliability;
            entity.MayberryMethod = incoming.MayberryMethod;
            return entity;
        }

        private static void MergePositions(List<BaseballPosition> incomingPostions, List<BaseballPosition> fullPositionList, PlayerEntity entity)
        {
            if (fullPositionList == null) return;
            entity.Positions.Clear();
            var positionSet = fullPositionList.Select(p => p.Code).ToHashSet();
            var positionCodes = incomingPostions != null ? incomingPostions.Select(p => p.Code) : Array.Empty<string>();
            entity.Positions.AddRange(positionCodes
                .Select(p => p.Trim().ToUpper())
                .Where(p => positionSet.Contains(p))
                .Select(p => new PlayerPositionEntity { PositionCode = p }));
            if (!entity.Positions.Any()) entity.Positions.Add(FindDefaultPosition(fullPositionList, entity));
        }

        private static void MergeTeam(BaseballTeam incomingTeam, List<TeamEntity> fullTeamList, PlayerEntity entity)
        {
            if (fullTeamList == null) return;
            var incomingCode = string.IsNullOrWhiteSpace(incomingTeam?.Code) ? string.Empty : incomingTeam.Code.Trim().ToUpper();
            var team = fullTeamList
                .FirstOrDefault(t => t.Code == incomingCode || (!string.IsNullOrWhiteSpace(t.AlternativeCode) && t.AlternativeCode == incomingCode));
            team = team ?? fullTeamList.FirstOrDefault(t => t.Code == string.Empty);
            entity.PlayerTeam = team;
            entity.Team = team.Code;
        }

        private static BattingStatsEntity SetupBattingStats(PlayerEntity entity, StatsType statsType)
        {
            var statsEntity = new BattingStatsEntity { PlayerId = entity.Id, StatsType = statsType, Player = entity };
            entity.BattingStats.Add(statsEntity);
            return statsEntity;
        }

        private static PlayerLeagueStatusEntity SetupLeagueStatus(PlayerEntity entity, int leagueId)
        {
            var statusEntity = new PlayerLeagueStatusEntity { PlayerId = entity.Id, LeagueId = leagueId, Player = entity };
            entity.LeagueStatuses.Add(statusEntity);
            return statusEntity;
        }

        private static PitchingStatsEntity SetupPitchingStats(PlayerEntity entity, StatsType statsType)
        {
            var statsEntity = new PitchingStatsEntity { PlayerId = entity.Id, StatsType = statsType, Player = entity };
            entity.PitchingStats.Add(statsEntity);
            return statsEntity;
        }
    }
}