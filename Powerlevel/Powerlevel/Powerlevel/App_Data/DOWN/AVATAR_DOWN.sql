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
