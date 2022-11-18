using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FantasyBaseball.Common.Enums;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerService.Database.Entities;
using FantasyBaseball.PlayerService.Models;
using Xunit;

namespace FantasyBaseball.PlayerService.Maps.UnitTests
{
    public class BaseballPlayerV1ProfileTest
    {
        private IMapper _mapper;

        public BaseballPlayerV1ProfileTest() =>
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new BaseballPlayerV1Profile())).CreateMapper();

        [Fact] public void ConvertFromV1NullTest() => Assert.Null(_mapper.Map<BaseballPlayer>((BaseballPlayerV1)null));

        [Theory]
        [InlineData(10, PlayerType.B)]
        [InlineData(100, PlayerType.P)]
        public void ConvertFromV1ValidTest(int value, PlayerType type)
        {
            var player = BuildBaseballPlayerV1(value, type);
            ValidatePlayer(player, _mapper.Map<BaseballPlayer>(player));
        }

        [Fact] public void ConvertToV1NullTest() => Assert.Null(_mapper.Map<BaseballPlayerV1>((BaseballPlayer)null));

        [Theory]
        [InlineData(10, PlayerType.B)]
        [InlineData(100, PlayerType.P)]
        public void ConvertToV1ValidTest(int value, PlayerType type)
        {
            var player = BuildBaseballPlayer(value, type);
            ValidatePlayer(player, _mapper.Map<BaseballPlayerV1>(player));
        }

        private static BaseballPlayer BuildBaseballPlayer(int value, PlayerType type) =>
            new BaseballPlayer
            {
                Id = Guid.NewGuid(),
                BhqId = value,
                FirstName = $"First-{value}",
                LastName = $"Last-{value}",
                Age = value,
                Type = type,
                Positions = type == PlayerType.P
                    ? new List<BaseballPosition>()
                    : new List<BaseballPosition> { new BaseballPosition { Code = "SS" }, new BaseballPosition { Code = "OF" } },
                Team = value == 10 ? new BaseballTeam { Code = $"Team-{value}" } : null,
                Status = value == 10 ? PlayerStatus.XX : PlayerStatus.DL,
                DraftRank = value + 1,
                AverageDraftPick = value + 2,
                HighestPick = value + 3,
                DraftedPercentage = value + 4,
                MayberryMethod = value + 5,
                Reliability = value + 6,
                League1 = value == 10 ? LeagueStatus.R : LeagueStatus.X,
                League2 = value == 10 ? LeagueStatus.R : LeagueStatus.X,
                BattingStats = new List<BattingStats>
                {
                    new BattingStats
                    {
                        StatsType = value == 10 ? StatsType.YTD : StatsType.PROJ,
                        AtBats = 300,
                        Runs = 75,
                        Hits = 96,
                        Doubles = 24,
                        Triples = 6,
                        HomeRuns = 12,
                        RunsBattedIn = 48,
                        BaseOnBalls = 30,
                        StrikeOuts = 60,
                        StolenBases = 9,
                        CaughtStealing = 3,
                        Power = 100,
                        Speed = 61
                    }
                },
                PitchingStats = new List<PitchingStats>
                {
                    new PitchingStats
                    {
                        StatsType = value == 10 ? StatsType.YTD : StatsType.PROJ,
                        Wins = 12,
                        Losses = 6,
                        QualityStarts = 18,
                        Saves = 9,
                        BlownSaves = 3,
                        Holds = 15,
                        InningsPitched = 60,
                        HitsAllowed = 45,
                        EarnedRuns = 24,
                        HomeRunsAllowed = 1,
                        BaseOnBallsAllowed = 30,
                        StrikeOuts = 120,
                        FlyBallRate = 0.2,
                        GroundBallRate = 0.31
                    }
                }
            };

        private static BaseballPlayerV1 BuildBaseballPlayerV1(int value, PlayerType type) =>
            new BaseballPlayerV1
            {
                Id = Guid.NewGuid(),
                BhqId = value,
                FirstName = $"First-{value}",
                LastName = $"Last-{value}",
                Age = value,
                Type = type,
                Positions = type == PlayerType.P ? null : "SS-OF",
                Team = $"Team-{value}",
                Status = value == 10 ? PlayerStatus.XX : PlayerStatus.DL,
                DraftRank = value + 1,
                AverageDraftPick = value + 2,
                HighestPick = value + 3,
                DraftedPercentage = value + 4,
                MayberryMethod = value + 5,
                Reliability = value + 6,
                League1 = value == 10 ? LeagueStatus.R : LeagueStatus.X,
                League2 = value == 10 ? LeagueStatus.R : LeagueStatus.X,
                BattingStats = new List<BattingStats>
                {
                    new BattingStats
                    {
                        StatsType = value == 10 ? StatsType.YTD : StatsType.PROJ,
                        AtBats = 300,
                        Runs = 75,
                        Hits = 96,
                        Doubles = 24,
                        Triples = 6,
                        HomeRuns = 12,
                        RunsBattedIn = 48,
                        BaseOnBalls = 30,
                        StrikeOuts = 60,
                        StolenBases = 9,
                        CaughtStealing = 3,
                        Power = 100,
                        Speed = 61
                    }
                },
                PitchingStats = new List<PitchingStats>
                {
                    new PitchingStats
                    {
                        StatsType = value == 10 ? StatsType.YTD : StatsType.PROJ,
                        Wins = 12,
                        Losses = 6,
                        QualityStarts = 18,
                        Saves = 9,
                        BlownSaves = 3,
                        Holds = 15,
                        InningsPitched = 60,
                        HitsAllowed = 45,
                        EarnedRuns = 24,
                        HomeRunsAllowed = 1,
                        BaseOnBallsAllowed = 30,
                        StrikeOuts = 120,
                        FlyBallRate = 0.2,
                        GroundBallRate = 0.31
                    }
                }
            };

        private static string BuildPositionString(List<BaseballPosition> positions) => string.Join("-", positions.OrderBy(p => p.SortOrder).Select(p => p.Code));

        private static string BuildPositionString(List<PlayerPositionEntity> positions) => string.Join("-", positions.Select(p => p.PositionCode));

        private static void ValidatePlayer(BaseballPlayer expected, BaseballPlayerV1 actual)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.BhqId, actual.BhqId);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.Age, actual.Age);
            Assert.Equal(expected.Type, actual.Type);
            Assert.Equal(BuildPositionString(expected.Positions), actual.Positions);
            Assert.Equal(expected.Team?.Code, actual.Team);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.DraftRank, actual.DraftRank);
            Assert.Equal(expected.AverageDraftPick, actual.AverageDraftPick);
            Assert.Equal(expected.HighestPick, actual.HighestPick);
            Assert.Equal(expected.DraftedPercentage, actual.DraftedPercentage);
            Assert.Equal(expected.MayberryMethod, actual.MayberryMethod);
            Assert.Equal(expected.Reliability, actual.Reliability);
            Assert.Equal(expected.League1, actual.League1);
            Assert.Equal(expected.League2, actual.League2);
            ValidatePlayerBattingStats(expected.BattingStats.First(), actual.BattingStats.First());
            ValidatePlayerPitchingStats(expected.PitchingStats.First(), actual.PitchingStats.First());
        }

        private static void ValidatePlayer(BaseballPlayerV1 expected, BaseballPlayer actual)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.BhqId, actual.BhqId);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.Age, actual.Age);
            Assert.Equal(expected.Type, actual.Type);
            Assert.Equal(string.IsNullOrEmpty(expected.Positions) ? "" : expected.Positions, BuildPositionString(actual.Positions));
            Assert.Equal(expected.Team, actual.Team.Code);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.DraftRank, actual.DraftRank);
            Assert.Equal(expected.AverageDraftPick, actual.AverageDraftPick);
            Assert.Equal(expected.HighestPick, actual.HighestPick);
            Assert.Equal(expected.DraftedPercentage, actual.DraftedPercentage);
            Assert.Equal(expected.MayberryMethod, actual.MayberryMethod);
            Assert.Equal(expected.Reliability, actual.Reliability);
            Assert.Equal(expected.League1, actual.League1);
            Assert.Equal(expected.League2, actual.League2);
            ValidatePlayerBattingStats(expected.BattingStats.First(), actual.BattingStats.First());
            ValidatePlayerPitchingStats(expected.PitchingStats.First(), actual.PitchingStats.First());
        }

        private static void ValidatePlayerBattingStats(BattingStats expected, BattingStats actual)
        {
            Assert.Equal(expected.AtBats, actual.AtBats);
            Assert.Equal(expected.Runs, actual.Runs);
            Assert.Equal(expected.Hits, actual.Hits);
            Assert.Equal(expected.Doubles, actual.Doubles);
            Assert.Equal(expected.Triples, actual.Triples);
            Assert.Equal(expected.HomeRuns, actual.HomeRuns);
            Assert.Equal(expected.RunsBattedIn, actual.RunsBattedIn);
            Assert.Equal(expected.BaseOnBalls, actual.BaseOnBalls);
            Assert.Equal(expected.StrikeOuts, actual.StrikeOuts);
            Assert.Equal(expected.StolenBases, actual.StolenBases);
            Assert.Equal(expected.CaughtStealing, actual.CaughtStealing);
            Assert.Equal(expected.Power, actual.Power);
            Assert.Equal(expected.Speed, actual.Speed);
        }

        private static void ValidatePlayerPitchingStats(PitchingStats expected, PitchingStats actual)
        {
            Assert.Equal(expected.Wins, actual.Wins);
            Assert.Equal(expected.Losses, actual.Losses);
            Assert.Equal(expected.QualityStarts, actual.QualityStarts);
            Assert.Equal(expected.Saves, actual.Saves);
            Assert.Equal(expected.BlownSaves, actual.BlownSaves);
            Assert.Equal(expected.Holds, actual.Holds);
            Assert.Equal(expected.InningsPitched, actual.InningsPitched);
            Assert.Equal(expected.HitsAllowed, actual.HitsAllowed);
            Assert.Equal(expected.EarnedRuns, actual.EarnedRuns);
            Assert.Equal(expected.HomeRunsAllowed, actual.HomeRunsAllowed);
            Assert.Equal(expected.BaseOnBallsAllowed, actual.BaseOnBallsAllowed);
            Assert.Equal(expected.StrikeOuts, actual.StrikeOuts);
            Assert.Equal(expected.FlyBallRate, actual.FlyBallRate);
            Assert.Equal(expected.GroundBallRate, actual.GroundBallRate);
        }
    }
}