using Guilded;
using Guilded.Base.Embeds;
using Spectre.Console;
using System;
using System.Text;

namespace Guilded_KeyAuth_Seller_Bot.Misc
{
    internal class Logs
    {
        public static async void Log(GuildedBotClient client, string message, string config)
        {
            var channel = new Guid(config);

            try
            {
                await client.CreateMessageAsync(channel, message);
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteLine(DateTime.Now + $"Error: {ex}");
            }
            AnsiConsole.WriteLine(DateTime.Now + $"> {message}");
        }
    }
}
