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
                        else if (msg.Contains("what\'s"))
                        {
                            string[] math = msg.Split("what\'s")[1].Split();
                            bool isValid = true;
                            int result = 0;
                            try
                            {
                                int num1 = Int32.Parse(math[1]);
                                int num2 = Int32.Parse(math[3]);

                                switch (math[2])
                                {
                                    case "plus":
                                    case "+":
                                        result = num1 + num2;
                                        break;
                                    case "minus":
                                    case "-":
                                        result = num1 - num2;
                                        break;
                                    case "times":
                                    case "*":
                                        result = num1 - num2;
                                        break;
                                    case "divide":
                                    case "/":
                                        result = num1 - num2;
                                        break;
                                    default:
                                        await e.Message.RespondAsync("What? This is not a number.");
                                        isValid = false;
                                        break;
                                }

                                if (isValid) await e.Message.RespondAsync(math[0] + " " + math[1] + " " + math[2] + " is " + result);
                            }
                            catch (FormatException)
                            {
                                await e.Message.RespondAsync("Hey! Those aren't numbers!");
                            }
                            RandomDelay();
                            await e.Message.RespondAsync("Yes? I heard my name?");
                        }
                    }
<<<<<<< HEAD
                };
                    discord.GuildMemberRemoved += async e =>
                    {
                        int messageID = RandomNumber(5);
                        string userNickName = e.Member.Nickname;

                        switch (messageID)
                        {
                            case 1:
                                await discord.SendMessageAsync(null, ("We will miss you, " + userNickName + "."));
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
=======

                    if (msg.StartsWith("qwerzen, enter echo mode"))
                    {
                        inEchoMode = true;
                    }
                };
>>>>>>> 49267132b52b6fef1bf31625fda8f23be2d697b7

                    await discord.ConnectAsync();
                    await Task.Delay(-1);
                }
            }
        }
    }
