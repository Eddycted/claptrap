using Discord.Commands;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System;

namespace CL4PTR4P.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private static MethodInfo[] array = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .SelectMany(t => t.GetMethods())
            .Where(m => m.GetCustomAttributes(typeof(CommandAttribute), false).Length > 0)
            .ToArray();

        [Command("help")]
        [Summary("Lists available commands.")]
        [Alias("?")]
        public async Task InfoAsync()
        {
            var temp = array.Select(m => m.GetCustomAttribute<CommandAttribute>().Text);

            await ReplyAsync($"List of commands:{Environment.NewLine}{string.Join(Environment.NewLine, temp)}");
        }
    }
}
