using System;
using System.Threading.Tasks;
using DSharpPlus;
using System.Threading;
using Microsoft.VisualBasic;
using DSharpPlus.Entities;
using System.Xml.XPath;

namespace QwerzenBot
{
    class Program
    {
    
        static DiscordClient discord;

        static void RandomDelay()
        {
            Random rand = new Random();
            int random = rand.Next(3, 12);
            Thread.Sleep(random * 1000);
        }

        static int RandomNumber(int max = 0)
        {
            int random = 0;
            Random rand = new Random();
            if (max != 0)
            {
                random = rand.Next(max);
            }
            else
            {
                random = rand.Next();
            }
            return random;
        }

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
            static async Task MainAsync(string[] args)
            {
                bool inEchoMode = false;
                discord = new DiscordClient(new DiscordConfiguration
                {
                    Token = "NzA1MjY4NjcwNTY1NDQ5Nzc5.XqrlWA.Z498SutsI9IdMC8YAnAoTgEKO6g",
                    TokenType = TokenType.Bot
                });
                discord.MessageCreated += async e =>
                {
                    string msg = e.Message.Content.ToLower();
                    if (inEchoMode == true)
                    {
                        if (msg.StartsWith("qwerzen, exit echo mode"))
                        {
                            inEchoMode = false;
                            return;
                        }
                        if (e.Message.Author.IsBot != true)
                        {
                            await e.Message.RespondAsync(msg);
                        }
                    }
                    if (msg == "qwerzen, terminate.")
                    {
                        await e.Message.RespondAsync("Terminating...");
                        Environment.Exit(02);
                    }
                    if (msg.Contains("qwerzen"))
                    {
                        if (msg.Contains("like"))
                        {
                            RandomDelay();
                            await e.Message.RespondAsync("You better like me.");
                            return;
                        }
                        RandomDelay();
                        await e.Message.RespondAsync("Yes? I heard my name?");
                    }

                    if (msg.StartsWith("qwerzen, enter echo mode"))
                    {
                        inEchoMode = true;
                    }
                };

                await discord.ConnectAsync();
                await Task.Delay(-1);
            }
        }
    }
}
