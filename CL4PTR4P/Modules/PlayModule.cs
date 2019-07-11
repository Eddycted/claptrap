using Discord;
using Discord.Commands;
using System.Linq;
using System.Threading.Tasks;

namespace CL4PTR4P.Modules
{
    [Name("Play Module")]
    public class PlayModule : ModuleBase<SocketCommandContext>
    {
        [Command("wiespeeltwat")]
        [Summary("Laat zien wie welke game speelt.")]
        public async Task ListPlayedGamesAsync()
        {
            var output = new EmbedBuilder { Footer = new EmbedFooterBuilder() };

            var activities = Context.Guild.Users
                .Where(u => u.Activity != null && !u.IsBot)
                .GroupBy(u => u.Activity.Name)
                .Select(g => g.FirstOrDefault().Activity.Name)
                .OrderBy(g => g)
                .ToList();

            if (!activities.Any())
            {
                output.AddField("No Results", "No one is currently playing games.");
                await ReplyAsync(embed: output.Build());
                return;
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

            await ReplyAsync(embed: output.Build());
        }
    }
}