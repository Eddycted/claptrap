using CL4PTR4P.Data.Enums;
using System.Threading.Tasks;

namespace CL4PTR4P.Services.Interfaces
{
    public interface ITournamentService
    {
        Task CreateAsync(string tournamentName, TournamentFormat format);

        Task SignUpAsync(string tournamentName, ulong playerId);

        Task StartTournamentAsync(string tournamentName);
    }
}