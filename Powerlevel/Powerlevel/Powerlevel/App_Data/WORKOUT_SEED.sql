/* This file is only for populating the lists of workouts, as such a list is exhaustive */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
*/

/* Create the table that contains various workouts, whether they are strength or cardio,
the muscle group that it focuses on, and approximately how long the full workout takes to complete */
INSERT INTO [dbo].[Workout] (Name, Type, MainMuscleFocus, TimeEstimate) VALUES

('Upper Body Hellhole', 'Strength', 'Chest', '30 Minutes'),
('Burning Back', 'Strength', 'Back', '45 Minutes')

/* Links each workout exercise to a workout, an exercise, and an order to complete the workout */
INSERT INTO [dbo].[WorkoutExercise] (WorkoutId, ExerciseId, OrderNumber) VALUES
(1,1,1),
(1,5,2),
(1,4,3),
(2,2,1),
(2,3,2),
(2,7,3)
