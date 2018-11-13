CREATE TABLE [dbo].[Buyers]
(
    [BuyerName] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([BuyerName])
);

CREATE TABLE [dbo].[Sellers]
(
    [SellerName] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([SellerName])
);

CREATE TABLE [dbo].[Items]
(
	[Id] INT IDENTITY(0,1) NOT NULL, 
    [ItemName] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,
	[Seller] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED([Id] ASC),
    CONSTRAINT [FK_Items_ToTable] FOREIGN KEY ([Seller]) REFERENCES [Sellers]([SellerName])
);

CREATE TABLE [dbo].[Bids]
(
	[Item] INT NOT NULL,
	[Buyer] NVARCHAR(50) NOT NULL, 
    [Price] DECIMAL NOT NULL, 
    [TimeStamp] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Bids_Item] FOREIGN KEY ([Item]) REFERENCES [Items]([ID]), 
    CONSTRAINT [FK_Bids_Buyer] FOREIGN KEY ([Buyer]) REFERENCES [Buyers]([BuyerName])	
);

INSERT INTO [dbo].[Buyers] (BuyerName) VALUES ('Jane Stone'),('Tom McMasters'),('Otto Vanderwall')
INSERT INTO [dbo].[Sellers] (SellerName) VALUES ('Gayle Hardy'),('Lyle Banks'),('Pearl Greene')
INSERT INTO [dbo].[Items] (ItemName, Description, Seller) VALUES
('Abraham Lincoln Hammer', 'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 'Pearl Greene'),
('Albert Einsteins Telescope', 'A brass telescope owned by Albert Einstein in Germany, circa 1927', 'Gayle Hardy'),
('Bob Dylan Love Poems', 'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 'Lyle Banks')
INSERT INTO [dbo].[Bids] (Item, Buyer, Price, TimeStamp) VALUES
(0, 'Otto Vanderwall',250000,'12/04/2017 09:04:22'),
(2,'Jane Stone',95000,'12/04/2017 08:44:03')
GO