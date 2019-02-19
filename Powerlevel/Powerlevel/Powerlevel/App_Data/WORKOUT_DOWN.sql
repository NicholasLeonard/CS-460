/*DOWN script for workout tables*/

/* DROP FKs */
ALTER TABLE [dbo].[WorkoutExercises] DROP CONSTRAINT [FK_dbo.WorkoutExercises_Workouts]
ALTER TABLE [dbo].[WorkoutExercises] DROP CONSTRAINT [FK_dbo.WorkoutExercises_Exercises]

/* DROP PKs */
ALTER TABLE [dbo].[Workouts] 			DROP CONSTRAINT [PK_dbo.Workouts]
ALTER TABLE [dbo].[WorkoutExercises] 	DROP CONSTRAINT [PK_dbo.WorkoutExercises]


/* DROP all tables */
DROP TABLE [dbo].[Workouts] 
DROP TABLE [dbo].[WorkoutExercises]

GO