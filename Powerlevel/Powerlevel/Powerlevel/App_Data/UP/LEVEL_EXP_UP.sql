CREATE TABLE [dbo].[LevelExp]
(
    [LevelExpId] INT IDENTITY (1, 1) NOT NULL,
    [Level]      INT DEFAULT ((1)) NOT NULL,
    [Exp]        INT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.LevelExp] PRIMARY KEY CLUSTERED ([LevelExpId] ASC)
)
