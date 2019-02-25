CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Height] INT NULL, 
    [Weight] INT NULL, 
    [UserName] NVARCHAR(256) NOT NULL,
)