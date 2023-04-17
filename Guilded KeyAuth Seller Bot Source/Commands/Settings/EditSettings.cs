using Guilded;
using Guilded_KeyAuth_Seller_Bot.Connection;
using Guilded_KeyAuth_Seller_Bot.Misc;
using Newtonsoft.Json;
using System.Net;
using System.Reactive.Linq;
using System.Text;

namespace Guilded_KeyAuth_Seller_Bot.Commands.Settings
{
    internal class EditSettings
    {
        public static void Settings_EditSettings(GuildedBotClient client, string prefix)
        {
            client.MessageCreated
                .Where(msgCreated => msgCreated.Content.StartsWith(prefix + "EditSettings"))
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
                        string enabled = sections[1],
                        hwidcheck = sections[2],
                        ver = sections[3],
                        download = sections[4],
                        webhook = sections[5],
                        resellerstore = sections[6],
                        appdisabled = sections[7],
                        usernametaken = sections[8],
                        keynotfound = sections[9],
                        keypaused = sections[10],
                        nosublevel = sections[11],
                        usernamenotfound = sections[12],
                        passmismatch = sections[13],
                        hwidmismatch = sections[14],
                        noactivesubs = sections[15],
                        keyexpired = sections[16],
                        sellixsecret = sections[17],
                        dayproduct = sections[18],
                        weekproduct = sections[19],
                        monthproduct = sections[20],
                        lifetimeproduct = sections[21];

                        if (string.IsNullOrEmpty(enabled) || string.IsNullOrEmpty(hwidcheck) || string.IsNullOrEmpty(ver) || string.IsNullOrEmpty(download) || string.IsNullOrEmpty(webhook) || string.IsNullOrEmpty(resellerstore) || string.IsNullOrEmpty(appdisabled) || string.IsNullOrEmpty(usernametaken) || string.IsNullOrEmpty(keynotfound) || string.IsNullOrEmpty(keypaused) || string.IsNullOrEmpty(nosublevel) || string.IsNullOrEmpty(usernamenotfound) || string.IsNullOrEmpty(passmismatch) || string.IsNullOrEmpty(hwidmismatch) || string.IsNullOrEmpty(noactivesubs) || string.IsNullOrEmpty(keyexpired) || string.IsNullOrEmpty(sellixsecret) || string.IsNullOrEmpty(dayproduct) || string.IsNullOrEmpty(weekproduct) || string.IsNullOrEmpty(monthproduct) || string.IsNullOrEmpty(lifetimeproduct))
                        {
                            await msgCreated.ReplyAsync("Invalid Usage. Usage: !EditSettings <enabled true/false> <hwicheck true/false> <version> <new update download link> <webhook> <resellerstore> <usernametaken msg> <keynotfound msg> <keypaused msg> <nosublevel msg> <usernamenotfound msg> <hwidmismatch msg> <noactivesubs msg> <keyexpired msg> <sellixsecret> <dayproduct> <weekproduct> <monthproduct> <lifetimeproduct>");
                        }
                        else
                        {
                             
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(configJson.SellerAPILink + configJson.SellerKey +
                                "&type=" + configJson.Type_EditSettings +
                                "&enabled=" + enabled +
                                "&hwidcheck=" + hwidcheck +
                                "&ver=" + ver +
                                "&download=" + download + 
                                "&webhook=" + webhook + 
                                "&resellerstore=" + resellerstore +
                                "&appdisabled=" + appdisabled +
                                "&usernametaken=" + usernametaken +
                                "&keynotfound=" + keynotfound +
                                "&keypaused=" + keypaused +
                                "&nosublevel=" + nosublevel +
                                "&usernamenotfound=" + usernamenotfound +
                                "&passmismatch=" + passmismatch +
                                "&hwidmismatch=" + hwidmismatch +
                                "&noactivesubs=" + noactivesubs +
                                "&keyexpired=" + keyexpired +
                                "&sellixsecret=" + sellixsecret +
                                "&dayproduct=" + dayproduct +
                                "&weekproduct=" + weekproduct +
                                "&monthproduct=" + monthproduct +
                                "&lifetimeproduct=" + lifetimeproduct);
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
