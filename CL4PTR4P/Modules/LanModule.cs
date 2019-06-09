using Discord.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace CL4PTR4P.Modules
{
    [Name("Bier Module")]
    public class BierModule : ModuleBase<SocketCommandContext>
    {
        private static readonly List<string> users = new List<string>();
        private static readonly Random random = new Random();

        [Command("bier")]
        [Summary("Wie moet bier halen?")]
        [Alias("2woorden9letters", "bierhalen", "ikhebdorst")]
        public async Task BierAsync()
        {
            if (users.Any())
            {
                await ReplyAsync($"De ronde is al gestart. Typ '!plus1' als je ook bier wil, of typ '!halen' om te bepalen wie er moet lopen.");
                return;
            }

            users.Add(Context.User.Username);
            await ReplyAsync($"Nieuwe ronde! Typ '!plus1' als je ook bier wil!");
        }

        [Command("plus1")]
        [Summary("Inschrijven voor de bier ronde.")]
        public async Task Plus1Async()
        {
            if (!users.Any())
            {
                await ReplyAsync($"Er is nog geen ronde gestart. Typ '!bier' om te starten.");
                return;
            }

            users.Add(Context.User.Username);
            await ReplyAsync($"{Context.User.Username} wil ook bier.");
        }

        [Command("halen")]
        [Summary("Wie moet het bier halen?")]
        public async Task HalenAsync()
        {
            if (!users.Any())
            {
                await ReplyAsync($"Niemand wil bier, mafkees!");
                return;
            }

            if (users.Count == 1 && users.First() == Context.User.Username)
            {
                await ReplyAsync($"{Context.User.Username} haalt voor zichzelf een biertje. Kijk die topper gaan!");                
            }
            else
            {
                await ReplyAsync($"{users[random.Next(users.Count)]} moet {users.Count} bier halen voor: {string.Join(", ", users)}!");
            }
            users.Clear();
        }
    }
}