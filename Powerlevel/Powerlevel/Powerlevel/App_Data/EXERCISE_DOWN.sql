/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
*/
/* DROP FKs */
ALTER TABLE     [dbo].[ExerciseFlag]        DROP CONSTRAINT [FK_dbo.ExerciseFlag_Exercise]
GO
ALTER TABLE     [dbo].[ExerciseEquipment]    DROP CONSTRAINT [FK_dbo.ExerciseEquipment_Exercise]
GO
ALTER TABLE  [dbo].[ExerciseImage]     DROP CONSTRAINT [FK_dbo.ExerciseImage_Exercise]
GO

/* DROP PKs */
ALTER TABLE  [dbo].[Exercise]             DROP CONSTRAINT [PK_dbo.Exercise]
GO
ALTER TABLE     [dbo].[ExerciseEquipment]    DROP CONSTRAINT [PK_dbo.ExerciseEquipment]
GO
ALTER TABLE  [dbo].[ExerciseFlag]         DROP CONSTRAINT [PK_dbo.ExerciseFlag]
GO
ALTER TABLE  [dbo].[ExerciseImage]     DROP CONSTRAINT [PK_dbo.ExerciseImage]
GO

/* DROP all tables */
DROP TABLE IF EXISTS [dbo].[Exercise] 	
DROP TABLE IF EXISTS [dbo].[ExerciseFlag]
DROP TABLE IF EXISTS [dbo].[ExerciseEquipment]
DROP TABLE IF EXISTS [dbo].[ExerciseImage] 

GO