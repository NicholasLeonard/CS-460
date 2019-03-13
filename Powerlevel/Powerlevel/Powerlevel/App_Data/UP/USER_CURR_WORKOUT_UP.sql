CREATE TABLE [dbo].[UserCurrWorkout]
(
	[UCWId] INT IDENTITY(1,1) NOT NULL,
	[UserId] INT NOT NULL,
	[UserActiveWorkout] INT NOT NULL
	CONSTRAINT [PK_dbo.UserCurrWorkout] PRIMARY KEY CLUSTERED ([UCWId] ASC),
	CONSTRAINT [FK_dbo.UserCurrWorkout_User] FOREIGN KEY (UserId) REFERENCES [User](UserId) /* [User] referenced with brackets due to VS built-in "User" creating conflict */
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.UserCurrWorkout_WorkoutExercise] FOREIGN KEY (UserActiveWorkout) REFERENCES WorkoutExercise(LinkId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
