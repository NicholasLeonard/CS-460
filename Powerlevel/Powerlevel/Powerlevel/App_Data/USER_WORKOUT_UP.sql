CREATE TABLE [dbo].[UserWorkout]
(
	[UWId] INT IDENTITY(1,1) NOT NULL,
	[UsernameId] INT NOT NULL,
	[UserCurrentPlan] INT NOT NULL
	CONSTRAINT [PK_dbo.UserWorkout] PRIMARY KEY CLUSTERED ([UWId] ASC),
	CONSTRAINT [FK_dbo.UserWorkout_User] FOREIGN KEY (UsernameId) REFERENCES [User](Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.UserWorkout_WorkoutPlanWorkout] FOREIGN KEY (UserCurrentPlan) REFERENCES PlanWorkout(LinkId)/*probably need to change this to reference PlanId in the workoutExercise table to reestablish connection*/
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
