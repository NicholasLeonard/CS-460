/* Drop all the Avatars table */
/*Drop Primary key*/
ALTER TABLE [dbo].[AvatarUnlock] DROP CONSTRAINT [PK_dbo.AvatarUnlock]
GO

/*Drop Foreign keys*/
ALTER TABLE [dbo].[AvatarUnlock] DROP CONSTRAINT [FK_dbo.AvatarUnlock_User]
GO
ALTER TABLE [dbo].[AvatarUnlock] DROP CONSTRAINT [AvatarUnlock_Avatar]
GO

/* Drop Table */
DROP TABLE IF EXISTS [dbo].[AvatarUnlock]
GO

/*Drop Primary key*/
ALTER TABLE [dbo].[UserAvatar] DROP CONSTRAINT [PK_dbo.UserAvatar]
GO
/*Drop Foreign keys*/
ALTER TABLE [dbo].[UserAvatar] DROP CONSTRAINT [FK_dbo.UserAvatar_User]
GO

/*Drop Table */
DROP TABLE IF EXISTS [dbo].[UserAvatar]
GO

/*Drop Avatar Table */
ALTER TABLE [dbo].[Avatar] DROP CONSTRAINT [PK_dbo.Avatar]
GO

/*Drop Table */
DROP TABLE IF EXISTS [dbo].[Avatar]
GO
