using CL4PTR4P.Services;
using Discord.Commands;
using System.Threading.Tasks;

namespace CL4PTR4P.Modules
{
    [Group("tournament")]
    [Name("Tournament Module")]
    public class TournamentModule : ModuleBase<SocketCommandContext>
    {
        private readonly ITournamentService _tournamentService;

        public TournamentModule(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [Command("create")]
        [Summary("Creates a new tournament.")]
        [Remarks("Supported formats: FFA, solo, team")]
        public async Task CreateAsync(string name, string format)
        {
            await ReplyAsync($"Creating new {format} {name} tournament.");
            await _tournamentService.CreateAsync(name);
        }

        [Command("signup")]
        [Summary("Sign up for the specified tournament.")]
        public async Task SignUpAsync(string name)
        {

        }
    }
}