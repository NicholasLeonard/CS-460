/*
This file is used to create the table that will track the current avatars for users
*/
CREATE TABLE [dbo].[Avatar]
(
	[UAId] INT IDENTITY(1,1) NOT NULL,
	[UserId] INT NOT NULL,
	[Body] NVARCHAR(64) NOT NULL DEFAULT 'human1',
	[Armor] NVARCHAR(64) NOT NULL DEFAULT 'none',
	[Weapon] NVARCHAR(64) NOT NULL DEFAULT 'none',
	CONSTRAINT [PK_dbo.Avatar] PRIMARY KEY CLUSTERED ([UAId] ASC),
	CONSTRAINT [FK_dbo.Avatar_User] FOREIGN KEY (UserId) REFERENCES [User](UserId) /* [User] referenced with brackets due to VS built-in "User" creating conflict */
		ON DELETE CASCADE
		ON UPDATE CASCADE,
);