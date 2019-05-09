/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singular instances for table names to Plural

*/

CREATE TABLE [dbo].[User]
(
	[UserId] INT IDENTITY(1,1), 
    [HeightFeet] FLOAT            NULL,
    [Weight] FLOAT NULL,
	[DOB] DATETIME,
	[Gender] NVARCHAR(10),
    [UserName] NVARCHAR(256) NOT NULL,
    [Experience] INT NOT NULL DEFAULT 0,
    [Level] INT NOT NULL DEFAULT 1, 
    [BMI]        FLOAT            DEFAULT 0 NOT NULL,
    [HeightInch] INT            NULL,
	[FitbitLinked] BIT NOT NULL DEFAULT (0),
	[FirstTimeLogin] BIT NOT NULL DEFAULT (1),
	CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([UserId] ASC)
)