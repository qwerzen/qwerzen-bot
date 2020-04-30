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
            Random rand = new Random();
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
            static async Task MainAsync(string[] args)
            {
                discord = new DiscordClient(new DiscordConfiguration
                {
                    Token = "NzA1MjY4NjcwNTY1NDQ5Nzc5.XqrlWA.Z498SutsI9IdMC8YAnAoTgEKO6g",
                    TokenType = TokenType.Bot
                });
                discord.MessageCreated += async e =>
                {
                    string msg = e.Message.Content.ToLower();
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
                };
                discord.GuildMemberRemoved += async e =>
                {
                    int messageID = RandomNumber(5);
                    string userNickName = e.Member.Nickname;

                    switch (messageID)
                    {
                        case 1:
                            await discord.SendMessageAsync( null, ("We will miss you, " + userNickName + "."));
                            break;

                        case 2:

                            break;

                        case 3:

                            break;

                        case 4:

                            break;

                        case 5:

                            break;

                        default:
                            break;
                    }
                };

                await discord.ConnectAsync();
                await Task.Delay(-1);
            }
        }
    }
}
