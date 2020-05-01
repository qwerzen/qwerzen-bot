﻿using System;
using System.Threading.Tasks;
using DSharpPlus;
using System.Threading;
using Microsoft.VisualBasic;
using DSharpPlus.Entities;
using System.Xml.XPath;

namespace QwerzenBot
{
    public class Shell
    {
        static DiscordClient discord;

        static async void MainAsync()
        {
            DiscordGuild guild = await discord.GetGuildAsync(699387333673222154);
            DiscordChannel announcments = guild.GetChannel(705114893128564757);
            DiscordChannel lingu = guild.GetChannel(703573253066719232);
            DiscordChannel general = guild.GetChannel(699387333673222157);

            string vwd = "/"; // virtual working directory
            bool? messageModeEnabled = null;
            if (messageModeEnabled != true) { Console.Write("remote@qwerzen:" + vwd + "$ "); }
            string input = Console.ReadLine();
            input = input.Replace(("remote@qwerzen:" + vwd + "$ "), "").ToLower().Trim();
            if (input.StartsWith("new"))
            {
                if (input.EndsWith("announcement"))
                {
                    Console.WriteLine("\n Enter announcment: \n");
                    string text = Console.ReadLine();
                    await discord.SendMessageAsync(announcments, ("@everyone" + text));
                }
            }

            if (input.StartsWith("message"))
            {
                if (input.EndsWith("general"))
                {
                    Console.WriteLine("Enter message: ");
                    await discord.SendMessageAsync(general, Console.ReadLine());
                }

                if (input.EndsWith("lingu"))
                {
                    Console.WriteLine("Enter message: ");
                    await discord.SendMessageAsync(lingu, Console.ReadLine());
                }
            }

            if (input.StartsWith("enter") && input.EndsWith("mode"))
            {
                if (input.Contains("message"))
                {
                    string line;
                    messageModeEnabled = true;
                    while (9 == 9)
                    {
                        if ((line = Console.ReadLine()) != "exit") 
                        {
                            messageModeEnabled = false;
                            break;
                        }
                        else
                        {
                            Console.Write("general: ");
                            await discord.SendMessageAsync(general, line);
                        }
                    }
                }
             
            }

            if (input == "terminate connection")
            {
                return;
            }

            MainAsync();
            return;
        }

        public static void DropToShell(string[] args = null)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "NzA1MjY4NjcwNTY1NDQ5Nzc5.XqrlWA.Z498SutsI9IdMC8YAnAoTgEKO6g",
                TokenType = TokenType.Bot
            });

            Thread inputEval = new Thread(MainAsync);
            Thread messages = new Thread(new ParameterizedThreadStart(getMessages));
            inputEval.Start();
            messages.Start();
        }

        static void getMessages(object args)
        {
            getMessagesT((string[])args).ConfigureAwait(false).GetAwaiter().GetResult();
            static async Task getMessagesT(string[] args)
            {
                discord.MessageCreated += async e =>
                {
                    Console.WriteLine((e.Message.Author.Username + "@" + e.Message.Channel.Name + ": " + e.Message.Content));
                };

                await discord.ConnectAsync();
                await Task.Delay(-1);
            }
            throw new Exception("You aren't supposed to be here.");
        }
        
    }
}
