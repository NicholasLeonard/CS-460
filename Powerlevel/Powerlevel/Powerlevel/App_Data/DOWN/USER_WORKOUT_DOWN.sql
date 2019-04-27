/*Drop Primary key*/
ALTER TABLE [dbo].[UserWorkout] DROP CONSTRAINT [PK_dbo.UserWorkout]
GO

/*Drop Foreign keys*/
ALTER TABLE [dbo].[UserWorkout] DROP CONSTRAINT [FK_dbo.UserWorkout_User]
ALTER TABLE [dbo].[UserWorkout] DROP CONSTRAINT [FK_dbo.UserWorkout_Workout]
GO

/*Drop Table*/
DROP TABLE IF EXISTS [dbo].[UserWorkout] 
GO