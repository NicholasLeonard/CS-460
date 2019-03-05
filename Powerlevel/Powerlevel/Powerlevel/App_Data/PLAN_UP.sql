/* This is the UP Script for Workout Plans */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
	-REFACTOR: Changed all Foreign Keys to follow format FK_[Tableitisin]_[Tableitrefences]
	-REFACTOR: Plan is a reserved word ins SQL, changed table names to WorkoutPlan and WorkoutPlanWorkout to reflect this
*/

/* CREATE the table for workout plans
	-Plan is a reserved word, needed to rename Plan to WorkoutPlan
*/
CREATE TABLE [dbo].[Plan]
(
	[PlanId] INT IDENTITY(1,1) NOT NULL,
	[Name] NCHAR(128) NOT NULL,
	[Type] NCHAR(64) NOT NULL, 
	[Description] NVARCHAR(3000) NOT NULL,
	[DaysToComplete] INT NOT NULL,
	[NumberOfWorkouts] INT NOT NULL,
	CONSTRAINT [PK_dbo.Plan] PRIMARY KEY CLUSTERED ([PlanId] ASC)
);

/* CREATE the table for linking workout plans to workouts */
CREATE TABLE [dbo].[PlanWorkout]
(
	[LinkID] INT IDENTITY(1,1) NOT NULL,
	[PlanId] INT NOT NULL,
	[WorkoutId] INT NOT NULL,
	[DayOfPlan] INT NOT NULL
	CONSTRAINT [PK_dbo.PlanWorkout] PRIMARY KEY CLUSTERED ([LinkId] ASC),
	CONSTRAINT [FK_dbo.PlanWorkout_Plan] FOREIGN KEY (PlanId) REFERENCES [Plan]([PlanId])
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.PlanWorkout_Workout] FOREIGN KEY (WorkoutId) REFERENCES Workout(WorkoutId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

/* Table for the name of a plan, the type of plan it is (working upper-body, back, legs, etc.), a description of the plan, 
how many days it will take to complete, and the number of workouts in the plan */
INSERT INTO [dbo].[Plan] (Name, Type, Description, DaysToComplete, NumberOfWorkouts) VALUES
('Chest and Back Plan', 'Upper-Body', 'The core of this plan works out your chest and back, with most of the workouts also 
strengthening your triceps.', 3, 10)

/* Table to connect the plan to a workout via PlanID and WorkoutID, 
as well as display which day of the plan the workout should be completed */
INSERT INTO [dbo].[PlanWorkout] (PlanId, WorkoutId, DayOfPlan) VALUES
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
