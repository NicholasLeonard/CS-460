/* This code commented out so that the DOWN.sql worked for me

/* This is the DOWN Script for Workout Plans */
/*DOWN script for workout tables*/

/* DROP FKs */
ALTER TABLE [dbo].[PlanWorkouts] DROP CONSTRAINT [FK_dbo.PlanWorkouts_Plans]
ALTER TABLE [dbo].[PlanWorkouts] DROP CONSTRAINT [FK_dbo.PlanWorkouts_Workouts]

/* DROP PKs */
ALTER TABLE [dbo].[Plans] 		 DROP CONSTRAINT [PK_dbo.Plans]
ALTER TABLE [dbo].[PlanWorkouts] DROP CONSTRAINT [PK_dbo.PlanWorkouts]

*/

/* DROP all tables */
DROP TABLE IF EXISTS [dbo].[Plans] 
DROP TABLE IF EXISTS [dbo].[PlanWorkouts]

GO