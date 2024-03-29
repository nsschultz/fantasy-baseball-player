﻿// <auto-generated />
using System;
using FantasyBaseball.PlayerService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FantasyBaseball.PlayerService.Database.Migrations
{
    [DbContext(typeof(PlayerContext))]
    [Migration("20200513041941_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.BattingStatsEntity", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<int>("StatsType")
                        .HasColumnType("integer");

                    b.Property<int>("AtBats")
                        .HasColumnType("integer");

                    b.Property<int>("BaseOnBalls")
                        .HasColumnType("integer");

                    b.Property<int>("CaughtStealing")
                        .HasColumnType("integer");

                    b.Property<int>("Doubles")
                        .HasColumnType("integer");

                    b.Property<int>("Hits")
                        .HasColumnType("integer");

                    b.Property<int>("HomeRuns")
                        .HasColumnType("integer");

                    b.Property<double>("Power")
                        .HasColumnType("double precision");

                    b.Property<int>("Runs")
                        .HasColumnType("integer");

                    b.Property<int>("RunsBattedIn")
                        .HasColumnType("integer");

                    b.Property<double>("Speed")
                        .HasColumnType("double precision");

                    b.Property<int>("StolenBases")
                        .HasColumnType("integer");

                    b.Property<int>("StrikeOuts")
                        .HasColumnType("integer");

                    b.Property<int>("Triples")
                        .HasColumnType("integer");

                    b.HasKey("PlayerId", "StatsType")
                        .HasName("BattingStats_PK");

                    b.ToTable("BattingStats");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.MlbTeamEntity", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("character varying(3)")
                        .HasMaxLength(3);

                    b.Property<string>("AlternativeCode")
                        .HasColumnType("character varying(3)")
                        .HasMaxLength(3);

                    b.Property<string>("City")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("MlbLeagueId")
                        .HasColumnType("character varying(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Nickname")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.HasKey("Code")
                        .HasName("MlbTeam_PK");

                    b.ToTable("MlbTeams");

                    b.HasData(
                        new
                        {
                            Code = "",
                            City = "Free Agent",
                            MlbLeagueId = "",
                            Nickname = "Free Agent"
                        },
                        new
                        {
                            Code = "BAL",
                            City = "Baltimore",
                            MlbLeagueId = "AL",
                            Nickname = "Orioles"
                        },
                        new
                        {
                            Code = "BOS",
                            City = "Boston",
                            MlbLeagueId = "AL",
                            Nickname = "Red Sox"
                        },
                        new
                        {
                            Code = "NYY",
                            City = "New York",
                            MlbLeagueId = "AL",
                            Nickname = "Yankees"
                        },
                        new
                        {
                            Code = "TB",
                            AlternativeCode = "TAM",
                            City = "Tampa Bay",
                            MlbLeagueId = "AL",
                            Nickname = "Rays"
                        },
                        new
                        {
                            Code = "TOR",
                            City = "Toronto",
                            MlbLeagueId = "AL",
                            Nickname = "Blue Jays"
                        },
                        new
                        {
                            Code = "CWS",
                            AlternativeCode = "CHW",
                            City = "Chicago",
                            MlbLeagueId = "AL",
                            Nickname = "White Sox"
                        },
                        new
                        {
                            Code = "CLE",
                            City = "Cleveland",
                            MlbLeagueId = "AL",
                            Nickname = "Indians"
                        },
                        new
                        {
                            Code = "DET",
                            City = "Detriot",
                            MlbLeagueId = "AL",
                            Nickname = "Tigers"
                        },
                        new
                        {
                            Code = "KC",
                            City = "Kansas City",
                            MlbLeagueId = "AL",
                            Nickname = "Royals"
                        },
                        new
                        {
                            Code = "MIN",
                            City = "Minnesota",
                            MlbLeagueId = "AL",
                            Nickname = "Twins"
                        },
                        new
                        {
                            Code = "HOU",
                            City = "Houston",
                            MlbLeagueId = "AL",
                            Nickname = "Astros"
                        },
                        new
                        {
                            Code = "LAA",
                            City = "Los Angeles",
                            MlbLeagueId = "AL",
                            Nickname = "Angels"
                        },
                        new
                        {
                            Code = "OAK",
                            City = "Oakland",
                            MlbLeagueId = "AL",
                            Nickname = "Athletics"
                        },
                        new
                        {
                            Code = "SEA",
                            City = "Seattle",
                            MlbLeagueId = "AL",
                            Nickname = "Mariners"
                        },
                        new
                        {
                            Code = "TEX",
                            City = "Texas",
                            MlbLeagueId = "AL",
                            Nickname = "Rangers"
                        },
                        new
                        {
                            Code = "ATL",
                            City = "Atlanta",
                            MlbLeagueId = "NL",
                            Nickname = "Braves"
                        },
                        new
                        {
                            Code = "MIA",
                            City = "Miami",
                            MlbLeagueId = "NL",
                            Nickname = "Marlins"
                        },
                        new
                        {
                            Code = "NYM",
                            City = "New York",
                            MlbLeagueId = "NL",
                            Nickname = "Mets"
                        },
                        new
                        {
                            Code = "PHI",
                            City = "Philadelphia",
                            MlbLeagueId = "NL",
                            Nickname = "Phillies"
                        },
                        new
                        {
                            Code = "WAS",
                            City = "Washington",
                            MlbLeagueId = "NL",
                            Nickname = "Nationals"
                        },
                        new
                        {
                            Code = "CHC",
                            City = "Chicago",
                            MlbLeagueId = "NL",
                            Nickname = "Cubs"
                        },
                        new
                        {
                            Code = "CIN",
                            City = "Cincinnati",
                            MlbLeagueId = "NL",
                            Nickname = "Reds"
                        },
                        new
                        {
                            Code = "MIL",
                            City = "Milwaukee",
                            MlbLeagueId = "NL",
                            Nickname = "Brewers"
                        },
                        new
                        {
                            Code = "PIT",
                            City = "Pittsburgh",
                            MlbLeagueId = "NL",
                            Nickname = "Pirates"
                        },
                        new
                        {
                            Code = "STL",
                            City = "St. Louis",
                            MlbLeagueId = "NL",
                            Nickname = "Cardinals"
                        },
                        new
                        {
                            Code = "ARZ",
                            AlternativeCode = "ARI",
                            City = "Arizona",
                            MlbLeagueId = "NL",
                            Nickname = "Diamondbacks"
                        },
                        new
                        {
                            Code = "COL",
                            City = "Colorado",
                            MlbLeagueId = "NL",
                            Nickname = "Rockies"
                        },
                        new
                        {
                            Code = "LAD",
                            AlternativeCode = "LA",
                            City = "Los Angeles",
                            MlbLeagueId = "NL",
                            Nickname = "Dodgers"
                        },
                        new
                        {
                            Code = "SD",
                            City = "San Diego",
                            MlbLeagueId = "NL",
                            Nickname = "Padres"
                        },
                        new
                        {
                            Code = "SF",
                            City = "San Francisco",
                            MlbLeagueId = "NL",
                            Nickname = "Giants"
                        });
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PitchingStatsEntity", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<int>("StatsType")
                        .HasColumnType("integer");

                    b.Property<int>("BaseOnBallsAllowed")
                        .HasColumnType("integer");

                    b.Property<int>("BlownSaves")
                        .HasColumnType("integer");

                    b.Property<int>("EarnedRuns")
                        .HasColumnType("integer");

                    b.Property<double>("FlyBallRate")
                        .HasColumnType("double precision");

                    b.Property<double>("GroundBallRate")
                        .HasColumnType("double precision");

                    b.Property<int>("HitsAllowed")
                        .HasColumnType("integer");

                    b.Property<int>("Holds")
                        .HasColumnType("integer");

                    b.Property<int>("HomeRunsAllowed")
                        .HasColumnType("integer");

                    b.Property<double>("InningsPitched")
                        .HasColumnType("double precision");

                    b.Property<int>("Losses")
                        .HasColumnType("integer");

                    b.Property<int>("QualityStarts")
                        .HasColumnType("integer");

                    b.Property<int>("Saves")
                        .HasColumnType("integer");

                    b.Property<int>("StrikeOuts")
                        .HasColumnType("integer");

                    b.Property<int>("Wins")
                        .HasColumnType("integer");

                    b.HasKey("PlayerId", "StatsType")
                        .HasName("PitchingStats_PK");

                    b.ToTable("PitchingStats");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int>("AverageDraftPick")
                        .HasColumnType("integer");

                    b.Property<int>("BhqId")
                        .HasColumnType("integer");

                    b.Property<int>("DraftRank")
                        .HasColumnType("integer");

                    b.Property<double>("DraftedPercentage")
                        .HasColumnType("double precision");

                    b.Property<string>("FirstName")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<int>("HighestPick")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<int>("MayberryMethod")
                        .HasColumnType("integer");

                    b.Property<double>("Reliability")
                        .HasColumnType("double precision");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Team")
                        .HasColumnType("character varying(3)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("Player_PK");

                    b.HasAlternateKey("BhqId", "Type")
                        .HasName("Player_Bhq_AK");

                    b.HasIndex("Team");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PlayerLeagueStatusEntity", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<int>("LeagueId")
                        .HasColumnType("integer");

                    b.Property<int>("LeagueStatus")
                        .HasColumnType("integer");

                    b.HasKey("PlayerId", "LeagueId")
                        .HasName("LeagueStatus_PK");

                    b.ToTable("LeagueStatuses");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PlayerPositionEntity", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<string>("PositionCode")
                        .HasColumnType("character varying(3)");

                    b.HasKey("PlayerId", "PositionCode");

                    b.HasIndex("PositionCode");

                    b.ToTable("PlayerPositionEntity");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PositionEntity", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("character varying(3)")
                        .HasMaxLength(3);

                    b.Property<string>("FullName")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<int>("PlayerType")
                        .HasColumnType("integer");

                    b.Property<int>("SortOrder")
                        .HasColumnType("integer");

                    b.HasKey("Code")
                        .HasName("Position_PK");

                    b.HasIndex("SortOrder")
                        .IsUnique();

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Code = "",
                            FullName = "Unknown",
                            PlayerType = 0,
                            SortOrder = 2147483647
                        },
                        new
                        {
                            Code = "C",
                            FullName = "Catcher",
                            PlayerType = 1,
                            SortOrder = 0
                        },
                        new
                        {
                            Code = "1B",
                            FullName = "First Baseman",
                            PlayerType = 1,
                            SortOrder = 1
                        },
                        new
                        {
                            Code = "2B",
                            FullName = "Second Baseman",
                            PlayerType = 1,
                            SortOrder = 2
                        },
                        new
                        {
                            Code = "3B",
                            FullName = "Third Baseman",
                            PlayerType = 1,
                            SortOrder = 3
                        },
                        new
                        {
                            Code = "SS",
                            FullName = "Shortstop",
                            PlayerType = 1,
                            SortOrder = 4
                        },
                        new
                        {
                            Code = "IF",
                            FullName = "Infielder",
                            PlayerType = 1,
                            SortOrder = 5
                        },
                        new
                        {
                            Code = "LF",
                            FullName = "Left Fielder",
                            PlayerType = 1,
                            SortOrder = 6
                        },
                        new
                        {
                            Code = "CF",
                            FullName = "Center Feilder",
                            PlayerType = 1,
                            SortOrder = 7
                        },
                        new
                        {
                            Code = "RF",
                            FullName = "Right Fielder",
                            PlayerType = 1,
                            SortOrder = 8
                        },
                        new
                        {
                            Code = "OF",
                            FullName = "Outfielder",
                            PlayerType = 1,
                            SortOrder = 9
                        },
                        new
                        {
                            Code = "DH",
                            FullName = "Designated Hitter",
                            PlayerType = 1,
                            SortOrder = 10
                        },
                        new
                        {
                            Code = "SP",
                            FullName = "Starting Pitcher",
                            PlayerType = 1,
                            SortOrder = 11
                        },
                        new
                        {
                            Code = "RP",
                            FullName = "Relief Pitcher",
                            PlayerType = 1,
                            SortOrder = 12
                        },
                        new
                        {
                            Code = "P",
                            FullName = "Pitcher",
                            PlayerType = 1,
                            SortOrder = 13
                        });
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.BattingStatsEntity", b =>
                {
                    b.HasOne("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", "Player")
                        .WithMany("BattingStats")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("BattingStats_Player_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PitchingStatsEntity", b =>
                {
                    b.HasOne("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", "Player")
                        .WithMany("PitchingStats")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("PitchingStats_Player_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", b =>
                {
                    b.HasOne("FantasyBaseball.PlayerService.Database.Entities.MlbTeamEntity", "MlbTeam")
                        .WithMany("Players")
                        .HasForeignKey("Team")
                        .HasConstraintName("Player_MlbTeam_FK");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PlayerLeagueStatusEntity", b =>
                {
                    b.HasOne("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", "Player")
                        .WithMany("LeagueStatuses")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("LeagueStatus_Player_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PlayerPositionEntity", b =>
                {
                    b.HasOne("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", "Player")
                        .WithMany("Positions")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("PlayerPosition_Player_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyBaseball.PlayerService.Database.Entities.PositionEntity", "Position")
                        .WithMany("Players")
                        .HasForeignKey("PositionCode")
                        .HasConstraintName("PlayerPosition_Position_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
