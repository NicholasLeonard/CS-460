/* DROP FKs */
ALTER TABLE	 [dbo].[ExerciseFlags]		DROP CONSTRAINT [FK_dbo.Exercises_Flags]
ALTER TABLE	 [dbo].[ExerciseEquipment]	DROP CONSTRAINT [FK_dbo.Exercises_Equipment]
ALTER TABLE  [dbo].[ExerciseImages] 	DROP CONSTRAINT [FK_dbo.Exercises_Images]

/* DROP PKs */
ALTER TABLE  [dbo].[Exercises] 			DROP CONSTRAINT [PK_dbo.Exercises]
ALTER TABLE	 [dbo].[ExerciseEquipment]	DROP CONSTRAINT [PK_dbo.ExerciseEquipment]
ALTER TABLE  [dbo].[ExerciseFlags] 		DROP CONSTRAINT [PK_dbo.ExerciseFlags]
ALTER TABLE  [dbo].[ExerciseImages] 	DROP CONSTRAINT [PK_dbo.ExerciseImages]

/* DROP all tables */
DROP TABLE [dbo].[Exercises] 	
DROP TABLE [dbo].[ExerciseFlags]
DROP TABLE [dbo].[ExerciseEquipment]
DROP TABLE [dbo].[ExerciseImages] 

GO