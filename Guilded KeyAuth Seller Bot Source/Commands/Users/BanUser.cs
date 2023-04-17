﻿using Guilded;
using Guilded_KeyAuth_Seller_Bot.Connection;
using Guilded_KeyAuth_Seller_Bot.Misc;
using Newtonsoft.Json;
using System.Net;
using System.Reactive.Linq;
using System.Text;

namespace Guilded_KeyAuth_Seller_Bot.Commands.Users
{
    internal class BanUser
    {
        public static void Users_BanUser(GuildedBotClient client, string prefix)
        {
            client.MessageCreated
                .Where(msgCreated => msgCreated.Content.StartsWith(prefix + "Banuser"))
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
                        string user = sections[1],
                        reason = sections[2];

                        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(reason))
                        {
                            await msgCreated.ReplyAsync("Invalid Usage. Usage: !BanUser <user> <reason>");
                        }
                        else
                        {
                             
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(configJson.SellerAPILink + configJson.SellerKey +
                                "&type=" + configJson.Type_BanUser +
                                "&user=" + user +
                                "&reason=" + reason);
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
