CREATE TABLE [dbo].[UserWorkoutPlan] 
(
    [LogId] INT IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR(256) NOT NULL,
    [PlanId] INT NOT NULL,
 	CONSTRAINT [PK_dbo.UserWorkoutPlan] PRIMARY KEY CLUSTERED ([LogId] ASC),
	CONSTRAINT [FK_dbo.UserWorkoutPlan_WorkoutPlan] FOREIGN KEY (PlanId) REFERENCES WorkoutPlan(PlanId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

