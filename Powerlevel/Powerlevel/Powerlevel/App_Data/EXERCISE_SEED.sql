/* This file is only for populating the lists of exercises, as such a list is exhaustive */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
	-REDESIGN: Flag and Equipment tables have been altered into One-To-Many Transaction Tables
*/


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
/* Insert into main exercise table */

/* NOTE:: The  + CHAR(13)+CHAR(10) + is for a line break and carriage return, will help in display of description */

INSERT INTO [dbo].[Exercise]  (Name, Type, MainMuscleWorked, Instructions) VALUES
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

/* Insert into flags table, all binary using Sets, Reps, Duration, Distance, Weight*/
INSERT INTO [dbo].[ExerciseFlags] (ExerciseId, FlagName) VALUES
(1, 'Sets'),(1, 'Reps'),
(2, 'Sets'),(2, 'Reps'),
(3, 'Sets'),(3, 'Reps'),
(4, 'Sets'),(4, 'Reps'),
(5, 'Sets'),(5, 'Reps'),
(6, 'Sets'),(6, 'Reps'),
(7, 'Sets'),(7, 'Reps'),
(8, 'Sets'),(8, 'Reps')

/* Insert into Equipment table, all binary using NoEquipment, Bench, Dumbells, BarbellRack, PullupBar, Spotter*/
INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, EquipmentName) VALUES
(1, 'Bench'),(1, 'Barbell Rack'),(1, 'Spotter'),
(2, 'Barbell Rack'),
(3, 'Pullup Bar'),
(4, 'Bench'),(4, 'Dumbells'),
(5, 'No Equipment'),
(6, 'Bench'),(6, 'Dumbells'),
(7, 'Bench'),(7, 'Dumbells'),
(8, 'Dumbells')

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