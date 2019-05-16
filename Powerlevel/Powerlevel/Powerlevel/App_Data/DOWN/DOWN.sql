/* Dropping the Workout Events Table */
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

/* Drop the user workout plan tables */
/*DROP user workout plan table constraint*/
ALTER TABLE [dbo].[UserWorkoutPlan] DROP CONSTRAINT [FK_dbo.UserWorkoutPlan_WorkoutPlan]
GO

/* Drop user workout plan table */
DROP TABLE IF EXISTS [dbo].[UserWorkoutPlan]
GO

/*Drop the User Workout table */
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

/* Drop the Level Experience Table */
DROP TABLE IF EXISTS [dbo].[LevelExp]
GO

/* Drop all the Avatars table */
/*Drop Primary key*/
ALTER TABLE [dbo].[AvatarUnlock] DROP CONSTRAINT [PK_dbo.AvatarUnlock]
GO

/*Drop Foreign keys*/
ALTER TABLE [dbo].[AvatarUnlock] DROP CONSTRAINT [FK_dbo.AvatarUnlock_User]
GO
ALTER TABLE [dbo].[AvatarUnlock] DROP CONSTRAINT [FK_dbo.AvatarUnlock_Avatar]
GO

/* Drop Table */
DROP TABLE IF EXISTS [dbo].[AvatarUnlock]
GO

/*Drop Primary key*/
ALTER TABLE [dbo].[UserAvatar] DROP CONSTRAINT [PK_dbo.UserAvatar]
GO
/*Drop Foreign keys*/
ALTER TABLE [dbo].[UserAvatar] DROP CONSTRAINT [FK_dbo.UserAvatar_User]
GO

/*Drop Table */
DROP TABLE IF EXISTS [dbo].[UserAvatar]
GO

/*Drop Avatar Table */
ALTER TABLE [dbo].[Avatar] DROP CONSTRAINT [PK_dbo.Avatar]
GO

/*Drop Table */
DROP TABLE IF EXISTS [dbo].[Avatar]
GO

/*Down script for our User table*/
/*DROP PKs*/
ALTER TABLE [dbo].[User] DROP CONSTRAINT [PK_dbo.User]
GO

/*DROP user table*/
DROP TABLE IF EXISTS [dbo].[User]
GO

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

/* Drop all exercise tables */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
*/

/*Drop the Exercise falg table */
ALTER TABLE     [dbo].[ExerciseFlag]        DROP CONSTRAINT [FK_dbo.ExerciseFlag_Exercise]
GO
ALTER TABLE		[dbo].[ExerciseFlag]        DROP CONSTRAINT [PK_dbo.ExerciseFlag]
GO
DROP TABLE IF EXISTS [dbo].[ExerciseFlag]
GO


/* Drop the Exercise Equipment Table */
ALTER TABLE     [dbo].[ExerciseEquipment]    DROP CONSTRAINT [FK_dbo.ExerciseEquipment_Exercise]
GO
ALTER TABLE     [dbo].[ExerciseEquipment]    DROP CONSTRAINT [PK_dbo.ExerciseEquipment]
GO
DROP TABLE IF EXISTS [dbo].[ExerciseEquipment]
GO

/*Drop the Exercise Image Table */
ALTER TABLE  [dbo].[ExerciseImage]     DROP CONSTRAINT [FK_dbo.ExerciseImage_Exercise]
GO
ALTER TABLE  [dbo].[ExerciseImage]     DROP CONSTRAINT [PK_dbo.ExerciseImage]
GO
DROP TABLE IF EXISTS [dbo].[ExerciseImage] 
GO

/* DROP the exercise table */
ALTER TABLE  [dbo].[Exercise]             DROP CONSTRAINT [PK_dbo.Exercise]
GO
DROP TABLE IF EXISTS [dbo].[Exercise] 	
GO