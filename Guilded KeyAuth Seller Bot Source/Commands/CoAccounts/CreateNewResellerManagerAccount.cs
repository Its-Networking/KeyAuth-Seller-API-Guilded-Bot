using Guilded;
using Guilded_KeyAuth_Seller_Bot.Connection;
using Guilded_KeyAuth_Seller_Bot.Misc;
using Newtonsoft.Json;
using System.Net;
using System.Reactive.Linq;
using System.Text;

namespace Guilded_KeyAuth_Seller_Bot.Commands.CoAccounts
{
    internal class CreateNewResellerManagerAccount
    {
        public static void RM_CreateNewResellerOrManager(GuildedBotClient client, string prefix)
        {
            client.MessageCreated
                .Where(msgCreated => msgCreated.Content.StartsWith(prefix + "CreateNewResellerorManager"))
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
                        string role = sections[1],
                        user = sections[2],
                        pass = sections[3],
                        keylevels = sections[4],
                        email = sections[5],
                        perms = sections[6];

                        if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(keylevels) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(perms))
                        {
                            await msgCreated.ReplyAsync("Invalid Usage. Usage: !CreateNewResellerorManager <role> <username> <pass> <keylevels> <email> <perms>)");
                        }
                        else                         
                        {
                             
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(configJson.SellerAPILink + configJson.SellerKey +
                                "&type=" + configJson.Type_CreateNewResellerManager +
                                "&role=" + role +
                                "&user=" + user +
                                "&pass=" + pass +
                                "&keylevels=" + keylevels + 
                                "&email=" + email + 
                                "&perms=" + perms);
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
