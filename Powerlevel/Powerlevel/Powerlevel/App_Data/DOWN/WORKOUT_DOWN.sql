/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
*/

/*DOWN script for workout tables*/
/* DROP FKs */
ALTER TABLE [dbo].[WorkoutExercise] DROP CONSTRAINT [FK_dbo.WorkoutExercise_Workout]
GO

ALTER TABLE [dbo].[WorkoutExercise] DROP CONSTRAINT [FK_dbo.WorkoutExercise_Exercise]
GO
/* DROP PKs */
ALTER TABLE [dbo].[Workout]             DROP CONSTRAINT [PK_dbo.Workout]
ALTER TABLE [dbo].[WorkoutExercise]     DROP CONSTRAINT [PK_dbo.WorkoutExercise]

/* DROP all tables */
DROP TABLE IF EXISTS [dbo].[Workout] 
DROP TABLE IF EXISTS [dbo].[WorkoutExercise]

GO

