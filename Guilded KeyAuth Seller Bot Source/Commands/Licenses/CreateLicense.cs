using Guilded;
using Guilded_KeyAuth_Seller_Bot.Connection;
using Guilded_KeyAuth_Seller_Bot.Misc;
using Newtonsoft.Json;
using System.Net;
using System.Reactive.Linq;
using System.Text;

namespace Guilded_KeyAuth_Seller_Bot.Commands.Licenses
{
    internal class CreateLicense
    {
        public static void License_CreateLicense(GuildedBotClient client, string prefix)
        {
            client.MessageCreated
                .Where(msgCreated => msgCreated.Content.StartsWith(prefix + "CreateLicense"))
                .Subscribe(async msgCreated =>
                {
                    try
                    {
                        var json = string.Empty;

                        using (var fs = File.OpenRead("config.json"))
                        using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                            json = await sr.ReadToEndAsync().ConfigureAwait(false);

                        var configJson = JsonConvert.DeserializeObject<Json>(json);

                        if (configJson.SellerKey == string.Empty)
                        {
                            Logs.Log(client, "No sellerkey found. Please check your config.json file to check you have added your key.", configJson.GuildedLogsChannel);
                        }

                        string[] sections = msgCreated.Content.Split(' ');
                        string format = sections[1],
                               expiry = sections[2],
                               mask = sections[3],
                               level = sections[4],
                               amount = sections[5];

                        if (string.IsNullOrEmpty(format) || string.IsNullOrEmpty(expiry) || string.IsNullOrEmpty(mask) || string.IsNullOrEmpty(level) || string.IsNullOrEmpty(amount))
                        {
                            await msgCreated.ReplyAsync("Invalid Usage. Usage: !CreateLicense <format> <expiry> <mask> <level> <amount> ");
                        }
                        else
                        {
                             
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(configJson.SellerAPILink + configJson.SellerKey + 
                                "&type=" + configJson.Type_Add + 
                                "&expiry=" + expiry + 
                                "&mask=" + mask + 
                                "&level=" + level + 
                                "&amount=" + amount);
                            request.UserAgent = "KeyAuth";
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            var reader = new StreamReader(response.GetResponseStream());
                            string rC = reader.ReadToEnd();
                            await msgCreated.ReplyAsync(rC);

                            Logs.Log(client, rC, configJson.GuildedLogsChannel);
                        }
                    }
                    catch (Exception)
                    {
                        await msgCreated.ReplyAsync("There was an error with the request.");
                    }
                   
                });
        }
    }
}
