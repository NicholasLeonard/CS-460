/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singular instances for table names to Plural

*/

CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY(0,1) NOT NULL, 
    [Height] INT NULL, 
    [Weight] INT NULL, 
    [UserName] NVARCHAR(256) NOT NULL,

	CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([Id] ASC)
)

/*INSERT INTO [dbo].[User] (Id, UserName) VALUES (0, 'tester')*/
GO