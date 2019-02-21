/*
CREATE the table for Exercises
*/
CREATE TABLE [dbo].[Exercises]
(
	[ExerciseId] INT IDENTITY(1,1) NOT NULL, 
    [Name] NCHAR(128) NOT NULL, 
    [Type] NCHAR(64) NOT NULL, 
    [MainMuscleWorked] NCHAR(64) NOT NULL,
    [Instructions] NVARCHAR(3000) NOT NULL,
	CONSTRAINT [PK_dbo.Exercises] PRIMARY KEY CLUSTERED ([ExerciseId] ASC)
);

/*
CREATE the table for Exercise's Flags
*/
CREATE TABLE [dbo].[ExerciseFlags]
(
	[FlagId] INT IDENTITY(1,1) NOT NULL,
	[ExerciseId] INT NOT NULL,
	[Sets] BIT,
	[Reps] BIT,
	[Duration] BIT,
	[Distance] BIT,
	[Weight] BIT,
	CONSTRAINT [PK_dbo.ExerciseFlags] PRIMARY KEY CLUSTERED ([FlagId] ASC),
	CONSTRAINT [FK_dbo.Exercises_Flags] FOREIGN KEY (ExerciseId) REFERENCES Exercises(ExerciseId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

/*
CREATE the table for Exercise's required equipment
*/
CREATE TABLE [dbo].[ExerciseEquipment]
(
	[RequirementId] INT IDENTITY(1,1) NOT NULL,
	[ExerciseId] INT NOT NULL,
	[NoEquipment] BIT,
	[Bench] BIT,
	[Dumbells] BIT,
	[BarbellRack] BIT,
	[PullupBar] BIT,
	[Spotter] BIT,
	CONSTRAINT [PK_dbo.ExerciseEquipment] PRIMARY KEY CLUSTERED ([RequirementId] ASC),
	CONSTRAINT [FK_dbo.Exercises_Equipment] FOREIGN KEY (ExerciseId) REFERENCES Exercises(ExerciseId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

/*
Create the table for Exercise Images
*/
CREATE TABLE [dbo].[ExerciseImages]
(
	[ImageId] INT IDENTITY(1,1) NOT NULL,
	[ExerciseId] INT NOT NULL,
	[ImageName] NCHAR(128) NOT NULL, 
	CONSTRAINT [PK_dbo.ExerciseImages] PRIMARY KEY CLUSTERED ([ImageId] ASC),
	CONSTRAINT [FK_dbo.Exercises_Images] FOREIGN KEY (ExerciseId) REFERENCES Exercises(ExerciseId)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
);