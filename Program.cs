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
            int random = rand.Next(3, 7);
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
            Console.Write("Would you like to start in Remote mode? (Y / n): ");
            string remoteaccessbool = Console.ReadLine();
            if (remoteaccessbool.ToLower() == "y")
            {
                Shell.DropToShell();
            }

            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
            static async Task MainAsync(string[] args)
            {
                bool inEchoMode = false;
                int songSection = 0;

                discord = new DiscordClient(new DiscordConfiguration
                {
                    Token = "NzA1MjY4NjcwNTY1NDQ5Nzc5.XqrlWA.Z498SutsI9IdMC8YAnAoTgEKO6g",
                    TokenType = TokenType.Bot
                });

                discord.Ready += async e =>
                {
                    await discord.SendMessageAsync(await discord.GetChannelAsync(705796441989447763), "Qwerzen online.");
                };

                discord.MessageCreated += async e =>
                {
                    string msg = e.Message.Content.ToLower();
                    string unaltered_msg = e.Message.Content;

                    if (msg.StartsWith("qwerzen, enter echo mode"))
                    {
                        await e.Message.RespondAsync("Entering echo mode");
                        inEchoMode = true;
                        return;
                    }
                    if (msg.StartsWith("qwerzen, enter remote mode"))
                    {
                        Shell.DropToShell();
                        return;
                    }
                    if (inEchoMode == true)
                    {
                        if (msg.StartsWith("qwerzen, exit echo mode"))
                        {
                            await e.Message.RespondAsync("Exiting echo mode");
                            inEchoMode = false;
                            return;
                        }
                        if (msg == "qwerzen, terminate.")
                        {
                            await e.Message.RespondAsync("Terminating...");
                            Environment.Exit(02);
                        }
                        if (e.Message.Author.IsBot == false && (e.Message.Author.Id == 705799634894848011 || e.Message.Author.Id == 248252747344904192))
                        {
                            await e.Message.DeleteAsync();
                            Thread.Sleep(1000);
                            await e.Message.RespondAsync(unaltered_msg);
                            return;
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
                        else if (msg.Contains("what is"))
                        {
                            string[] math = msg.Split("what is")[1].Split();
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

                                if (isValid) await e.Message.RespondAsync(math[1] + " " + math[2] + " " + math[3] + " is " + result);
                                return;
                            }
                            catch (FormatException)
                            {
                                await e.Message.RespondAsync("Hey! Those aren't numbers!");
                                return;
                            }
                        }
                        RandomDelay();
                        await e.Message.RespondAsync("Yes? I heard my name?");
                    }

                    // song
                    if (msg == "beautiful... crazy...")
                    {
                        RandomDelay();
                        songSection = 0;
                        await e.Message.RespondAsync("she can't help but...");
                        songSection++;
                    }
                    if (msg == "amaze me!" && songSection == 1)
                    {
                        RandomDelay();
                        await e.Message.RespondAsync("it drives me so crazy...");
                        songSection++;
                    }
                    if (msg == "the way that she's walking..." && songSection == 2)
                    {
                        RandomDelay();
                        await e.Message.RespondAsync("the way that she moves!");
                        songSection++;
                    }
                    if (msg == "oh god i love..." && songSection == 3)
                    {
                        RandomDelay();
                        await e.Message.RespondAsync("my baby!");
                        songSection++;
                    }
                    if (msg.Contains("yeah!") && songSection == 4)
                    {
                        RandomDelay();
                        await e.Message.RespondAsync("woo!!");
                        songSection = 0;
                    }
                };
                // discord.GuildMemberRemoved += async e =>
                {
                    int messageID = RandomNumber(5);
                //    string userNickName = e.Member.Nickname;

                    switch (messageID)
                    {
                        case 1:
                  //          await discord.SendMessageAsync(null, ("We will miss you, " + userNickName + "."));
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
            };
        }
    }
}
