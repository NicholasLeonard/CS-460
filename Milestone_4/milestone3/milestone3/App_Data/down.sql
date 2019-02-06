ALTER TABLE [dbo].[Topics] DROP CONSTRAINT [FK_dbo.Categories]
ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [Fk_Comments_Topics]
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [PK_dbo.Categories]
ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [PK_dbo.Comments]
ALTER TABLE [dbo].[Topics] DROP CONSTRAINT [PK_dbo.Topics]
ALTER TABLE [dbo].[User] DROP CONSTRAINT [PK_dbo.User]
DROP TABLE [dbo].[Categories]
DROP TABLE [dbo].[Topics]
DROP TABLE [dbo].[User]
DROP TABLE [dbo].[Comments]

GO