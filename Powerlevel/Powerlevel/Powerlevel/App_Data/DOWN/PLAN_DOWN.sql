/* This is the DOWN Script for Workout Plans */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
	-REFACTOR: Changed all Foreign Keys to follow format FK_[Tableitisin]_[Tableitrefences]
	-REFACTOR: Plan is a reserved word ins SQL, changed table names to WorkoutPlan and WorkoutPlanWorkout to reflect this
*/
/*DOWN script for workout tables*/

/* DROP FKs */
ALTER TABLE [dbo].[WorkoutPlanWorkout] DROP CONSTRAINT [FK_dbo.WorkoutPlanWorkout_WorkoutPlan]
GO
ALTER TABLE [dbo].[WorkoutPlanWorkout] DROP CONSTRAINT [FK_dbo.WorkoutPlanWorkout_Workout]
GO

/* DROP PKs */
ALTER TABLE [dbo].[WorkoutPlan]          DROP CONSTRAINT [PK_dbo.WorkoutPlan]
GO
ALTER TABLE [dbo].[WorkoutPlanWorkout] DROP CONSTRAINT [PK_dbo.WorkoutPlanWorkout]
GO


/* DROP all tables */
DROP TABLE IF EXISTS [dbo].[WorkoutPlan] 
DROP TABLE IF EXISTS [dbo].[WorkoutPlanWorkout]

GO