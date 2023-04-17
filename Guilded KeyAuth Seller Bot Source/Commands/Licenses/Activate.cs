using Guilded;
using Guilded_KeyAuth_Seller_Bot.Connection;
using Guilded_KeyAuth_Seller_Bot.Misc;
using Newtonsoft.Json;
using System.Net;
using System.Reactive.Linq;
using System.Text;

namespace Guilded_KeyAuth_Seller_Bot.Commands.Licenses
{
    internal class Activate
    {
        public static void License_Activate(GuildedBotClient client, string prefix)
        {
            client.MessageCreated
                .Where(msgCreated => msgCreated.Content.StartsWith(prefix + "Activate"))
                .Subscribe(async msgCreated =>
                {
                    try
                    {
                        var json = string.Empty;

                        using (var fs = File.OpenRead("config.json"))
                        using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                            json = await sr.ReadToEndAsync().ConfigureAwait(false);

                        var configJson = JsonConvert.DeserializeObject<Json>(json);

                        if (string.IsNullOrEmpty(configJson.SellerKey) || configJson.SellerKey.Length < 32)
                        {
                            Logs.Log(client, "No sellerkey found. Please check your config.json file to check you have added your key.", configJson.GuildedLogsChannel);
                        }

                        string[] sections = msgCreated.Content.Split(' ');
                        string user = sections[1],
                               key = sections[2],
                               pass = sections[3];

                        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(pass))
                        {
                            await msgCreated.ReplyAsync("Invalid Usage. Usage: !Activate <user> <key> <password>");
                        }

                         
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(configJson.SellerAPILink + configJson.SellerKey + 
                            "&type=" + configJson.Type_Activate + 
                            "&user=" + user + 
                            "&key=" + key + 
                            "&pass=" + pass); ;
                        request.UserAgent = "KeyAuth";
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        var reader = new StreamReader(response.GetResponseStream());
                        string rC = reader.ReadToEnd();
                        await msgCreated.ReplyAsync(rC);

                        Logs.Log(client, rC, configJson.GuildedLogsChannel);
                    }
                    catch (Exception)
                    {
                        await msgCreated.ReplyAsync("There was an error tring to complete the request.");
                    }
                });
        }
    }
}
