### NOTICE ###
YOU MUST HAVE A KEYAUTH SELLER SUBSCRIPTION (19.99/yr) IN ORDER TO USE THIS!

### SETUP ###
VIEW THE CONFIG.JSON FILE AND ENTER THE INFORMATION THAT IS ASKS FOR.

### DISCLAIMER ###
I may have forgot to add a few params... however, you can view them in the source or for easier/quicker access you can view the docs site: https://keyauth.readme.io

If you notice any bugs, feel free to make a pull request or let me know and I'll fix it when I get the chance. 

!CreateLicense <format> <expiry> <mask> <level> <amount>
!VerifyLicense <key>
!Activate <user> <key> <pass>
!DeleteLicense <key> <userToo, 0 = no, 1 = yes>
!DeleteUnusedLicense
!DeleteUsedLicenses
!DeleteAllLicenses
!AddTimeToUnusedLicenses <time>
!BanLicense <key> <reason> <reason> <userToo 0 = no, 1 = yes>

!AddNewBlacklist <ip> <hwid>
!DeleteAllBlacklists
!DeleteBlacklist <data> <blacktype IP or HWID>
!FetchAllBlacklists

!CreateNewChatChannel <name> <delay> 
!ClearChannelMessages <name>
!FetchChatChannels
!FetchChatMutes
!MuteUser
!UnmuteUser

!CreateWebhook <baseurl> <ua> <authed>

!CreateNewResellerorManager <role> <user> <pass> <keylevels> <email> <perms>
!DeleteResellerOrManager <user>

!DeleteAllFiles
!DeleteFile
!GetAllFiles
!UploadFile <Direct Download Link>

!EndAllSessions
!EndSession <SessionID>
!FetchAllSessions

!AddHash <hash>
!EditSettings <enabled true/false> <hwicheck true/false> <version> <new update download link> <webhook> <resellerstore> <usernametaken msg> <keynotfound msg> <keypaused msg> <nosublevel msg> <usernamenotfound msg> <hwidmismatch msg> <noactivesubs msg> <keyexpired msg> <sellixsecret> <dayproduct> <weekproduct> <monthproduct> <lifetimeproduct>
!GetSettings
!PauseApplication
!ResetHash

!CreateSub <name> <sub> 
!DeleteSub <name>
!EditSub <sub> <level> 
!FetchAllSubs

!DeleteWhitelist
!AddWhitelist

!CreateNewWebloaderButton
!DeleteWebloaderButton
!FetchAllWebloaderButton

!CreateNewVar <name> <data> <authed>
!DeleteVar <name>
!DeleteAllVars
!RetrieveVar
!EditVar <varid> <data>
!FetchAllVars


!AddHwidToUser <user> <hwid> 
!BanUser <user> <reason>
!ChangePassword
!CountSubs
!CreateUser <user> <sub> <expiry> <pass>
!DeleteAllUsers
!DeleteAllUserVarsWithName <name>
!DeleteUser <user>
!DeleteExpiredUsers
!DeleteUsersSub
!DeleteUsersVar
!ExtendUser
!FetchAllUsernames
!FetchAllUsers
!FetchAllUserVars
!FetchUserVarData
!ResetAllUsersHWID
!ResetUserHWID <user>
!FetchUserData <user>
!SetUsersCooldown <user> <cooldown in seconds>
!SetUsersVar <user> <var> <data> <readOnly>
!SubtractFromUserSub <user> <sub> <seconds>
!UnbanUser <user>
!VerifyUserExists <user>