/*DROP user workout plan table constraint*/
ALTER TABLE [dbo].[UserWorkoutPlan] DROP CONSTRAINT [FK_dbo.UserWorkoutPlan_WorkoutPlan]
GO

/* Drop user workout plan table */
DROP TABLE IF EXISTS [dbo].[UserWorkoutPlan]
GO