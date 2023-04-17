using Guilded;
using Guilded_KeyAuth_Seller_Bot.Commands.Blacklists;
using Guilded_KeyAuth_Seller_Bot.Commands.Chats;
using Guilded_KeyAuth_Seller_Bot.Commands.CoAccounts;
using Guilded_KeyAuth_Seller_Bot.Commands.Files;
using Guilded_KeyAuth_Seller_Bot.Commands.Licenses;
using Guilded_KeyAuth_Seller_Bot.Commands.Sessions;
using Guilded_KeyAuth_Seller_Bot.Commands.Settings;
using Guilded_KeyAuth_Seller_Bot.Commands.Subscriptions;
using Guilded_KeyAuth_Seller_Bot.Commands.Users;
using Guilded_KeyAuth_Seller_Bot.Commands.Variables;
using Guilded_KeyAuth_Seller_Bot.Commands.Webhooks;
using Guilded_KeyAuth_Seller_Bot.Commands.WebLoaderButtons;
using Guilded_KeyAuth_Seller_Bot.Commands.Whitelists;
using Guilded_KeyAuth_Seller_Bot.Connection;
using Guilded_KeyAuth_Seller_Bot.Misc;
using Newtonsoft.Json;
using Spectre.Console;
using System.ComponentModel;
using System.Text;


#region UI Display
 AnsiConsole.Write(
    new FigletText("KeyAuth Seller Panel")
        .LeftJustified()
        .Color(Color.Blue3));

var rule = new Rule();
AnsiConsole.Write(rule);
#endregion

var json = string.Empty;

using (var fs = File.OpenRead("config.json"))
using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
    json = await sr.ReadToEndAsync().ConfigureAwait(false);

 var configJson = JsonConvert.DeserializeObject<Json>(json);
 await using var client = new GuildedBotClient(configJson.BotToken);

client.Prepared
    .Subscribe(me =>
    AnsiConsole.WriteLine(DateTime.Now + $"> Successfully Connected :: BotID: {client.Id}"));

#region Licenses
CreateLicense.License_CreateLicense(client, configJson.Prefix);
VerifyLicense.License_VerifyLicense(client, configJson.Prefix);
Activate.License_Activate(client, configJson.Prefix);
DeleteLicense.License_DeleteLicense(client, configJson.Prefix);
DeleteUnusedLicense.License_DeleteLicense(client, configJson.Prefix);
DeleteUsedLicenses.License_DeleteUsedLicenses(client, configJson.Prefix);
FetchAllLicense.License_FetchAllLicenses(client, configJson.Prefix);
AddTimeToUnusedLicense.License_AddTimeToUnusedLicenses(client, configJson.Prefix);
BanLicense.License_BanLicense(client, configJson.Prefix);
UnbanLicense.License_UnBanLicense(client, configJson.Prefix);
RetrieveLicenseFromUser.License_RetrieveLicenseFromUser(client, configJson.Prefix);
SetNote.License_SetNote(client, configJson.Prefix);
GetNote.License_GettNote(client, configJson.Prefix);
#endregion

#region Users
AddHWIDToUser.Users_AddHwidToUser(client, configJson.Prefix);
BanUser.Users_BanUser(client, configJson.Prefix);
ChangeUsersPassword.Users_ChangePassword(client, configJson.Prefix);
CountSubscriptions.Users_CountSubs(client, configJson.Prefix);
CreateNewUser.Users_CreateUser(client, configJson.Prefix);
DeleteAllUSers.Users_DeleteAllUsers(client, configJson.Prefix);
DeleteAllUserVarsWithName.Users_DeleteAllUserVarsWithName(client, configJson.Prefix);
DeleteExistingUser.Users_DeleteUser(client, configJson.Prefix);
DeleteExpiredUsers.Users_DeleteExpiredUsers(client, configJson.Prefix);
DeleteUsersSub.Users_DeleteUsersSub(client, configJson.Prefix);
DeleteUserVar.Users_DeleteUsersVar(client, configJson.Prefix);
ExtendUsers.Users_ExtendUser(client, configJson.Prefix);
FetchAllUsernames.Users_FetchAllUsernames(client, configJson.Prefix);
FetchAllUsers.Users_FetchAllUsers(client, configJson.Prefix);
FetchAllUsersVars.Users_FetchAllUserVars(client, configJson.Prefix);
GetUserVarData.Users_FetchUserVarData(client, configJson.Prefix);
ResetAllUsersHWID.Users_ResetAllUsersHWID(client, configJson.Prefix);
ResetUSERsHwid.Users_ResetUserHWID(client, configJson.Prefix);
SetUsersCooldown.Users_SetUsersCooldown(client, configJson.Prefix);
SetUserVar.Users_SetUsersVar(client, configJson.Prefix);
SubtractFromUserSub.Users_SubtractFromUserSub(client, configJson.Prefix);
UnbanUser.Users_UnbanUser(client, configJson.Prefix);
VerifyUserExists.Users_VerifyUserExists(client, configJson.Prefix);
#endregion

#region Subscriptions
CreateNewSub.Sub_CreateNewSub(client, configJson.Prefix);
DeleteExistingSub.Sub_DeleteSub(client, configJson.Prefix);
EditSub.Sub_EditSub(client, configJson.Prefix);
FetchAllSub.Sub_FetchAllSubs(client, configJson.Prefix);
#endregion

#region Chats
ClearChannelMessages.Chats_ClearChannelMessages(client, configJson.Prefix);
CreateNewChatChannel.Chats_CreateNewChatChannel(client, configJson.Prefix);
DeleteExistingChatChannel.Chats_DeleteExistingChatChannel(client, configJson.Prefix);
FetchAllChannels.Chats_FetchAllChannels(client, configJson.Prefix);
FetchAllMutes.Chats_FetchChatMutes(client, configJson.Prefix);
MuteUser.Chats_MuteUser(client, configJson.Prefix);
UnmuteUser.Chats_UnmuteUser(client, configJson.Prefix);
#endregion

#region Sessions
EndAllSessions.Sessions_EndAllSessions(client, configJson.Type_EndAllSessions);
EndSelectedSession.Sessions_EndSession(client, configJson.Type_EndSelectedSession);
GetAllSessions.Sessions_FetchAllSessions(client, configJson.Type_GetAllSessions);
#endregion

#region Webhooks
Webhooks.Webhooks_CreateNewWebhook(client, configJson.Prefix);
#endregion

#region Files
DeleteAllFiles.Files_DeleteAllFiles(client, configJson.Prefix);
DeleteExistingFile.Files_DeleteFile(client, configJson.Prefix);
GetAllFiles.Files_GetAllFiles(client, configJson.Prefix);
#endregion

#region Variables
CreateNewVar.Vars_CreateNewVar(client, configJson.Prefix);
DeleteAllVars.Vars_DeleteAllVars(client, configJson.Prefix);
DeleteVar.Var_DeleteVar(client, configJson.Prefix);
EditVar.Var_EditVar(client, configJson.Prefix);
GetAllVars.Var_FetchAllVars(client, configJson.Prefix);
RetrieveVar.Var_RetrieveVar(client, configJson.Prefix);
#endregion

#region Blacklists
AddNewBlacklist.Blacklist_AddNewBlacklist(client, configJson.Prefix);
DeleteExistingBlacklist.Blacklist_DeleteBlacklist(client, configJson.Prefix);
DeleteAllBlacklists.Blacklist_DeleteAllBlacklists(client, configJson.Prefix);
GetAllBlacklists.Blacklist_GetAllBlacklist(client, configJson.Prefix);
#endregion

#region Whitelists
DeleteExistingWhitelist.Whitelist_DeleteWhitelist(client, configJson.Prefix);
AddNewWhitelists.Whitelist_AddWhitelist(client, configJson.Prefix);
#endregion

#region Settings
AddHash.Settings_AddHash(client, configJson.Prefix);
EditSettings.Settings_EditSettings(client, configJson.Prefix);
GetCurrentSettings.Settings_GetSettings(client, configJson.Prefix);
Resethash.Settings_ResetHash(client, configJson.Prefix);
UnpauseApplication.Settings_UnpauseApplication(client, configJson.Prefix);
#endregion

#region Reseller/Manager Accounts
CreateNewResellerManagerAccount.RM_CreateNewResellerOrManager(client, configJson.Prefix);
DeleteResellerManagerAccount.RM_DeleteResellerorManagerAccount(client, configJson.Prefix);
#endregion

#region Web Loader Buttons
CreateNewWebLoaderButton.Webloader_CreateNewWebloaderButton(client, configJson.Prefix);
DeleteWebLoaderButton.Webloader_DeleteWebloaderButton(client, configJson.Prefix);
GetAllWebLoaderButtons.Webloader_FetchAllWebloaderButton(client, configJson.Prefix);
#endregion

await client.ConnectAsync();

await Task.Delay(-1);
