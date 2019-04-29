/*Drop Primary key*/
ALTER TABLE [dbo].[Avatar] DROP CONSTRAINT [PK_dbo.Avatar]
GO
/*Drop Foreign keys*/
ALTER TABLE [dbo].[Avatar] DROP CONSTRAINT [FK_dbo.Avatar_User]
GO

/*Drop Table */
DROP TABLE IF EXISTS [dbo].[Avatar]
GO