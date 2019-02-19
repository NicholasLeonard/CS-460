/* This is the UP Script for Workout Plans */

/* CREATE the table for workout plans */
CREATE TABLE [dbo].[Plans]
(
	[PlanId] INT IDENTITY(1,1) NOT NULL,
	[Name] NCHAR(128) NOT NULL,
	[Type] NCHAR(64) NOT NULL, 
	[Description] NVARCHAR(3000) NOT NULL,
	[DaysToComplete] INT NOT NULL,
	[NumberOfWorkouts] INT NOT NULL,
	CONSTRAINT [PK_dbo.Plans] PRIMARY KEY CLUSTERED ([PlanId] ASC)
);

/* CREATE the table for linking workout plans to workouts */
CREATE TABLE [dbo].[PlanWorkouts]
(
	[LinkID] INT IDENTITY(1,1) NOT NULL,
	[PlanId] INT NOT NULL,
	[WorkoutId] INT NOT NULL,
	[DayOfPlan] INT NOT NULL
	CONSTRAINT [PK_dbo.PlanWorkouts] PRIMARY KEY CLUSTERED ([LinkId] ASC),
	CONSTRAINT [FK_dbo.PlanWorkouts_Plans] FOREIGN KEY (PlanId) REFERENCES Plans(PlanId),
	CONSTRAINT [FK_dbo.PlanWorkouts_Workouts] FOREIGN KEY (WorkoutId) REFERENCES Workouts(WorkoutId)
);
