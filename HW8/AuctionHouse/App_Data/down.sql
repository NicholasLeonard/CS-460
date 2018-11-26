ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [FK_Bids_Item]
ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [FK_Bids_Buyer]
ALTER TABLE [dbo].[Items] DROP CONSTRAINT [FK_Items_Sellers]

DROP TABLE [dbo].[Bids]
DROP TABLE [dbo].[Buyers]
DROP TABLE [dbo].[Items]
DROP TABLE [dbo].[Sellers]
GO