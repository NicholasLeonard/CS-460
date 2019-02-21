/* This file is only for populating the lists of exercises, as such a list is exhaustive */
/*Items inserted:
	ID 1: Bench Press
	ID 2: Bent-over row
	ID 3: Chin-up
	ID 4: Incline flye
	ID 5: Diamond push-up
	ID 6: Dumbbell overhead press
	ID 7: Hammer-grip dumbbell bench press
	ID 8: Dumbbell triceps extension
*/

/* THE FOLLOWING CODE IS TEMPORARILY COMMENTED OUT IN FAVOR OF MORE GENERIC INFORMATION ABOUT WORKOUTS
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
*/

INSERT INTO [dbo].[Exercises]  (Name, Type, MainMuscleWorked, Instructions) VALUES
('Bench Press', 'Strength', 'Chest',
'Lie on a flat bench, holding a barbell with your hands slightly wider than shoulder-width apart using an overhand grip. 
Brace your core and press your feet into the ground, then lower the bar towards your chest. Press it back up to the start.'),
('Bent-over row', 'Strength', 'Back', 'Hold a barbell using a shoulder-width overhand grip, hands just outside your legs. 
Bend your knees slightly, then bend forwards, hingeing from the hips and keeping your shoulder blades back. 
Pull the bar up towards your sternum, leading with your elbows, then lower it back to the start.'),
('Chin-up', 'Strength', 'Back', 'Hold a chin-up bar using a shoulder-width underhand grip. Brace your core, then pull yourself 
up until your chin is higher than the bar, keeping your elbows tucked in to your body. Lower until your arms are straight again.'),
('Incline flye', 'Strength', 'Chest', 'Lie on an incline bench holding a dumbbell in each hand above your face, with your palms facing 
and a slight bend in your elbows. Lower them to the sides, then bring them back to the top.'),
('Diamond push-up', 'Strength', 'Chest', 'Start in a press-up position but with your thumbs and index fingers touching to form a diamond. 
Keeping your hips up and core braced, bend your elbows to lower your chest towards the floor. Push down through your 
hands to return to the start.'),
('Dumbbell overhead press', 'Strength', 'Anterior Deltoids', 'Sit on an upright bench holding a dumbbell in each hand at shoulder height, 
palms facing forwards. Keeping your chest up, press the weights directly overhead until your arms are straight, then lower them 
back to the start.'),
('Hammer-grip dumbbell bench press', 'Strength', 'Chest', 'Lie on a flat bench, holding dumbbells by your shoulders with palms facing. 
Drive your feet into the floor and press the weights straight up, then lower them slowly back to the start.'),
('Dumbbell triceps extension', 'Strength', 'Triceps', 'Stand tall holding a dumbbell in each hand over your head, arms straight. 
Keeping your chest up, core braced and elbows pointing up, lower the weights behind your head, then return to the start.')

/* Insert into flags table, all binary */
INSERT INTO [dbo].[ExerciseFlags] (ExerciseId, Sets, Reps, Duration, Distance, Weight) VALUES
(1, 1, 1, 0, 0, 0),
(2, 1, 1, 0, 0, 0),
(3, 1, 1, 0, 0, 0),
(4, 1, 1, 0, 0, 0),
(5, 1, 1, 0, 0, 0),
(6, 1, 1, 0, 0, 0),
(7, 1, 1, 0, 0, 0),
(8, 1, 1, 0, 0, 0)

/* Insert into Equipment table, all binary */
INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, NoEquipment, Bench, Dumbells, BarbellRack, PullupBar, Spotter) VALUES
(1, 0, 1, 0, 1, 0, 1),
(2, 0, 0, 0, 1, 0, 0),
(3, 0, 0, 0, 0, 1, 0),
(4, 0, 1, 1, 0, 0, 0),
(5, 1, 0, 0, 0, 0, 0),
(6, 0, 1, 1, 0, 0, 0),
(7, 0, 1, 1, 0, 0, 0),
(8, 0, 0, 1, 0, 0, 0)

/* Insert into Exercise Images table, lookup used for reference */
INSERT INTO [dbo].[ExerciseImages] (ExerciseId, ImageName) VALUES
(1, '1_1.jpg'),
(1, '1_2.jpg'),
(2, '2_1.jpg'),
(3, '3_1.jpg'),
(4, '4_1.jpg'),
(5, '5_1.jpg'),
(6, '6_1.jpg'),
(7, '7_1.jpg'),
(8, '8_1.jpg')