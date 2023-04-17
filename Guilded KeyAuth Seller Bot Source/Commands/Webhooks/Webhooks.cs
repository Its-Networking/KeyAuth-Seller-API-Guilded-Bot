using Guilded;
using Guilded_KeyAuth_Seller_Bot.Connection;
using Guilded_KeyAuth_Seller_Bot.Misc;
using Newtonsoft.Json;
using System.Net;
using System.Reactive.Linq;
using System.Text;

namespace Guilded_KeyAuth_Seller_Bot.Commands.Webhooks
{
    internal class Webhooks
    {
        public static void Webhooks_CreateNewWebhook(GuildedBotClient client, string prefix)
        {
            client.MessageCreated
                .Where(msgCreated => msgCreated.Content.StartsWith(prefix + "CreateWebhook"))
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
                        string baseurl = sections[1],
                        ua = sections[2],
                        authed = sections[3];

                        if (string.IsNullOrEmpty(baseurl) || string.IsNullOrEmpty(ua) || string.IsNullOrEmpty(authed))
                        {
                            await msgCreated.ReplyAsync("Invalid Usage. Usage: !CreateNewWebhook <baseurl> <ua> <authed 0 = false 1 = true>)");
                        }
                        else
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(configJson.SellerAPILink + configJson.SellerKey + 
                                "&type=" + configJson.Type_CreateNewWebhook + 
                                "&baseurl=" + baseurl + 
                                "&ua=" + ua + 
                                "&authed=" + authed);
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
