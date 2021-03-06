﻿// <auto-generated />
using System;
using CL4PTR4P.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CL4PTR4P.Migrations
{
    [DbContext(typeof(TournamentContext))]
    partial class TournamentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CL4PTR4P.Data.Models.JoinEntities.PlayerMatch", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("MatchId");

                    b.HasKey("PlayerId", "MatchId");

                    b.HasIndex("MatchId");

                    b.ToTable("PlayerMatch");
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.JoinEntities.PlayerTeam", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("TeamId");

                    b.HasKey("PlayerId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("PlayerTeam");
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.JoinEntities.PlayerTournament", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("TournamentId");

                    b.HasKey("PlayerId", "TournamentId");

                    b.HasIndex("TournamentId");

                    b.ToTable("PlayerTournament");
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.JoinEntities.TeamMatch", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("MatchId");

                    b.HasKey("TeamId", "MatchId");

                    b.HasIndex("MatchId");

                    b.ToTable("TeamMatch");
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.JoinEntities.TeamTournament", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("TournamentId");

                    b.HasKey("TeamId", "TournamentId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TeamTournament");
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TournamentId");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<decimal>("PlayerId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Format");

                    b.Property<bool>("HasStarted");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("TeamSize");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.JoinEntities.PlayerMatch", b =>
                {
                    b.HasOne("CL4PTR4P.Data.Models.Match", "Match")
                        .WithMany("PlayerMatches")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CL4PTR4P.Data.Models.Player", "Player")
                        .WithMany("PlayerMatches")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.JoinEntities.PlayerTeam", b =>
                {
                    b.HasOne("CL4PTR4P.Data.Models.Player", "Player")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CL4PTR4P.Data.Models.Team", "Team")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.JoinEntities.PlayerTournament", b =>
                {
                    b.HasOne("CL4PTR4P.Data.Models.Player", "Player")
                        .WithMany("PlayerTournaments")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CL4PTR4P.Data.Models.Tournament", "Tournament")
                        .WithMany("PlayerTournaments")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.JoinEntities.TeamMatch", b =>
                {
                    b.HasOne("CL4PTR4P.Data.Models.Match", "Match")
                        .WithMany("TeamMatches")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CL4PTR4P.Data.Models.Team", "Team")
                        .WithMany("TeamMatches")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.JoinEntities.TeamTournament", b =>
                {
                    b.HasOne("CL4PTR4P.Data.Models.Team", "Team")
                        .WithMany("TeamTournaments")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CL4PTR4P.Data.Models.Tournament", "Tournament")
                        .WithMany("TeamTournaments")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CL4PTR4P.Data.Models.Match", b =>
                {
                    b.HasOne("CL4PTR4P.Data.Models.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId");
                });
#pragma warning restore 612, 618
        }
    }
}
