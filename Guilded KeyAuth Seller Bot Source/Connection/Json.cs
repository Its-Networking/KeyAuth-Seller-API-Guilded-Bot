using Newtonsoft.Json;

namespace Guilded_KeyAuth_Seller_Bot.Connection
{
    public struct Json
    {
        //Main
        [JsonProperty("BotToken")]
        public string BotToken { get; private set; }

        [JsonProperty("SellerKey")]
        public string SellerKey { get; private set; }

        [JsonProperty("GuildedLogsChannel")]
        public string GuildedLogsChannel { get; private set; }

        [JsonProperty("Prefix")]
        public string Prefix { get; private set; }

        [JsonProperty("SellerAPILink")]
        public string SellerAPILink { get; private set; }

        //License Functions
        [JsonProperty("Type_Add")]
        public string Type_Add { get; private set; }

        [JsonProperty("Type_Verify")]
        public string Type_Verify { get; private set; }

        [JsonProperty("Type_Activate")]
        public string Type_Activate { get; private set; }

        [JsonProperty("Type_Del")]
        public string Type_Del { get; private set; }

        [JsonProperty("Type_DelUnused")]
        public string Type_DelUnused { get; private set; }

        [JsonProperty("Type_DelUsed")]
        public string Type_DelUsed { get; private set; }

        [JsonProperty("Type_DelAllLicenses")]
        public string Type_DelAllLicenses { get; private set; }

        [JsonProperty("Type_FetchAllLicenses")]
        public string Type_FetchAllLicenses { get; private set; }

        [JsonProperty("Type_AddTimeToUnusedLicense")]
        public string Type_AddTimeToUnusedLicense { get; private set; }

        [JsonProperty("Type_BanLicense")]
        public string Type_BanLicense { get; private set; }

        [JsonProperty("Type_UnbanLicense")]
        public string Type_UnbanLicense { get; private set; }

        [JsonProperty("Type_RetrieveLicenseFromUser")]
        public string Type_RetrieveLicenseFromUser { get; private set; }

        [JsonProperty("Type_SetNote")]
        public string Type_SetNote { get; private set; }

        [JsonProperty("Type_GetNote")]
        public string Type_GetNote { get; private set; }

        //User Functions
        [JsonProperty("Type_AddUser")]
        public string Type_AddUser { get; private set; }

        [JsonProperty("Type_DeleteExistingUser")]
        public string Type_DeleteExistingUser { get; private set; }

        [JsonProperty("Type_DeleteExpiredUser")]
        public string Type_DeleteExpiredUser { get; private set; }

        [JsonProperty("Type_ResetUsersHWID")]
        public string Type_ResetUserHWID { get; private set; }

        [JsonProperty("Type_SetUserVariable")]
        public string Type_SetUserVariable { get; private set; }

        [JsonProperty("Type_GetUserVariableData")]
        public string Type_GetUserVariableData { get; private set; }

        [JsonProperty("Type_BanUser")]
        public string Type_BanUser { get; private set; }

        [JsonProperty("Type_UnbanUser")]
        public string Type_UnbanUser { get; private set; }

        [JsonProperty("Type_DeleteUserVariable")]
        public string Type_DeleteUserVariable { get; private set; }

        [JsonProperty("Type_DeleteAllUserVariablesWithName")]
        public string Type_DeleteAllUserVariablesWithName { get; private set; }

        [JsonProperty("Type_DeleteUserSub")]
        public string Type_DeleteUserSub { get; private set; }

        [JsonProperty("Type_DeleteAllUsers")]
        public string Type_DeleteAllUsers { get; private set; }

        [JsonProperty("Type_SubtractFromUsers")]
        public string Type_SubtractFromUsers { get; private set; }

        [JsonProperty("Type_ResetAllUsersHWID")]
        public string Type_ResetAllUsersHWID { get; private set; }

        [JsonProperty("Type_VerifyUserExits")]
        public string Type_VerifyUserExists { get; private set; }

        [JsonProperty("Type_AddHWIDToUser")]
        public string Type_AddHWIDToUser { get; private set; }

        [JsonProperty("Type_FetchAllUsers")]
        public string Type_FetchAllUsers { get; private set; }

        [JsonProperty("Type_ChangeUsersPassword")]
        public string Type_ChangeUsersPassword { get; private set; }

        [JsonProperty("Type_FetchAllUsersVars")]
        public string Type_FetchAllUsersVars { get; private set; }

        [JsonProperty("Type_RetrieveUserData")]
        public string Type_RetrieveUserData { get; private set; }

        [JsonProperty("Type_FetchAllUsernames")]
        public string Type_FetchAllUsernames { get; private set; }

        [JsonProperty("Type_CountSubscriptions")]
        public string Type_CountSubscriptions { get; private set; }

        [JsonProperty("Type_SetUsersCooldown")]
        public string Type_SetUsersCooldown { get; private set; }

        [JsonProperty("Type_ExtendUsers")]
        public string Type_ExtendUsers { get; private set; }

        //Subscription Functions
        [JsonProperty("Type_CreateNewSubscription")]
        public string Type_CreateNewSubscription { get; private set; }

        [JsonProperty("Type_DeleteExistingSubscription")]
        public string Type_DeleteExistingSubscription { get; private set; }

        [JsonProperty("Type_FetchAllSubscriptions")]
        public string Type_FetchAllSubscriptions { get; private set; }

        [JsonProperty("Type_EditSubs")]
        public string Type_EditSubs { get; private set; }

        //Chats Functions
        [JsonProperty("Type_CreateNewChatChannel")]
        public string Type_CreateNewChatChannel { get; private set; }

        [JsonProperty("Type_DeleteExistingChatChannel")]
        public string Type_DeleteExistingChatChannel { get; private set; }

        [JsonProperty("Type_EditChannel")]
        public string Type_EditChannel { get; private set; }

        [JsonProperty("Type_ClearChannelMessages")]
        public string Type_ClearChannelMessages { get; private set; }

        [JsonProperty("Type_MuteUser")]
        public string Type_MuteUser { get; private set; }

        [JsonProperty("Type_UnmuteUser")]
        public string Type_UnmuteUser { get; private set; }

        [JsonProperty("Type_FetchAllChannels")]
        public string Type_FetchAllChannels { get; private set; }

        [JsonProperty("Type_FetchAllMutes")]
        public string Type_FetchAllMutes { get; private set; }

        //Session Functions
        [JsonProperty("Type_EndSelectedSession")]
        public string Type_EndSelectedSession { get; private set; }

        [JsonProperty("Type_EndAllSessions")]
        public string Type_EndAllSessions { get; private set; }

        [JsonProperty("Type_GetAllSessions")]
        public string Type_GetAllSessions { get; private set; }

        //Webhooks Functions
        [JsonProperty("Type_CreateNewWebhook")]
        public string Type_CreateNewWebhook { get; private set; }

        //Files Functions
        [JsonProperty("Type_UploadNewFile")]
        public string Type_UploadNewFile { get; private set; }

        [JsonProperty("Type_DeleteFile")]
        public string Type_DeleteFile { get; private set; }

        [JsonProperty("Type_DeleteAllFiles")]
        public string Type_DeleteAllFiles { get; private set; }

        [JsonProperty("Type_GetAllFiles")]
        public string Type_GetAllFiles { get; private set; }

        //Variables Functions
        [JsonProperty("Type_CreateNewVar")]
        public string Type_CreateNewVar { get; private set; }

        [JsonProperty("Type_EditVar")]
        public string Type_EditVar { get; private set; }

        [JsonProperty("Type_RetrieveVar")]
        public string Type_RetrieveVar { get; private set; }

        [JsonProperty("Type_GetAllVars")]
        public string Type_GetAllVars { get; private set; }

        [JsonProperty("Type_DeleteVar")]
        public string Type_DeleteVar { get; private set; }

        [JsonProperty("Type_DeleteAllVars")]
        public string Type_DeleteAllVars { get; private set; }

        //Blacklists Functions
        [JsonProperty("Type_AddNewBlacklist")]
        public string Type_AddNewBlacklist { get; private set; }

        [JsonProperty("Type_DeleteExistingBlacklist")]
        public string Type_DeleteExistingBlacklist { get; private set; }

        [JsonProperty("Type_DeleteAllBlacklists")]
        public string Type_DeleteAllBlacklists { get; private set; }

        [JsonProperty("Type_GetAllBlacklists")]
        public string Type_GetAllBlacklists { get; private set; }

        //Whitelists Functions
        [JsonProperty("Type_AddNewWhitelist")]
        public string Type_AddNewWhitelist { get; private set; }

        [JsonProperty("Type_DeleteExistingWhitelist")]
        public string Type_DeleteExistingWhitelist { get; private set; }

        //Settings Functions
        [JsonProperty("Type_GetCurrentSettings")]
        public string Type_GetCurrentSettings { get; private set; }

        [JsonProperty("Type_EditSettings")]
        public string Type_EditSettings { get; private set; }

        [JsonProperty("Type_ResetHash")]
        public string Type_ResetHash { get; private set; }

        [JsonProperty("Type_AddHash")]
        public string Type_AddHash { get; private set; }

        [JsonProperty("Type_PauseApplication")]
        public string Type_PauseApplication { get; private set; }

        [JsonProperty("Type_UnpauseApplication")]
        public string Type_UnpauseApplication { get; private set; }

        //Resller/Manager Functions
        [JsonProperty("Type_CreateNewResellerManager")]
        public string Type_CreateNewResellerManager { get; private set; }

        [JsonProperty("Type_DeleteResellerManager")]
        public string Type_DeleteResellerManager { get; private set; }

        //Webloader Button Functions
        [JsonProperty("Type_GetAllWebLoaderButtons")]
        public string Type_GetAllWebLoaderButtons { get; private set; }

        [JsonProperty("Type_AddButtons")]
        public string Type_AddButtons { get; private set; }

        [JsonProperty("Type_DeleteWebLoaderButton")]
        public string Type_DeleteWebLoaderButton { get; private set; }
    }
}