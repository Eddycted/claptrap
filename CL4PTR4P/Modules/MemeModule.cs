using Discord.Commands;
using System.Threading.Tasks;

namespace CL4PTR4P.Modules
{
    [Name("Meme Module")]
    public class MemeModule : ModuleBase<SocketCommandContext>
    {
        // TODO: Find and .Mention
        [Command("thunderfury")]
        [Summary("Echoes a message.")]
        public async Task ThunderfuryAsync()
        {
            await ReplyAsync($"Misschien wil Demix (Roel) die even vasthouden?");
        }
    }
}