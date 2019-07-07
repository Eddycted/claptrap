using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace CL4PTR4P.Modules
{
    [Name("Meme Module")]
    public class MemeModule : ModuleBase<SocketCommandContext>
    {
        [Command("thunderfury")]
        [Summary("???")]
        public async Task ThunderfuryAsync()
        {
            var user = Context.Guild.GetUser(361612714117824512);
            if (user != null)
            {
                var output = new EmbedBuilder { Footer = new EmbedFooterBuilder() };
                output.ThumbnailUrl = "https://wow.zamimg.com/images/wow/icons/large/inv_sword_39.jpg";
                output.AddField("THUNDERFURY!", $"Misschien wil {user.Mention} die even vasthouden?", true);
                await ReplyAsync(embed: output.Build());
            }            
        }
    }
}