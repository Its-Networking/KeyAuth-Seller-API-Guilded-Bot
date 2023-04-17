﻿using Guilded;
using Guilded_KeyAuth_Seller_Bot.Connection;
using Guilded_KeyAuth_Seller_Bot.Misc;
using Newtonsoft.Json;
using System.Net;
using System.Reactive.Linq;
using System.Text;

namespace Guilded_KeyAuth_Seller_Bot.Commands.Users
{
    internal class SetUserVar
    {
        public static void Users_SetUsersVar(GuildedBotClient client, string prefix)
        {
            client.MessageCreated
                .Where(msgCreated => msgCreated.Content.StartsWith(prefix + "SetUsersVar"))
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
                        var = sections[2],
                        data = sections[3],
                        readOnly = sections[4];

                        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(var) || string.IsNullOrEmpty(data) || string.IsNullOrEmpty(readOnly))
                        {
                            await msgCreated.ReplyAsync("Invalid Usage. Usage: !SetUsersVar <user> <var> <data> <readOnly 0 = no, 1 = yes>");
                        }
                        else
                        {
                             
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(configJson.SellerAPILink + configJson.SellerKey +
                                "&type=" + configJson.Type_SetUserVariable +
                                "&user=" + user +
                                "&var=" + var +
                                "&data=" + data +
                                "&readOnly=" + readOnly);
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
