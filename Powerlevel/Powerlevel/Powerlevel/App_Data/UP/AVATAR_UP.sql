/*
This file is used to create the table that will track the current avatars for users
*/
CREATE TABLE [dbo].[Avatar]
(
    [AvaId] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(64) NOT NULL,
	[Imagefile] NVARCHAR(64) NOT NULL,
    [Type] NVARCHAR(64) NOT NULL,
	[Race] NVARCHAR(64) NOT NULL
    CONSTRAINT [PK_dbo.Avatar] PRIMARY KEY CLUSTERED ([AvaId] ASC)
);

/* This table is for tracking the user's currently equipped avatar */
CREATE TABLE [dbo].[UserAvatar]
(
    [UAId] INT IDENTITY(1,1) NOT NULL,
    [UserId] INT NOT NULL,
    [Body] NVARCHAR(64)  NULL DEFAULT 'human1.PNG',
    [Armor] NVARCHAR(64)   NULL DEFAULT 'none.PNG',
    [Weapon] NVARCHAR(64)  NULL DEFAULT 'none.PNG',
	[Race] NVARCHAR(64)  NULL DEFAULT 'human',
    CONSTRAINT [PK_dbo.UserAvatar] PRIMARY KEY CLUSTERED ([UAId] ASC),
    CONSTRAINT [FK_dbo.UserAvatar_User] FOREIGN KEY (UserId) REFERENCES [User](UserId) /* [User] referenced with brackets due to VS built-in "User" creating conflict */
      ON DELETE CASCADE
      ON UPDATE CASCADE,
);

/* This table is for tracking each user's unlocked avatar parts */
CREATE TABLE [dbo].[AvatarUnlock]
(
	[UnlockId] INT IDENTITY(1,1) NOT NULL,
    [UserId] INT NOT NULL,
	[AvaId] INT NOT NULL,
	CONSTRAINT [PK_dbo.AvatarUnlock] PRIMARY KEY CLUSTERED ([UnlockId] ASC),
    CONSTRAINT [FK_dbo.AvatarUnlock_User] FOREIGN KEY (UserId) REFERENCES [User](UserId) /* [User] referenced with brackets due to VS built-in "User" creating conflict */
      ON DELETE CASCADE
      ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.AvatarUnlock_Avatar] FOREIGN KEY (AvaId) REFERENCES [Avatar](AvaId)
      ON DELETE CASCADE
      ON UPDATE CASCADE
);