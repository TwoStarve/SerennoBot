using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerennoBot
{
    class MyBot
    {
        DiscordClient discord;

        Random rand;

        string[] ball;

        public MyBot()
        {
            rand = new Random();

            ball = new string[]
            {
                "Yes.", // 0
                "No.", // 1
                "Definitely.", // 2
                "Probably.", // 3
                "Ask again.", // 4
                "Never.", //5
                "Absolutely not.", //6
                "Ask a friend.", //7
            };

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '~';
                x.AllowMentionPrefix = true;
            });

            var commands = discord.GetService<CommandService>();

            discord.UserJoined += async (s, e) =>
            {
                var channel = e.Server.FindChannels("ooc", ChannelType.Text).FirstOrDefault();

                var user = e.User;

                await channel.SendMessage(string.Format("{0} has joined the server!", user.Name));
            };

            discord.UserLeft += async (s, e) =>
            {
                var channel = e.Server.FindChannels("ooc", ChannelType.Text).FirstOrDefault();

                var user = e.User;

                await channel.SendMessage(string.Format("{0} has left the server!", user.Name));
            };

            commands.CreateCommand("help")
            .Do(async (e) =>
            {
            await e.Channel.SendMessage("~help - Gives you a list of commands.\n~rules - Gives you a list of the rules, follow them!\n~8ball - Gives you a randomly generated response.\n~Lenny - ( ͡° ͜ʖ ͡°)\n~Kappa - <:kappa:329855501074694144>\n~Ping - Pong!\n~rp1 - Announces a RP in the RP1 channel.\n~rp2 - Announces a RP in the RP2 channel.\n~rp3 - Announces a RP in the RP3 channel.\n~shittymeme - Posts a shitty terrible meme.\n");
            });

            commands.CreateCommand("rules")
            .Do(async (e) =>
            {
                await e.Channel.SendMessage("No posting pornographic content.\nTry not to spam unless in meme wars.\nTry and keep OOC chat in the OOC channel.\nNo bullying.\nKeep flaming to a minimum.\nDo not spam the functions of any bot.\n");
            });

            commands.CreateCommand("lenny")
            .Do(async (e) =>
            {
            await e.Channel.SendMessage("( ͡° ͜ʖ ͡°)");
            });

            commands.CreateCommand("shittymeme")
            .Do(async (e) =>
            {
            await e.Channel.SendMessage("https://www.youtube.com/watch?v=a-5VCZyAMz0");
            });

            commands.CreateCommand("kappa")
            .Do(async (e) =>
            {
            await e.Channel.SendMessage("<:kappa:329855501074694144>");
            });

            commands.CreateCommand("ping")
            .Do(async (e) =>
            {
            await e.Channel.SendMessage("Pong!");
            });

            commands.CreateCommand("rp1")
            .Do(async (e) =>
            {
                var channel = e.Server.FindChannels("ooc", ChannelType.Text).FirstOrDefault();

                var user = e.User;

                await channel.SendMessage(string.Format("@everyone {0} has started a RP in the RP1 channel!", user.Name));
            });

            commands.CreateCommand("rp2")
            .Do(async (e) =>
            {
                var channel = e.Server.FindChannels("ooc", ChannelType.Text).FirstOrDefault();

                var user = e.User;

                await channel.SendMessage(string.Format("@everyone {0} has started a RP in the RP2 channel!", user.Name));
            });

            commands.CreateCommand("rp3")
            .Do(async (e) =>
            {
                var channel = e.Server.FindChannels("ooc", ChannelType.Text).FirstOrDefault();

                var user = e.User;

                await channel.SendMessage(string.Format("@everyone {0} has started a RP in the RP3 channel!", user.Name));
            });

            commands.CreateCommand("8ball")
            .Do(async (e) =>
            {
                int randomresponse = rand.Next(ball.Length);
                string responsetopost = ball[randomresponse];
                await e.Channel.SendMessage(responsetopost);
            });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzI5ODEzMTMzMjMxMTI4NTc2.DDYCsA.dj84S0Raal5Vr2KojK4-ueSsh6A", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
