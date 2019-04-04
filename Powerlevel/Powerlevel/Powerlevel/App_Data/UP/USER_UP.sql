/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singular instances for table names to Plural

*/

CREATE TABLE [dbo].[User]
(
	[UserId] INT IDENTITY(1,1), 
    [Height] INT NULL, 
    [Weight] INT NULL,
	[DOB] DATETIME,
	[Gender] NVARCHAR(10),
    [UserName] NVARCHAR(256) NOT NULL,
	CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([UserId] ASC)
)