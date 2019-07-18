using Discord;
using Discord.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CL4PTR4P.Modules
{
    [Name("Play Module")]
    public class PlayModule : ModuleBase<SocketCommandContext>
    {
        // TODO: Channel filter param

        [Command("wiespeeltwat")]
        [Summary("Laat zien wie welke game speelt.")]
        public Task ListPlayingGamesAsync()
        {
            var output = new EmbedBuilder();

            var activities = Context.Guild.Users
                .Where(u => u.Activity != null && !u.IsBot)
                .GroupBy(u => u.Activity.Name)
                .Select(g => g.FirstOrDefault().Activity.Name)
                .OrderBy(g => g)
                .ToList();

            if (!activities.Any())
            {
                output.AddField("No Results", "No one is currently playing games.");
                return ReplyAsync(embed: output.Build());
            }

            foreach (var activity in activities)
            {
                var names = Context.Guild.Users
                    .Where(u => u.Activity?.Name == activity)
                    .Select(u => u.Nickname ?? u.Username)
                    .ToList();

                var result = $"{names.Count} - " + string.Join(", ", names);

                output.AddField(activity, result);
            }

            return ReplyAsync(embed: output.Build());
        }

        [Command("wiespeelt")]
        [Summary("Laat zien wie de gespecificeerde game speelt.")]
        public Task IsPlayingGameAsync([Remainder]string gameName)
        {
            var output = new EmbedBuilder();

            var players = Context.Guild.Users
                .Where(u => u.Activity != null && string.Equals(u.Activity.Name, gameName, StringComparison.OrdinalIgnoreCase));

            if (!players.Any())
            {
                output.AddField("No Results", $"No one is currently playing {gameName}.");
                return ReplyAsync(embed: output.Build());
            }

            var result = string.Join(", ", players.Select(u => u.Nickname ?? u.Username));

            output.AddField($"{players.First().Activity.Name} ({players.Count()})", result);

            return ReplyAsync(embed: output.Build());
        }

        [Command("ikwil")]
        [Summary("Laat weten wat je wil spelen.")]
        [Alias("lfg")]
        public Task IWantToPlayAsync([Remainder]string gameName)
        {
            
            throw new NotImplementedException();
        }

        [Command("wiewil")]
        [Summary("Laat zien wie de gespecificeerde game wil spelen.")]
        public Task WhoWantsToPlayAsync([Remainder]string gameName)
        {

            throw new NotImplementedException();
        }
    }
}