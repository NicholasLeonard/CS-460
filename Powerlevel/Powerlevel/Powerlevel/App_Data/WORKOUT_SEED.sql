/* This file is only for populating the lists of workouts, as such a list is exhaustive */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
*/

/* Create the table that contains various workouts, whether they are strength or cardio,
the muscle group that it focuses on, and approximately how long the full workout takes to complete */
INSERT INTO [dbo].[Workout] (Name, Type, MainMuscleFocus, TimeEstimate) VALUES
('Upper Body', 'Strength', 'Chest', '16 Minutes'),/*benchpress, incline flye, diamond pushup, hammergrip dumbell bench press*/
('Back', 'Strength', 'Back', '14.5 Minutes'),/*bentover row, chin up*/
('Arm', 'Strength', 'Triceps, Anterior-Deltoids', '12 Minutes')/*Dumbell overhead press, Dumbell tricep extension*/

/* Links each workout exercise to a workout, an exercise, and an order to complete the workout */
INSERT INTO [dbo].[WorkoutExercise] (WorkoutId, ExerciseId, OrderNumber, PlanId) VALUES
(1,1,1,1),
(1,5,5,1),
(1,7,8,1),
(1,4,4,1),
(2,2,2,1),
(2,3,3,1),
(3,6,7,2),
(3,8,9,2)

/* Old seed data. Just keeping incase we need it but hope to move away from it*/
/*
('Bench Press', 'Strength', 'Chest', '8 Minutes'),
('Bent-over row', 'Strength', 'Back', '12.5 Minutes'),
('Chin-up', 'Strength', 'Back', '2 Minutes'),
('Incline flye', 'Strength', 'Chest', '2 Minutes'),
('Diamond push-up', 'Strength', 'Chest', '4.5 Minutes'),
('Dumbbell overhead press', 'Strength', 'Anterior Deltoids', '10.5 Minutes'),
('Hammer-grip dumbbell bench press', 'Strength', 'Chest', '1.5 Minutes'),
('Dumbbell triceps extension', 'Strength', 'Triceps', '1.5 Minutes')

/* Links each workout exercise to a workout, an exercise, and an order to complete the workout */
INSERT INTO [dbo].[WorkoutExercise] (WorkoutId, ExerciseId, OrderNumber) VALUES
(1,1,1),
(2,2,2),
(3,3,3),
(4,4,4),
(5,5,5),
(1,1,6),
(6,6,7),
(7,7,8),
(8,8,9),
(5,5,10)
*/