/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
	-REFACTOR: Changed all Foreign Keys to follow format FK_[Tableitisin]_[Tableitrefences]
	-REDESIGN: Flag and Equipment tables have been altered into One-To-Many Transaction Tables
*/


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
