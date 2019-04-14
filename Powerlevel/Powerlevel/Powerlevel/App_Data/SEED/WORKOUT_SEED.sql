/* This file is only for populating the lists of workouts, as such a list is exhaustive */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
*/

/* Create the table that contains various workouts, whether they are strength or cardio,
the muscle group that it focuses on, and approximately how long the full workout takes to complete */
INSERT INTO [dbo].[Workout] (Name, Type, MainMuscleFocus, TimeEstimate, ExpReward) VALUES
('Upper Body Hellhole', 'Strength', 'Chest', '30 Minutes', 50),
('Burning Back', 'Strength', 'Back', '45 Minutes', 50),
('Beginner Full Body Gym', 'Strength', 'Full Body', '60 Minutes', 50),
('Rest Day', 'None', 'Full Body', '24 Hours', 50),
('Beginner Upper Body Gym', 'Strength', 'Upper Body', '60 Minutes', 50),
('Beginner Lower Body Gym', 'Strength', 'Lower Body', '60 Minutes', 50),
('Beginner Push Gym', 'Strength', 'Biceps', '60 Minutes', 50),
('Beginner Pull Gym', 'Strength', 'Chest', '60 Minutes', 50),
('Beginner Legs Gym', 'Strength', 'Legs', '60 Minutes', 50),
('Beginner Chest, Triceps, Calves Gym', 'Strength', 'Chest, Triceps, Calves', '60 Minutes', 50),
('Beginner Legs and Abs Gym', 'Strength', 'Legs, Abs', '60 Minutes', 50),
('Beginner Sholders and Calves Gym', 'Strength','Sholders, Calves', '60 Minutes', 50),
('Beginner Back, Biceps, Abs Gym', 'Strength', 'Back, Biceps, Abs', '60 Minutes', 50)

/* Links each workout exercise to a workout, an exercise, and an order to complete the workout */
INSERT INTO [dbo].[WorkoutExercise] (WorkoutId, ExerciseId, OrderNumber) VALUES
(1,1,1),(1,5,2),(1,4,3),
(2,2,1),(2,3,2),(2,7,3),
(3,17,1),(3,9,2),(3,6,3),(3,10,4),(3,11,5),(3,12,6),(3,13,7),(3,14,8),(3,15,9),
(4,16,1),
(5,1,1),(5,18,2),(5,2,3),(5,9,4),(5,6,5),(5,19,6),(5,13,7),(5,20,8),(5,21,9),(5,12,10),(5,15,11),
(6,10,1),(6,11,2),(6,22,3),(6,14,4),(6,23,5),
(7,24,1),(7,18,2),(7,6,3),(7,25,4),(7,21,5),(7,26,6),
(8,25,1),(8,27,2),(8,28,3),(8,20,4),(8,29,5),(8,15,6),
(9,30,1),(9,10,2),(9,22,3),(9,31,4),(9,14,5),(9,23,6),
(10,21,1),(10,17,2),(10,18,3),(10,12,4),(10,26,5),(10,21,6),(10,14,7),(10,23,8),
(11,30,1),(11,10,2),(11,11,3),(11,31,4),(11,22,5),(11,29,6),(11,15,7),
(12,6,1),(12,25,2),(12,19,3),(12,23,4),
(13,2,1),(13,9,2),(13,27,3),(13,13,4),(13,28,5),(13,20,6),(13,15,7)

