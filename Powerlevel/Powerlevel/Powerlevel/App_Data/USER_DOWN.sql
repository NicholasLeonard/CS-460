/*Down script for our User table*/

/*DROP PKs*/
ALTER TABLE [dbo].[User] DROP CONSTRAINT [PK_dbo.User]
GO

/*DROP user table*/
DROP TABLE IF EXISTS [dbo].[User]
GO