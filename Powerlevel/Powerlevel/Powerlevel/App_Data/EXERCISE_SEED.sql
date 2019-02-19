/* This file is only for populating the lists of exercises, as such a list is exhaustive */
/*Items inserted:
	ID 1: Pushup
*/

/* Insert into main exercise table */
/* NOTE:: The  + CHAR(13)+CHAR(10) + is for a line break and carriage return, will help in display of description */
INSERT INTO [dbo].[Exercises]  (Name, Type, MainMuscleWorked, Instructions) VALUES
( 'Pushup',
'Strength',
'Chest',
'1. Lie on the floor face down and place your hands about 36 inches apart while holding your torso up at arms length.' +  + CHAR(13)+CHAR(10) +
'2. Next, lower yourself downward until your chest almost touches the floor as you inhale.'  + CHAR(13)+CHAR(10) +
'3. Now breathe out and press your upper body back up to the starting position while squeezing your chest.'  + CHAR(13)+CHAR(10) +
'4. After a brief pause at the top contracted position, you can begin to lower yourself downward again for as many repetitions as needed.')


/* Insert into flags table, all binary */
INSERT INTO [dbo].[ExerciseFlags] (ExerciseId, Sets, Reps, Duration, Distance, Weight) VALUES
( 1, 1, 1, 0, 0, 0)

/* Insert into Equipment table, all binary */
INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, NoEquipment, Bench, Dumbells, BarbellRack, PullupBar, Spotter) VALUES
( 1, 1, 0, 0, 0, 0, 0)

/* Insert into Exercise Images table, lookup used for reference */
INSERT INTO [dbo].[ExerciseImages] (ExerciseId, ImageName) VALUES
(1, '1_1.jpg'),
(1, '1_2.jpg')