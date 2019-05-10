CREATE TABLE [dbo].[Team] (
    [TeamId] INT IDENTITY(1,1) NOT NULL,
    [UserId] INT NULL , 
    [TeamMemId] INT NULL , 
    PRIMARY KEY CLUSTERED ([TeamId])
);

