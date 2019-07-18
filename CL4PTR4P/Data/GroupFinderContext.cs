using CL4PTR4P.Data.Models;
using CL4PTR4P.Data.Models.JoinEntities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CL4PTR4P.Data
{
    public class GroupFinderContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        public GroupFinderContext(DbContextOptions<GroupFinderContext> options) : base(options) { }

        public GroupFinderContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Move to configuration file
            optionsBuilder.UseSqlServer(@"Server=(localdb)\claptrap;Database=GroupFinder;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Game>()
                .HasIndex(g => g.Name)
                .IsUnique();

            modelBuilder.Entity<GameUser>()
                .HasKey(gu => new { gu.GameId, gu.UserId });
            modelBuilder.Entity<GameUser>()
                .HasOne(gu => gu.Game)
                .WithMany(u => u.GameUsers)
                .HasForeignKey(gu => gu.GameId);
            modelBuilder.Entity<GameUser>()
                .HasOne(gu => gu.User)
                .WithMany(g => g.GameUsers)
                .HasForeignKey(gu => gu.UserId);

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