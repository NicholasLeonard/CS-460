CREATE TABLE [dbo].[Exercises]
(
	[ExerciseId] INT IDENTITY(0,1) NOT NULL, 
    [Name] NCHAR(100) NOT NULL, 
    [Type] NCHAR(64) NOT NULL, 
    [MainMuscleWorked] NCHAR(64) NOT NULL, 
    [Instructions] NCHAR(3000) NOT NULL,
	CONSTRAINT [PK_dbo.Exercises] PRIMARY KEY CLUSTERED ([ExerciseID] ASC)
);