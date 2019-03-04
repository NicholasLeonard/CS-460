/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singular instances for table names to Plural

*/

CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Height] INT NULL, 
    [Weight] INT NULL, 
    [UserName] NVARCHAR(256) NOT NULL,
)

INSERT INTO [dbo].[User] (UserName) VALUES ('tester')
GO