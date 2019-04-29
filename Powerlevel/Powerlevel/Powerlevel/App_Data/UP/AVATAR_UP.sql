/*
This file is used to create the table that will track the current avatars for users
*/
CREATE TABLE [dbo].[UserAvatar]
(
    [UAId] INT IDENTITY(1,1) NOT NULL,
    [UserId] INT NOT NULL,
    [Body] NVARCHAR(64)  NULL DEFAULT 'human1',
    [Armor] NVARCHAR(64)   NULL DEFAULT 'none',
    [Weapon] NVARCHAR(64)  NULL DEFAULT 'none',
    CONSTRAINT [PK_dbo.UserAvatar] PRIMARY KEY CLUSTERED ([UAId] ASC),
    CONSTRAINT [FK_dbo.UserAvatar_User] FOREIGN KEY (UserId) REFERENCES [User](UserId) /* [User] referenced with brackets due to VS built-in "User" creating conflict */
     ON DELETE CASCADE
      ON UPDATE CASCADE,
);

CREATE TABLE [dbo].[Avatar]
(
    [AvaId] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(64) NOT NULL,
    [Type] NVARCHAR(64) NOT NULL,
    CONSTRAINT [PK_dbo.Avatar] PRIMARY KEY CLUSTERED ([AvaId] ASC)
);