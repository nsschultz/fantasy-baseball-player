﻿// <auto-generated />
using System;
using FantasyBaseball.PlayerService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FantasyBaseball.PlayerService.Database.Migrations
{
    [DbContext(typeof(PlayerContext))]
    [Migration("20250227172937_rename-oakland-athletics")]
    partial class renameoaklandathletics
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.Property<double>("AverageDraftPick")
                        .HasColumnType("double precision");

                    b.Property<int>("AverageDraftPickMax")
                        .HasColumnType("integer");

                    b.Property<int>("AverageDraftPickMin")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("LastName")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("MayberryMethod")
                        .HasColumnType("integer");

                    b.Property<int>("MlbAmId")
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

                    b.HasAlternateKey("MlbAmId", "Type")
                        .HasName("Player_MlbAmId_AK");

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
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)");

                    b.HasKey("PlayerId", "PositionCode");

                    b.ToTable("PlayerPositionEntity");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.TeamEntity", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("AlternativeCode")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("City")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("LeagueId")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Code")
                        .HasName("Team_PK");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Code = "",
                            City = "Free Agent",
                            LeagueId = "",
                            Nickname = "Free Agent"
                        },
                        new
                        {
                            Code = "BAL",
                            City = "Baltimore",
                            LeagueId = "AL",
                            Nickname = "Orioles"
                        },
                        new
                        {
                            Code = "BOS",
                            City = "Boston",
                            LeagueId = "AL",
                            Nickname = "Red Sox"
                        },
                        new
                        {
                            Code = "NYY",
                            City = "New York",
                            LeagueId = "AL",
                            Nickname = "Yankees"
                        },
                        new
                        {
                            Code = "TB",
                            AlternativeCode = "TAM",
                            City = "Tampa Bay",
                            LeagueId = "AL",
                            Nickname = "Rays"
                        },
                        new
                        {
                            Code = "TOR",
                            City = "Toronto",
                            LeagueId = "AL",
                            Nickname = "Blue Jays"
                        },
                        new
                        {
                            Code = "CWS",
                            AlternativeCode = "CHW",
                            City = "Chicago",
                            LeagueId = "AL",
                            Nickname = "White Sox"
                        },
                        new
                        {
                            Code = "CLE",
                            City = "Cleveland",
                            LeagueId = "AL",
                            Nickname = "Guardians"
                        },
                        new
                        {
                            Code = "DET",
                            City = "Detriot",
                            LeagueId = "AL",
                            Nickname = "Tigers"
                        },
                        new
                        {
                            Code = "KC",
                            City = "Kansas City",
                            LeagueId = "AL",
                            Nickname = "Royals"
                        },
                        new
                        {
                            Code = "MIN",
                            City = "Minnesota",
                            LeagueId = "AL",
                            Nickname = "Twins"
                        },
                        new
                        {
                            Code = "HOU",
                            City = "Houston",
                            LeagueId = "AL",
                            Nickname = "Astros"
                        },
                        new
                        {
                            Code = "LAA",
                            City = "Los Angeles",
                            LeagueId = "AL",
                            Nickname = "Angels"
                        },
                        new
                        {
                            Code = "ATH",
                            City = "",
                            LeagueId = "AL",
                            Nickname = "Athletics"
                        },
                        new
                        {
                            Code = "SEA",
                            City = "Seattle",
                            LeagueId = "AL",
                            Nickname = "Mariners"
                        },
                        new
                        {
                            Code = "TEX",
                            City = "Texas",
                            LeagueId = "AL",
                            Nickname = "Rangers"
                        },
                        new
                        {
                            Code = "ATL",
                            City = "Atlanta",
                            LeagueId = "NL",
                            Nickname = "Braves"
                        },
                        new
                        {
                            Code = "MIA",
                            City = "Miami",
                            LeagueId = "NL",
                            Nickname = "Marlins"
                        },
                        new
                        {
                            Code = "NYM",
                            City = "New York",
                            LeagueId = "NL",
                            Nickname = "Mets"
                        },
                        new
                        {
                            Code = "PHI",
                            City = "Philadelphia",
                            LeagueId = "NL",
                            Nickname = "Phillies"
                        },
                        new
                        {
                            Code = "WAS",
                            AlternativeCode = "WSH",
                            City = "Washington",
                            LeagueId = "NL",
                            Nickname = "Nationals"
                        },
                        new
                        {
                            Code = "CHC",
                            AlternativeCode = "CHI",
                            City = "Chicago",
                            LeagueId = "NL",
                            Nickname = "Cubs"
                        },
                        new
                        {
                            Code = "CIN",
                            City = "Cincinnati",
                            LeagueId = "NL",
                            Nickname = "Reds"
                        },
                        new
                        {
                            Code = "MIL",
                            City = "Milwaukee",
                            LeagueId = "NL",
                            Nickname = "Brewers"
                        },
                        new
                        {
                            Code = "PIT",
                            City = "Pittsburgh",
                            LeagueId = "NL",
                            Nickname = "Pirates"
                        },
                        new
                        {
                            Code = "STL",
                            City = "St. Louis",
                            LeagueId = "NL",
                            Nickname = "Cardinals"
                        },
                        new
                        {
                            Code = "ARZ",
                            AlternativeCode = "ARI",
                            City = "Arizona",
                            LeagueId = "NL",
                            Nickname = "Diamondbacks"
                        },
                        new
                        {
                            Code = "COL",
                            City = "Colorado",
                            LeagueId = "NL",
                            Nickname = "Rockies"
                        },
                        new
                        {
                            Code = "LAD",
                            AlternativeCode = "LA",
                            City = "Los Angeles",
                            LeagueId = "NL",
                            Nickname = "Dodgers"
                        },
                        new
                        {
                            Code = "SD",
                            City = "San Diego",
                            LeagueId = "NL",
                            Nickname = "Padres"
                        },
                        new
                        {
                            Code = "SF",
                            City = "San Francisco",
                            LeagueId = "NL",
                            Nickname = "Giants"
                        });
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.BattingStatsEntity", b =>
                {
                    b.HasOne("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", "Player")
                        .WithMany("BattingStats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("BattingStats_Player_FK");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PitchingStatsEntity", b =>
                {
                    b.HasOne("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", "Player")
                        .WithMany("PitchingStats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PitchingStats_Player_FK");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", b =>
                {
                    b.HasOne("FantasyBaseball.PlayerService.Database.Entities.TeamEntity", "PlayerTeam")
                        .WithMany("Players")
                        .HasForeignKey("Team")
                        .HasConstraintName("Player_Team_FK");

                    b.Navigation("PlayerTeam");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PlayerLeagueStatusEntity", b =>
                {
                    b.HasOne("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", "Player")
                        .WithMany("LeagueStatuses")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("LeagueStatus_Player_FK");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PlayerPositionEntity", b =>
                {
                    b.HasOne("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", "Player")
                        .WithMany("Positions")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PlayerPosition_Player_FK");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.PlayerEntity", b =>
                {
                    b.Navigation("BattingStats");

                    b.Navigation("LeagueStatuses");

                    b.Navigation("PitchingStats");

                    b.Navigation("Positions");
                });

            modelBuilder.Entity("FantasyBaseball.PlayerService.Database.Entities.TeamEntity", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
