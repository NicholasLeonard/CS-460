  CREATE TABLE [dbo].[UserWorkoutHistory]
(
	[UWHId] INT IDENTITY(1,1) NOT NULL,
	[CurrentTime] DATETIME NULL,
	[UserId] INT NOT NULL,
	[UserOldWorkout] INT NOT NULL
	CONSTRAINT [PK_dbo.UserWorkoutHistory] PRIMARY KEY CLUSTERED ([UWHId] ASC),
	CONSTRAINT [FK_dbo.UserWorkoutHistory_User] FOREIGN KEY (UserId) REFERENCES [User](UserId) /* [User] referenced with brackets due to VS built-in "User" creating conflict */
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.UserWorkoutHistory_WorkoutExercise] FOREIGN KEY (UserOldWorkout) REFERENCES WorkoutExercise(LinkId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);