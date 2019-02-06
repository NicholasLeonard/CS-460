CREATE TABLE [dbo].[Categories]
(
	[CategoryID] INT IDENTITY(0,1) NOT NULL,
	[CategoryName] NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);

CREATE TABLE [dbo].[Topics]
(
	[TopicId] INT IDENTITY(0,1) NOT NULL, 
    [Title] NVARCHAR(50) NOT NULL,
	[WebURL] NVARCHAR(500) NOT NULL,
    [Ranking] INT NOT NULL, 
    [Views] INT NOT NULL, 
    [Timestamp] DATETIME2 NOT NULL, 
	[CategoryID] INT NOT NULL,

	CONSTRAINT [PK_dbo.Topics] PRIMARY KEY CLUSTERED([TopicId] ASC),
	CONSTRAINT [FK_dbo.Categories] FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE [dbo].[Comments]
(
	[CommentId] INT IDENTITY(0,1),
	[Content] NVARCHAR(1000),
	[Ranking] INT NULL,
	[Timestamp] DATETIME2 NOT NULL,
	[TopicId] INT,
	CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED ([CommentId] ASC),
	CONSTRAINT [Fk_Comments_Topics] FOREIGN KEY ([TopicId]) REFERENCES [Topics]([TopicId]) 
);

CREATE TABLE [dbo].[User]
(
	[Userid] INT IDENTITY(0,1) NOT NULL, 
	[Username] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(100) NOT NULL,
	[Pseudonym] NVARCHAR(50) NOT NULL,
	[PaymentInformation] NVARCHAR(100) NULL
	CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED([Userid] ASC)
);



INSERT INTO	[dbo].[Categories] (CategoryName) VALUES
	('Travel'),
	('Politics'),
	('Technology'),
	('Business'),
	('Health'),
	('Entertainment'),
	('Sports')

INSERT INTO [dbo].[Topics] (Title, WebURL, Ranking, Views, Timestamp, CategoryID) VALUES 
	('Self Driving Trucks', 'https://www.atbs.com/knowledge-hub/self-driving-trucks-are-truck-drivers-out-of-a-jo', 0, 0, '12/04/2017 09:04:22', 2),
	('Antarctica Hiker', 'https://www.cnn.com/2018/12/27/world/colin-obrady-antarctica-solo-trip-trnd/index.html', 59, 20, '12/04/2018 10:04:22', 0),
	('New Abortion Laws', 'https://www.bbc.com/news/world-us-canada-46994583', 32, 50, '01/04/2019 09:04:22', 1)

	INSERT INTO	[dbo].[User] (Username, Password, Email, Pseudonym, PaymentInformation) VALUES
	('tester', 'test', 'tester@admin.com', 'Admin', '1111-1111-1111-1111')