/*Dropping foreign keys*/
ALTER TABLE [dbo].[WorkoutEvent] DROP CONSTRAINT [FK_dbo.WorkoutEvent_User]
GO
ALTER TABLE [dbo].[WorkoutEvent] DROP CONSTRAINT [FK_dbo.WorkoutEvent_Workout]
GO

/*Dropping primary key*/
ALTER TABLE [dbo].[WorkoutEvent] DROP CONSTRAINT [PK_dbo.Event]
GO

/*Dropping table*/
DROP TABLE IF EXISTS [dbo].[WorkoutEvent]
GO