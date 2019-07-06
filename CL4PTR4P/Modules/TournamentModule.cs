using CL4PTR4P.Data.Enums;
using CL4PTR4P.Services;
using Discord.Commands;
using System;
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
            Enum.TryParse(format, ignoreCase: true, out TournamentFormat tournamentFormat);

            if (tournamentFormat == TournamentFormat.None)
            {
                await ReplyAsync($"Invalid tournament format: {format}");
                return;
            }

            await ReplyAsync($"Creating new {format} {name} tournament.");
            await _tournamentService.CreateAsync(name, tournamentFormat);
        }

        [Command("signup")]
        [Summary("Sign up for the specified tournament.")]
        public async Task SignUpAsync(string tournament)
        {
            await ReplyAsync($"Signing you up for tournament {tournament}, {Context.User.Mention}.");
            await _tournamentService.SignUpAsync(tournament, Context.User.Id);
        }
    }
}