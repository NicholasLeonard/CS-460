CREATE TABLE [dbo].[UserWorkout]
(
	[UWId] INT IDENTITY(1,1) NOT NULL,
	[UserId] INT NOT NULL,
	[UserActiveWorkout] INT NOT NULL,
	[ActiveWorkoutStage] INT NOT NULL,
	[FromPlan] BIT NOT NULL, /*Refactoring so that FromPlan is saved within the database, instead of URL based*/
	[WorkoutCompleted] BIT NOT NULL, /* This is for checking Workout History, if a workout is marked completed, it will appear in the user's workout history view */
	[CompletedTime] DATETIME NULL
	CONSTRAINT [PK_dbo.UserWorkout] PRIMARY KEY CLUSTERED ([UWId] ASC),
	CONSTRAINT [FK_dbo.UserWorkout_User] FOREIGN KEY (UserId) REFERENCES [User](UserId) /* [User] referenced with brackets due to VS built-in "User" creating conflict */
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.UserWorkout_Workout] FOREIGN KEY (UserActiveWorkout) REFERENCES Workout(WorkoutId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
