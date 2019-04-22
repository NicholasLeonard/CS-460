/*Table for workout calendar events for workout plan*/

CREATE TABLE [dbo].[WorkoutEvent]
(
	[EventId] INT IDENTITY(1,1) NOT NULL, 
    [Title] NCHAR(128) NULL, 
    [Start] DATETIME NULL, 
    [End] DATETIME NULL,
    [StatusColor] NVARCHAR(20) NULL,
	[Description] NVARCHAR(200) NULL,
	[UserId] INT NOT NULL,
	[WorkoutId] INT NOT NULL,
	
	CONSTRAINT [PK_dbo.Event] PRIMARY KEY CLUSTERED ([EventId] ASC),
	CONSTRAINT [FK_dbo.WorkoutEvent_User] FOREIGN KEY (UserId) REFERENCES [User](UserId),
	CONSTRAINT [FK_dbo.WorkoutEvent_Workout] FOREIGN KEY (WorkoutId) REFERENCES Workout(WorkoutId)
);