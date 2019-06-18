/*Drop Primary key*/
ALTER TABLE [dbo].[Team] DROP CONSTRAINT [PK_dbo.Team]
GO

/*Drop Foreign key*/
ALTER TABLE [dbo].[Team] DROP CONSTRAINT [FK_dbo.Team_User]
GO

/*Drop Table*/
DROP TABLE IF EXISTS [dbo].[Team] 
GO