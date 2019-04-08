INSERT INTO [dbo].[WorkoutPlan] (Name, Type, Description, DaysToComplete, NumberOfWorkouts) VALUES
('Chest and Back Plan', 'Upper-Body', 'The core of this plan works out your chest and back, with most of the workouts also 
strengthening your triceps.', 2, 2),
('4 Week Beginner Gym Plan', 'Full Body', 'Think of this as the accelerated guide to body-building.
In this plan, your first month of training will be demanding, but not so demanding as to cause injury. 
This program isn’t just for the true beginner who has never touched a weight before;
it’s also suitable for anyone who has taken an extended leave of absence from training.', 28, 18)


/* Table to connect the plan to a workout via PlanID and WorkoutID, 
as well as display which day of the plan the workout should be completed */
INSERT INTO [dbo].[WorkoutPlanWorkout] (PlanId, WorkoutId, DayOfPlan) VALUES
(1,1,1),(1,2,2),
/*4 Week Beginner Plan, org weekly*/
(2,3,1),(2,4,2),(2,3,3),(2,4,4),(2,3,5),(2,4,6),(2,4,7),
(2,5,8),(2,6,9),(2,4,10),(2,5,11),(2,6,12),(2,4,13),(2,4,14),
(2,7,15),(2,8,16),(2,9,17),(2,7,18),(2,8,19),(2,9,20),(2,4,21),
(2,10,22),(2,11,23),(2,4,24),(2,12,25),(2,13,26),(2,4,27),(2,4,28)