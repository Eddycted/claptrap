using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL4PTR4P.Modules
{
    [Name("Bier Module")]
    public class BierModule : ModuleBase<SocketCommandContext>
    {
        private static readonly List<string> users = new List<string>();
        private static readonly Random random = new Random();
        private readonly EmbedBuilder output = new EmbedBuilder { Footer = new EmbedFooterBuilder() };

        [Command("bier")]
        [Alias("2woorden9letters", "bierhalen", "ikhebdorst")]
        [Summary("Tijd voor een nieuw rondje!")]
        public async Task BierAsync()
        {
            if (users.Any())
            {
                output.Title = $"De ronde is al gestart!";
                output.Footer.Text = $"Typ '!plus1' als je ook bier wil, of typ '!halen' om te bepalen wie er moet lopen.";
                await ReplyAsync(embed: output.Build());
                return;
            }

            var user = (IGuildUser)Context.User;
            var nickname = user.Nickname ?? user.Username;
            users.Add(nickname);

            output.AddField($"Bierrrrr!", $"Nieuwe ronde gestart door {Context.User.Mention}!");
            output.Footer.Text = $"Typ '!plus1' als je ook bier wil.";
            await ReplyAsync(embed: output.Build());
        }

        [Command("plus1")]
        [Alias("+1")]
        [Summary("Inschrijven voor de bier ronde.")]
        public async Task Plus1Async()
        {
            if (!users.Any())
            {
                output.Title = $"Er is nog geen ronde gestart.";
                output.Footer.Text = $"Typ '!bier' om een ronde te starten.";
                await ReplyAsync(embed: output.Build());
                return;
            }

            var user = (IGuildUser)Context.User;
            var nickname = user.Nickname ?? user.Username;
            users.Add(nickname);

            output.AddField($"+1", $"{Context.User.Mention} wil ook bier!");
            await ReplyAsync(embed: output.Build());
        }

        [Command("halen")]
        [Summary("Wie moet het bier halen?")]
        public async Task HalenAsync()
        {
            if (!users.Any())
            {
                output.Title = $"Het lijkt erop dat niemand dorst heeft, man.";
                output.Footer.Text = $"Typ '!bier' om een ronde te starten.";
                await ReplyAsync(embed: output.Build());
                return;
            }

            var user = (IGuildUser)Context.User;
            var nickname = user.Nickname ?? user.Username;
            if (users.Count == 1 && users.First() == nickname)
            {
                output.AddField($"Wat een topper!", $"{Context.User.Mention} haalt voor zichzelf wel even een biertje!");
            }
            else
            {
                // TODO: Mention winner
                var winnaar = users[random.Next(users.Count)];
                output.AddField($"Halen!", $"{winnaar} gaat {users.Count} bier halen voor:\n{string.Join(", ", users)}!");
            }
            users.Clear();

            await ReplyAsync(embed: output.Build());
        }
    }
}