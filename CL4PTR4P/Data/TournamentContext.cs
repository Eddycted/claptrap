using CL4PTR4P.Data.Models;
using CL4PTR4P.Data.Models.JoinEntities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CL4PTR4P.Data
{
    public class TournamentContext : DbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        public TournamentContext(DbContextOptions<TournamentContext> options) : base(options) { }

        public TournamentContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Move to configuration file
            optionsBuilder.UseSqlServer(@"Server=(localdb)\claptrap;Database=Claptrap;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Team>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Player>()
                .HasIndex(p => p.PlayerId)
                .IsUnique();

            modelBuilder.Entity<PlayerMatch>()
                .HasKey(pm => new { pm.PlayerId, pm.MatchId });
            modelBuilder.Entity<PlayerMatch>()
                .HasOne(pm => pm.Player)
                .WithMany(p => p.PlayerMatches)
                .HasForeignKey(pm => pm.PlayerId);
            modelBuilder.Entity<PlayerMatch>()
                .HasOne(pm => pm.Match)
                .WithMany(m => m.PlayerMatches)
                .HasForeignKey(pm => pm.MatchId);

            modelBuilder.Entity<PlayerTeam>()
                .HasKey(pt => new { pt.PlayerId, pt.TeamId });
            modelBuilder.Entity<PlayerTeam>()
                .HasOne(pt => pt.Player)
                .WithMany(p => p.PlayerTeams)
                .HasForeignKey(pt => pt.PlayerId);
            modelBuilder.Entity<PlayerTeam>()
                .HasOne(pt => pt.Team)
                .WithMany(t => t.PlayerTeams)
                .HasForeignKey(pt => pt.TeamId);

            modelBuilder.Entity<PlayerTournament>()
                .HasKey(pt => new { pt.PlayerId, pt.TournamentId });
            modelBuilder.Entity<PlayerTournament>()
                .HasOne(pt => pt.Player)
                .WithMany(p => p.PlayerTournaments)
                .HasForeignKey(pt => pt.PlayerId);
            modelBuilder.Entity<PlayerTournament>()
                .HasOne(pt => pt.Tournament)
                .WithMany(t => t.PlayerTournaments)
                .HasForeignKey(pt => pt.TournamentId);

            modelBuilder.Entity<TeamMatch>()
                .HasKey(tm => new { tm.TeamId, tm.MatchId });
            modelBuilder.Entity<TeamMatch>()
                .HasOne(tm => tm.Team)
                .WithMany(t => t.TeamMatches)
                .HasForeignKey(tm => tm.TeamId);
            modelBuilder.Entity<TeamMatch>()
                .HasOne(tm => tm.Match)
                .WithMany(m => m.TeamMatches)
                .HasForeignKey(tm => tm.MatchId);

            modelBuilder.Entity<TeamTournament>()
                .HasKey(tt => new { tt.TeamId, tt.TournamentId });
            modelBuilder.Entity<TeamTournament>()
                .HasOne(tt => tt.Team)
                .WithMany(t => t.TeamTournaments)
                .HasForeignKey(tt => tt.TeamId);
            modelBuilder.Entity<TeamTournament>()
                .HasOne(tt => tt.Tournament)
                .WithMany(t => t.TeamTournaments)
                .HasForeignKey(tt => tt.TournamentId);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        modelBuilder.Entity(entityType.ClrType)
                         .Property<DateTime>(property.Name)
                         .HasConversion(
                          v => v.ToUniversalTime(),
                          v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
                    }
                    else if (property.ClrType == typeof(DateTime?))
                    {
                        modelBuilder.Entity(entityType.ClrType)
                         .Property<DateTime?>(property.Name)
                         .HasConversion(
                          v => v.HasValue ? v.Value.ToUniversalTime() : v,
                          v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);
                    }
                }
            }
        }
    }
}