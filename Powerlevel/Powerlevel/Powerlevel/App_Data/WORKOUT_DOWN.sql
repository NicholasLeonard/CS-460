/*DOWN script for workout tables*/

/* DROP FKs */
ALTER TABLE [dbo].[WorkoutEquipment] DROP CONSTRAINT [FK_dbo.Workout_Equipment]
ALTER TABLE [dbo].[WorkoutExercises] DROP CONSTRAINT [FK_dbo.WorkoutExercises_Workouts]
ALTER TABLE [dbo].[WorkoutExercises] DROP CONSTRAINT [FK_dbo.WorkoutExercises_Exercises]

/* DROP PKs */
ALTER TABLE [dbo].[Workouts] 			DROP CONSTRAINT [PK_dbo.Workouts]
ALTER TABLE [dbo].[WorkoutEquipment] 	DROP CONSTRAINT [PK_dbo.WorkoutEquipment]
ALTER TABLE [dbo].[WorkoutExercises] 	DROP CONSTRAINT [PK_dbo.WorkoutExercises]


/* DROP all tables */
DROP TABLE [dbo].[Workouts] 
DROP TABLE [dbo].[WorkoutEquipment] 
DROP TABLE [dbo].[WorkoutExercises]

GO