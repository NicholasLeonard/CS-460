INSERT INTO [dbo].[WorkoutPlan] (Name, Type, Description, DaysToComplete, NumberOfWorkouts) VALUES
('Chest and Back Plan', 'Upper-Body', 'The core of this plan works out your chest and back, with most of the workouts also 
strengthening your triceps.', 2, 2)

/* Table to connect the plan to a workout via PlanID and WorkoutID, 
as well as display which day of the plan the workout should be completed */
INSERT INTO [dbo].[WorkoutPlanWorkout] (PlanId, WorkoutId, DayOfPlan) VALUES
(1,1,1),
(1,2,2)