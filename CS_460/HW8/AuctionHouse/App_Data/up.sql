CREATE TABLE [dbo].[Buyers]
(
	[BuyerId] INT IDENTITY(0,1) NOT NULL,
    [BuyerName] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_dbo.Buyers] PRIMARY KEY CLUSTERED([BuyerId] ASC)
);

CREATE TABLE [dbo].[Sellers]
(
	[SellerId] INT IDENTITY(0,1) NOT NULL,
    [SellerName] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_dbo.Sellers] PRIMARY KEY CLUSTERED([SellerId] ASC)
);

CREATE TABLE [dbo].[Items]
(
	[ItemId] INT IDENTITY(0,1) NOT NULL, 
    [ItemName] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,
	[Seller] INT NOT NULL,
	CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED([ItemId] ASC),
    CONSTRAINT [FK_Items_Sellers] FOREIGN KEY ([Seller]) REFERENCES [Sellers]([SellerId])
);

CREATE TABLE [dbo].[Bids]
(
	[BidId] INT IDENTITY(0,1) NOT NULL,
	[Item] INT NOT NULL,
	[Buyer] INT NOT NULL, 
    [Price] DECIMAL NOT NULL, 
    [TimeStamp] DATETIME2 NOT NULL,
	CONSTRAINT [PK-dbo.Bids] PRIMARY KEY CLUSTERED([BidId] ASC),
    CONSTRAINT [FK_Bids_Item] FOREIGN KEY ([Item]) REFERENCES [Items]([ItemId]), 
    CONSTRAINT [FK_Bids_Buyer] FOREIGN KEY ([Buyer]) REFERENCES [Buyers]([BuyerId])	
);

INSERT INTO [dbo].[Buyers] (BuyerName) VALUES ('Jane Stone'),('Tom McMasters'),('Otto Vanderwall')
INSERT INTO [dbo].[Sellers] (SellerName) VALUES ('Gayle Hardy'),('Lyle Banks'),('Pearl Greene')
INSERT INTO [dbo].[Items] (ItemName, Description, Seller) VALUES
('Abraham Lincoln Hammer', 'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 2),
('Albert Einsteins Telescope', 'A brass telescope owned by Albert Einstein in Germany, circa 1927', 0),
('Bob Dylan Love Poems', 'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 1)
INSERT INTO [dbo].[Bids] (Item, Buyer, Price, TimeStamp) VALUES
(0, 2,250000,'12/04/2017 09:04:22'),
(2,0,95000,'12/04/2017 08:44:03')
GO