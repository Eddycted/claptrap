using System;
using System.Threading.Tasks;

namespace CL4PTR4P.Services
{
    public class TournamentService : ITournamentService
    {
        public async Task CreateAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task SignupAsync(string name)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITournamentService
    {
        Task CreateAsync(string name);

        Task SignupAsync(string name);
    }
}
