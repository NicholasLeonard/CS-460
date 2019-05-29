/*THIS IS THE MASTER UP FILE */


/*
CREATE the table for Exercises
2/28/2019
	-REFACTOR: Changed name from Exercises to Exercise
*/
CREATE TABLE [dbo].[Exercise]
(
	[ExerciseId] INT IDENTITY(1,1) NOT NULL, 
    [Name] NCHAR(128) NOT NULL, 
    [Type] NCHAR(64) NOT NULL, 
    [MainMuscleWorked] NCHAR(64) NOT NULL,
    [Instructions] NVARCHAR(3000) NOT NULL,
	CONSTRAINT [PK_dbo.Exercise] PRIMARY KEY CLUSTERED ([ExerciseId] ASC)
);


/*
CREATE the table for Exercise's Flags of information
2/28/2019
	-REFACTOR: This table has been refactored to be a one to many relationship after the database review meeting
	-REFACTOR: This table has been renamed from ExerciseFlags to ExerciseFlag
*/
CREATE TABLE [dbo].[ExerciseFlag]
(
	[FlagId] INT IDENTITY(1,1) NOT NULL,
	[ExerciseId] INT NOT NULL,
	[FlagName] NCHAR(64)
	CONSTRAINT [PK_dbo.ExerciseFlag] PRIMARY KEY CLUSTERED ([FlagId] ASC),
	CONSTRAINT [FK_dbo.ExerciseFlag_Exercise] FOREIGN KEY (ExerciseId) REFERENCES Exercise(ExerciseId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

/*
CREATE the table for Exercise's required equipment
2/28/2019
	-REFACTOR: This table has been refactored to be a one to many relationship after the database review meeting
*/
CREATE TABLE [dbo].[ExerciseEquipment]
(
	[RequirementId] INT IDENTITY(1,1) NOT NULL,
	[ExerciseId] INT NOT NULL,
	[EquipmentName] NCHAR(64)
	CONSTRAINT [PK_dbo.ExerciseEquipment] PRIMARY KEY CLUSTERED ([RequirementId] ASC),
	CONSTRAINT [FK_dbo.ExerciseEquipment_Exercise] FOREIGN KEY (ExerciseId) REFERENCES Exercise(ExerciseId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

/*
Create the table for Exercise Images
*/
CREATE TABLE [dbo].[ExerciseImage]
(
	[ImageId] INT IDENTITY(1,1) NOT NULL,
	[ExerciseId] INT NOT NULL,
	[ImageName] NCHAR(128) NOT NULL, 
	CONSTRAINT [PK_dbo.ExerciseImage] PRIMARY KEY CLUSTERED ([ImageId] ASC),
	CONSTRAINT [FK_dbo.ExerciseImage_Exercise] FOREIGN KEY (ExerciseId) REFERENCES Exercise(ExerciseId)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
);
GO

/* This is the file for the Workout upscript */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
	-REFACTOR: Changed all Foreign Keys to follow format FK_[Tableitisin]_[Tableitrefences]
*/

/* CREATE the table for Workouts */
CREATE TABLE [dbo].[Workout]
(
	[WorkoutId] INT IDENTITY(1,1) NOT NULL,
	[Name] NCHAR(128) NOT NULL, 
    [Type] NCHAR(64) NOT NULL, 
	[MainMuscleFocus] NCHAR(64) NOT NULL,
	[TimeEstimate] NCHAR(64) NOT NULL,
	[ExpReward] INT NOT NULL DEFAULT 0, 
	CONSTRAINT [PK_dbo.Workout] PRIMARY KEY CLUSTERED ([WorkoutId] ASC)
);

/*CREATE the table that links workouts to thier various exercises in an order */
CREATE TABLE [dbo].[WorkoutExercise]
(
	[LinkId] INT IDENTITY(1,1) NOT NULL,
	[WorkoutId] INT NOT NULL,
	[ExerciseId] INT NOT NULL,
	[OrderNumber] INT,
	CONSTRAINT [PK_dbo.WorkoutExercise] PRIMARY KEY CLUSTERED ([LinkId] ASC),
	CONSTRAINT [FK_dbo.WorkoutExercise_Workout] FOREIGN KEY (WorkoutId) REFERENCES Workout(WorkoutId)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.WorkoutExercise_Exercise] FOREIGN KEY (ExerciseId) REFERENCES Exercise(ExerciseId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
GO

/* This is the UP Script for Workout Plans */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
	-REFACTOR: Changed all Foreign Keys to follow format FK_[Tableitisin]_[Tableitrefences]
	-REFACTOR: Plan is a reserved word ins SQL, changed table names to WorkoutPlan and WorkoutPlanWorkout to reflect this
*/

/* CREATE the table for workout plans
	-Plan is a reserved word, needed to rename Plan to WorkoutPlan
*/
CREATE TABLE [dbo].[WorkoutPlan]
(
	[PlanId] INT IDENTITY(1,1) NOT NULL,
	[Name] NCHAR(128) NOT NULL,
	[Type] NCHAR(64) NOT NULL, 
	[Description] NVARCHAR(3000) NOT NULL,
	[DaysToComplete] INT NOT NULL,
	[NumberOfWorkouts] INT NOT NULL,
	CONSTRAINT [PK_dbo.WorkoutPlan] PRIMARY KEY CLUSTERED ([PlanId] ASC)
);

/* CREATE the table for linking workout plans to workouts */
CREATE TABLE [dbo].[WorkoutPlanWorkout]
(
	[LinkID] INT IDENTITY(1,1) NOT NULL,
	[PlanId] INT NOT NULL,
	[WorkoutId] INT NOT NULL,
	[DayOfPlan] INT NOT NULL
	CONSTRAINT [PK_dbo.WorkoutPlanWorkout] PRIMARY KEY CLUSTERED ([LinkId] ASC),
	CONSTRAINT [FK_dbo.WorkoutPlanWorkout_WorkoutPlan] FOREIGN KEY (PlanId) REFERENCES WorkoutPlan(PlanId)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.WorkoutPlanWorkout_Workout] FOREIGN KEY (WorkoutId) REFERENCES Workout(WorkoutId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
GO

/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singular instances for table names to Plural
5/20/2019
	-REFACTOR: Added new fields
*/

CREATE TABLE [dbo].[User]
(
	[UserId] INT IDENTITY(1,1), 
    [HeightFeet] INT            NULL,
    [Weight] FLOAT NULL,
	[DOB] DATETIME,
	[Gender] NVARCHAR(10),
    [UserName] NVARCHAR(256) NOT NULL,
    [Experience] INT NOT NULL DEFAULT 0,
    [Level] INT NOT NULL DEFAULT 1, 
    [BMI]        FLOAT            DEFAULT 0 NOT NULL,
    [HeightInch] INT            NULL,
	[TotalWorkoutsCompleted] INT NOT NULL DEFAULT 0, 
	[FitbitLinked] BIT NOT NULL DEFAULT (0),
	[FirstTimeLogin] BIT NOT NULL DEFAULT (1),
	CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);
GO

/*
This file is used to create the table that will track the current avatars for users
*/
CREATE TABLE [dbo].[Avatar]
(
    [AvaId] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(64) NOT NULL,
	[Imagefile] NVARCHAR(64) NOT NULL,
    [Type] NVARCHAR(64) NOT NULL,
	[Race] NVARCHAR(64) NOT NULL
    CONSTRAINT [PK_dbo.Avatar] PRIMARY KEY CLUSTERED ([AvaId] ASC)
);

/* This table is for tracking the user's currently equipped avatar */
CREATE TABLE [dbo].[UserAvatar]
(
    [UAId] INT IDENTITY(1,1) NOT NULL,
    [UserId] INT NOT NULL,
    [Body] NVARCHAR(64)  NULL DEFAULT 'human1.PNG',
    [Armor] NVARCHAR(64)   NULL DEFAULT 'none.PNG',
    [Weapon] NVARCHAR(64)  NULL DEFAULT 'none.PNG',
	[Race] NVARCHAR(64) NULL DEFAULT 'human',
    CONSTRAINT [PK_dbo.UserAvatar] PRIMARY KEY CLUSTERED ([UAId] ASC),
    CONSTRAINT [FK_dbo.UserAvatar_User] FOREIGN KEY (UserId) REFERENCES [User](UserId) /* [User] referenced with brackets due to VS built-in "User" creating conflict */
      ON DELETE CASCADE
      ON UPDATE CASCADE,
);

/* This table is for tracking each user's unlocked avatar parts */
CREATE TABLE [dbo].[AvatarUnlock]
(
	[UnlockId] INT IDENTITY(1,1) NOT NULL,
    [UserId] INT NOT NULL,
	[AvaId] INT NOT NULL,
	CONSTRAINT [PK_dbo.AvatarUnlock] PRIMARY KEY CLUSTERED ([UnlockId] ASC),
    CONSTRAINT [FK_dbo.AvatarUnlock_User] FOREIGN KEY (UserId) REFERENCES [User](UserId) /* [User] referenced with brackets due to VS built-in "User" creating conflict */
      ON DELETE CASCADE
      ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.AvatarUnlock_Avatar] FOREIGN KEY (AvaId) REFERENCES [Avatar](AvaId)
      ON DELETE CASCADE
      ON UPDATE CASCADE
);
GO

/* This table is for the experience tracking for players */
CREATE TABLE [dbo].[LevelExp]
(
    [LevelExpId] INT IDENTITY (1, 1) NOT NULL,
    [Level]      INT DEFAULT ((1)) NOT NULL,
    [Exp]        INT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.LevelExp] PRIMARY KEY CLUSTERED ([LevelExpId] ASC)
);
GO

/* This table is for tracking user's current workout */
CREATE TABLE [dbo].[UserWorkout]
(
	[UWId] INT IDENTITY(1,1) NOT NULL,
	[UserId] INT NOT NULL,
	[UserActiveWorkout] INT NOT NULL,
	[ActiveWorkoutStage] INT NOT NULL,
	[FromPlan] BIT NOT NULL, /*Refactoring so that FromPlan is saved within the database, instead of URL based*/
	[WorkoutCompleted] BIT NOT NULL, /* This is for checking Workout History, if a workout is marked completed, it will appear in the user's workout history view */
	[StartTime] DATETIME NOT NULL,
	[CompletedTime] DATETIME NULL
	CONSTRAINT [PK_dbo.UserWorkout] PRIMARY KEY CLUSTERED ([UWId] ASC),
	CONSTRAINT [FK_dbo.UserWorkout_User] FOREIGN KEY (UserId) REFERENCES [User](UserId) /* [User] referenced with brackets due to VS built-in "User" creating conflict */
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.UserWorkout_Workout] FOREIGN KEY (UserActiveWorkout) REFERENCES Workout(WorkoutId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
GO

/* This table is for tacking user's current workout plan */
CREATE TABLE [dbo].[UserWorkoutPlan] 
(
    [LogId] INT IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR(256) NOT NULL,
    [PlanId] INT NOT NULL,
	[PlanStage] INT NOT NULL,
	[MaxStage] INT NOT NULL,
 	CONSTRAINT [PK_dbo.UserWorkoutPlan] PRIMARY KEY CLUSTERED ([LogId] ASC),
	CONSTRAINT [FK_dbo.UserWorkoutPlan_WorkoutPlan] FOREIGN KEY (PlanId) REFERENCES WorkoutPlan(PlanId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
GO

/*Table for workout calendar events for workout plan*/
CREATE TABLE [dbo].[WorkoutEvent]
(
	[EventId] INT IDENTITY(1,1) NOT NULL, 
    [Title] NCHAR(128) NULL, 
    [Start] DATETIME NULL, 
    [End] DATETIME NULL,
    [StatusColor] NVARCHAR(20) NULL,
	[Description] NVARCHAR(200) NULL,
	[UserId] INT NOT NULL,
	[WorkoutId] INT NOT NULL,
	
	CONSTRAINT [PK_dbo.Event] PRIMARY KEY CLUSTERED ([EventId] ASC),
	CONSTRAINT [FK_dbo.WorkoutEvent_User] FOREIGN KEY (UserId) REFERENCES [User](UserId),
	CONSTRAINT [FK_dbo.WorkoutEvent_Workout] FOREIGN KEY (WorkoutId) REFERENCES Workout(WorkoutId)
);
GO

/*Team Up Script */
CREATE TABLE [dbo].[Team] (
    [TeamId] INT IDENTITY(1,1) NOT NULL,
    [UserId] INT NULL , 
    [TeamMemId] INT NULL , 
    CONSTRAINT [PK_dbo.Team] PRIMARY KEY CLUSTERED ([TeamId] ASC),
	CONSTRAINT [FK_dbo.Team_User] FOREIGN KEY (UserId) REFERENCES [User](UserId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
GO