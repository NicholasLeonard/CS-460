CREATE TABLE [dbo].[UserWorkout]
(
	[UCWId] INT IDENTITY(1,1) NOT NULL,
	[UserId] INT NOT NULL,
	[UserActiveWorkout] INT NOT NULL,
	[ActiveWorkoutStage] INT NOT NULL,
	[WorkoutCompleted] BIT NOT NULL, /* This is for checking Workout History, if a workout is marked completed, it will appear in the user's workout history view */
	[CompletedTime] DATETIME NULL
	CONSTRAINT [PK_dbo.UserWorkout] PRIMARY KEY CLUSTERED ([UCWId] ASC),
	CONSTRAINT [FK_dbo.UserWorkout_User] FOREIGN KEY (UserId) REFERENCES [User](UserId) /* [User] referenced with brackets due to VS built-in "User" creating conflict */
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.UserWorkout_WorkoutExercise] FOREIGN KEY (UserActiveWorkout) REFERENCES WorkoutExercise(LinkId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
