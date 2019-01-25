CREATE TABLE [dbo].[Topics]
(
	[TopicId] INT IDENTITY(0,1) NOT NULL, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Ranking] INT NULL, 
    [Views] INT NOT NULL, 
    [Category] NVARCHAR(50) NULL, 
    [Timestamp] DATETIME2 NOT NULL, 
	CONSTRAINT [PK_dbo.Topics] PRIMARY KEY CLUSTERED([TopicId] ASC)
)

INSERT INTO [dbo].[Topics] (Title, Views, Timestamp) VALUES 
('Self Driving Trucks', 0, '12/04/2017 09:04:22'),
('Antartica Hiker', 20, '12/04/2018 10:04:22'),
('New Abortion Laws', 50, '01/04/2019 09:04:22')