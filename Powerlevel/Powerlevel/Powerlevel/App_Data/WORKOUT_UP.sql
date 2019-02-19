/* This is the file for the Workout upscript */

/* CREATE the table for Workouts */
CREATE TABLE [dbo].[Workouts]
(
	[WorkoutId] INT IDENTITY(1,1) NOT NULL,
	[Name] NCHAR(128) NOT NULL, 
    [Type] NCHAR(64) NOT NULL, 
	[MainMuscleFocus] NCHAR(64) NOT NULL,
	[TimeEstimate] NCHAR(64) NOT NULL,
	CONSTRAINT [PK_dbo.Workouts] PRIMARY KEY CLUSTERED ([WorkoutId] ASC)
);

/*CREATE the table that links workouts to thier various exercises in an order */
CREATE TABLE [dbo].[WorkoutExercises]
(
	[LinkId] INT IDENTITY(1,1) NOT NULL,
	[WorkoutId] INT NOT NULL,
	[ExerciseId] INT NOT NULL,
	[OrderNumber] INT,
	CONSTRAINT [PK_dbo.WorkoutExercises] PRIMARY KEY CLUSTERED ([LinkId] ASC),
	CONSTRAINT [FK_dbo.WorkoutExercises_Workouts] FOREIGN KEY (WorkoutId) REFERENCES Workouts(WorkoutId),
	CONSTRAINT [FK_dbo.WorkoutExercises_Exercises] FOREIGN KEY (ExerciseId) REFERENCES Exercises(ExerciseId)
);


