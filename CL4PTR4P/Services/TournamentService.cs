using CL4PTR4P.Data;
using CL4PTR4P.Data.Enums;
using CL4PTR4P.Data.Models;
using System;
using System.Threading.Tasks;

namespace CL4PTR4P.Services
{
    public class TournamentService : ITournamentService
    { 
        private readonly TournamentContext _tournamentContext;

        public TournamentService(TournamentContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public async Task Create(TournamentFormat format, string name)
        {
            var tournament = new Tournament
            {
                Format = format,
                Name = name
            };

            await _tournamentContext.AddAsync(tournament);
            await _tournamentContext.SaveChangesAsync();
        }

        public async Task Signup(string name)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITournamentService
    {
        Task Create(TournamentFormat format, string name);

        Task Signup(string name);
    }
}