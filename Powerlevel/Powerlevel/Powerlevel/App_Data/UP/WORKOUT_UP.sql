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