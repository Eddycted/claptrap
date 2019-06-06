using Discord.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CL4PTR4P.Modules
{
    public class LanModule : ModuleBase<SocketCommandContext>
    {
        private static readonly List<string> users = new List<string>();
        private static readonly Random random = new Random();

        // !bier
        [Command("bier")]
        [Summary("Wie moet bier halen?")]
        [Alias("2woorden9letters", "bierhalen", "ikhebdorst")]
        public async Task BierAsync()
        {
            // We can also access the channel from the Command Context.
            await ReplyAsync($"Nieuwe ronde bier! Typ '!plus1' voor bier!");
        }

        // !plus1
        [Command("plus1")]
        [Summary("Inschrijven voor de bier ronde.")]
        public async Task Plus1Async()
        {
            users.Add(Context.User.Username);
            await ReplyAsync($"{Context.User.Username} wil ook bier.");
        }

        // !plus1
        [Command("halen")]
        [Summary("Wie moet het bier halen?")]
        public async Task HalenAsync()
        {
            await ReplyAsync($"{users[random.Next(users.Count)]} moet bier halen voor {string.Join(", ", users)}!");
            users.Clear();
        }
    }
}