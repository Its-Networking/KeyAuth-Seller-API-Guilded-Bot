﻿using Guilded;
using Guilded_KeyAuth_Seller_Bot.Connection;
using Guilded_KeyAuth_Seller_Bot.Misc;
using Newtonsoft.Json;
using System.Net;
using System.Reactive.Linq;
using System.Text;

namespace Guilded_KeyAuth_Seller_Bot.Commands.Chats
{
    internal class DeleteExistingChatChannel
    {
        public static void Chats_DeleteExistingChatChannel(GuildedBotClient client, string prefix)
        {
            client.MessageCreated
                .Where(msgCreated => msgCreated.Content.StartsWith(prefix + "DeleteExistingChatChannel"))
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
                        string name = sections[1];

                        if (string.IsNullOrEmpty(name))
                        {
                            await msgCreated.ReplyAsync("Invalid Usage. Usage: !DeleteExistingChatChannel <channelName>");
                        }
                        else
                        {
                             
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(configJson.SellerAPILink + configJson.SellerKey + 
                                "&type=" + configJson.Type_DeleteExistingChatChannel + 
                                "&name=" + name);
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
