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
	CONSTRAINT [FK_dbo.PlanWorkouts_Plans] FOREIGN KEY (PlanId) REFERENCES Plans(PlanId)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.PlanWorkouts_Workouts] FOREIGN KEY (WorkoutId) REFERENCES Workouts(WorkoutId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO [dbo].[Plans] (Name, Type, Description, DaysToComplete, NumberOfWorkouts) VALUES
('Chest and Back Plan', 'Upper-Body', 'The core of this plan works out your chest and back, with most of the workouts also 
strengthening your triceps.', 3, 10)

INSERT INTO [dbo].[PlanWorkouts] (PlanId, WorkoutId, DayOfPlan) VALUES
(1,1,1),
(1,2,1),
(1,3,1),
(1,4,1),
(1,5,1),
(1,1,3),
(1,6,3),
(1,7,3),
(1,8,3),
(1,5,3)