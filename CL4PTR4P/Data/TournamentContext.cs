using CL4PTR4P.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CL4PTR4P.Data
{
    public class TournamentContext : DbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        public TournamentContext(DbContextOptions<TournamentContext> options) : base(options) { }

        public TournamentContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Move to configuration file
            optionsBuilder.UseSqlServer(@"Server=(localdb)\claptrap;Database=Claptrap;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}