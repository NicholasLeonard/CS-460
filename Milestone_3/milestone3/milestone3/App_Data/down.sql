ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_Topics]
ALTER TABLE [dbo].[Topics] DROP CONSTRAINT [FK_Topics_Categories]

DROP TABLE [dbo].[Categories]
DROP TABLE [dbo].[Topics]
DROP TABLE [dbo].[Comments]
GO