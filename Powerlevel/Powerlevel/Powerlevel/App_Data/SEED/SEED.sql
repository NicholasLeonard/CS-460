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
	ID 9: Lat Pull Down
	ID 10: Leg Press
	ID 11: Lying Leg Curl
	ID 12: Rope Pressdown
	ID 13: Barbell Biceps Curl
	ID 14: Standing Calf Raise
	ID 15: Crunches
	ID 16: Rest
	ID 17: Dumbell Bench Press
	ID 18: Dumbell Flye
	ID 19: Dumbell Lateral Raise
	ID 20: Preacher Curl With Cable
	ID 21: Lying EZ-Bar Triceps Extension
	ID 22: Seated Leg Curl
	ID 23: Seated Calf Raise
	ID 24: Incline Barbell Bench Press
	ID 25: Barbell Rack Upright Row
	ID 26: Dumbell Kickbacks
	ID 27: Single-Arm Neutral-Grip Dumbell Row
	ID 28: Incline Dumbell Biceps Curl
	ID 29: Reverse Crunch
	ID 30: Back Squat
	ID 31: Romanian Deadlift
	ID 32: Push-Ups
	ID 33: Pylo Push-Ups
	ID 34: Ab-Draw Leg Slides
	ID 35: Air Bike
	ID 36: Plank
	ID 37: Lying Knee Raise
	ID 38: Body-Weight Lunges
	ID 39: Body-Weight Side Lunges
	ID 40: Prisoner Squats
	ID 41: Body-Weight Standing Calf Raise

*/
/* Insert into main exercise table */
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
Keeping your chest up, core braced and elbows pointing up, lower the weights behind your head, then return to the start.'),
('Lat Pull Down', 'Strength', 'Back', 'Sit at a lat pulldown station and grab the bar with an overhand grip that is just beyond shoulder width.
Your arms should be completely straight and your torso upright. Pull your shoulder blades down and back, and bring the bar to your chest. 
Pause, then slowly return to the starting position.'),
('Leg Press', 'Strength', 'Legs', 'Adjust the seat of the machine so that you can sit comfortably with your hips beneath your knees and your knees in line with your feet.
Remove the safeties and lower your knees toward your chest until they’re bent 90 degrees and then press back up.
Be careful not to go too low or you risk your lower back coming off the seat (which can cause injury).')
GO

INSERT INTO [dbo].[Exercise]  (Name, Type, MainMuscleWorked, Instructions) VALUES
('Lying Leg Curl', 'Strength', 'Hamstrings', 'Lie face down on a leg curl machine and hold handles. 
Curl your legs as far as possible, hold for a sec, then curl back down to the starting position.'),
('Rope Pressdown', 'Strength', 'Biceps', 'Facing an adjustable cable machine, grab the rope attachment from the high setting with a thumbs-up grip.
Bring your elbows to your sides so that your forearms are parallel to the floor. Extend your forearms straight down while twisting the rope inward so that your knuckles face the floor when your arms are fully extended.
Pause, then return to the start position.'),
('Barbell Biceps Curl', 'Strength', 'Biceps', 'Grab a barbell with an underhand grip and let it hang with arms fully extended and palms facing forward.
Begin to raise the barbell to your neck level only using your biceps. Once you reach the peak, slowly lower the bar to starting position.' ),
('Standing Calf Raise', 'Warmup', 'Calves', 'Stand in a shoulder-width stance with your toes flat on the edge of a box or step with your heels and mid-foot hanging off the edge so you feel a stretch in your calf. 
Use the wall or a rail as a support to stay balanced. This is your starting position. 
Push your toes into the box so your heels raise up, pause, then lower yourself back to the starting position, being sure to feel a stretch in your calves.'),
('Crunches', 'Strength', 'Abs', 'Lie flat on your back and place your hands behind your head. Bend your knees and firmly plant your feet on the floor.
This is your starting position. With your elbows flared, tighten your abs, and lift your shoulders and upper back off of the floor.
Hold at the top for a second and then retract back down to starting position.'),
('Rest', 'None', 'None', 'Today is a rest day, enjoy time away from the gym.'),
('Dumbell Bench Press', 'Strength', 'Chest', 'Lying on your back on a bench, hold a pair of dumbbells directly above your sternum with your arms fully extended.
Pull your shoulder blades together, slightly stick out your chest, and point your palms forward. Slowly lower both dumbbells to the sides of your chest.
Pause, then press the dumbbells back to the starting position.'),
('Dumbell Flye', 'Strength', 'Chest', 'Grab a pair of dumbbells with an overhand grip and lie face up on a flat bench. 
Extend arms out to sides so that they are parallel to the ground and dumbbells are at chest level. In a controlled motion, raise arms so that palms are facing each other and dumbbells are directly over chest. 
Pause and squeeze chest muscles together at top of movement. Slowly lower the dumbbells in an arc down and away from your body. 
Once the dumbbells are almost in line with chest, reverse the movement back to the starting position.'),
('Dumbell Lateral Raise', 'Strength', 'Delts', 'Standing in a shoulder-width stance, grab a pair of dumbbells with palms facing inward and let them hang at your sides.
Raise your arms out to the sides until they are at shoulder level. Pause, then lower the weights back to the starting position.'),
('Preacher Curl With Cable', 'Strength', 'Biceps', 'Place a preacher bench in front of a cable machine with an EZ-Bar on the lowest setting.
Resting your arms on the padding, hold the bar with both hands, palms facing away from you. Without moving your elbows, curl the bar toward your shoulders. 
Pause, then slowly return the bar to the starting position.')
GO

INSERT INTO [dbo].[Exercise]  (Name, Type, MainMuscleWorked, Instructions) VALUES
('Lying EZ-Bar Triceps Extension', 'Strength', 'Triceps', 'Lie on your back on a bench while holding a loaded EZ-Bar with an overhand grip, your hands almost shoulder-width apart.
Hold the bar directly above your head with your arms fully extended. Keeping your elbows locked in place, lower the bar until it is about an inch above your forehead.
Pause, then contract your triceps to return the bar to the starting position.'),
('Seated Leg Curl', 'Strength', 'Thighs', 'Sit in a legs curl machine, grasping the handles. Press your legs down as far a possible then return to starting position.'),
('Seated Calf Raise', 'Warmup', 'Calves', 'Sit on a box or bench with your feet flat on the floor in front of you. Flex your calves as high as possible before returning back to the starting position.'),
('Incline Barbell Bench Press', 'Strength', 'Chest', 'Position your body on an incline bench on a 30-45 degree angle. 
Grab a barbell with an overhand grip that is shoulder-width apart and hold it above your chest. Extend arms upward, locking out elbows. Lower the bar straight down in a slow, controlled movement to your chest.
Pause, then press the bar in a straight line back up to the starting position.'),
('Barbell Rack Upright Row', 'Strength', 'Biceps', 'Set the bar in the rack slightly above knee height and grip the bar using a double-overhand grip.
Make sure your palms are facing towards you and your hands are spaced about six inches apart. Raise the bar to chest height, pause, and then slowly lower the weight back to the starting position.'),
('Dumbell Kickbacks', 'Strength', 'Deltoids', 'Kneel over one side of a weight bench by placing one knee and one hand on the bench. Position the standing leg slightly back and to the side with the foot firmly planted on the floor.
The torso should be parallel to the floor. Grab a dumbbell with the free hand with an overhand grip and position the elbow at your side so the upper arm is parallel to the floor.
Keeping the upper arm stationary, extend the arm behind you by contracting the triceps. Pause for one second at the top and then return to the start position.'),
('Single-Arm Neutral-Grip Dumbell Row', 'Strength', 'Biceps', 'Holding a dumbbell in one hand with arm fully extended, bend at the hips until your torso is at approximately a 30-degree angle to the floor.
Without moving your torso, row the dumbbell upward toward your shoulder until it touches your lower chest. Pause, then lower the dumbbell back to start.'),
('Incline Dumbell Bicep Curl', 'Strength', 'Biceps', 'Grab a pair of dumbbells and sit down on an incline bench positioned at a 45-degree angle. 
Pull your shoulder blades back and let the dumbbells hang at your sides with your palms facing forward. Curl the dumbbells up, bending the elbows and bringing both weights to your shoulders. 
Pause, then lower your arms back to starting position.'),
('Reverse Crunch', 'Strength', 'Abs', 'Lie on your back with your knees together and your legs bent to 90 degrees, feet planted on the floor. 
Place your palms face down on the floor for support. Tighten your abs to lift your hips off the floor as you crunch your knees inward to your chest. 
Pause at the top for a moment, then lower back down without allowing your lower back to arch and lose contact with the floor.'),
('Back Squat', 'Strength', 'Glutes', 'Standing in a shoulder-width stance with feet slightly pointed out, rest a loaded barbell across the back of your shoulders holding it with an overhand grip.
Descend into a squat position by pushing your hips back and bending at the knee. At the bottom of the squat, pause, and then drive your hips upward bringing you back to starting position.')
GO


INSERT INTO [dbo].[Exercise]  (Name, Type, MainMuscleWorked, Instructions) VALUES
('Romanian Deadlift', 'Strength', 'Hamstrings', 'Hold the bar in front of your thighs with a shoulder-width grip. Pull it in toward your body—don’t let it drift in front of you. 
Drive your hips back and lower your torso, allowing your knees to bend as needed, until you feel a stretch in your hamstrings. Extend your hips to come back up.'),
('Push-Ups', 'Strength', 'Chest', 'Start off by lying face down on the floor or on a mat with your feet together and arms shoulder width apart. 
Slowly draw your abs in, inhale and raise your body off of the floor until your arms are straight, keeping your head and neck level with your body as this will be your starting position.
As you lower yourself down towards the ground, exhale until your chest almost touches the ground and you feel a stretch in your chest muscles.
Hold for a count at the bottom position and then return back up to the starting position.'),
('Pylo Push-Ups', 'Strength', 'Chest', 'Start off in a prone push up position on the floor with your arms fully extended at shoulder width and keeping your body straight.
Slowly descend to the ground by flexing through your elbows, lowering your chest towards the ground until you feel a tension in your chest.
As soon as you feel a stretch in your muscle quickly push yourself back up so that your hands leave the ground.
Return back to the starting position and repeat for as many reps and sets as desired'),
('Ab-Draw Leg Slides', 'Strength', 'Abs', 'Start off laying on your back with your knees bent at 90 degrees and keeping your arms at your sides, palms up.
Maintaining slight pressure on your hands, extend your legs slowly forward so that you feel a stretch and squeeze on your abdominals.
Return back to the starting position and repeat for as many reps and sets desired.'),
('Air Bike', 'Strength', 'Abs', 'Start off lying flat as if you were going to perform a sit up putting your hands behind your your head and lifting your shoulders into a crunch position.
Bring your knees up so that they are perpendicular with the floor and your lower legs are parallel with the ground as this will be your starting position.
Slowly go through a cycle pedal motion kicking forward with your right leg and bringing in the knee of the left leg.
Next bring your right elbow close to your left knee by crunching to the side.
Return back to the starting position as you breathe in then crunch to the opposite side as you cycle your legs and bring your left elbow close to your right knee.
Repeat with each side for as many reps and sets as desired.'),
('Plank', 'Strength', 'Abs', 'Start off by kneeling on all fours and aligning both hands right below your shoulders keep your knees beneath your hips.
Extend both of your feet out behind you and squeeze on your core muscles, making sure that your body is aligned straight 
Hold this position for about 30 seconds to a minute (or longer depending on the workout).
Release, return back to the starting position and repeat for as many times as you would like to perform this exercise.'),
('Lying Knee Raise', 'Strength', 'Abs', 'Start off laying with your back flat on the floor, arms at your side and feet extended out straight in front of you.
Slowly lift both of your knees up off of the floor and pull them towards your chest. Feel a stretch in your abdominals then return your knees back to the starting position.
Repeat for as many reps and sets as desired.'),
('Bodyweight Lunges', 'Strength', 'Glutes', 'Start off standing up straight with your knees slightly bent then get into a lunge position, and squat down through your hips.
Squat down so that your front leg is parallel with the floor and hold for a count. Return back to the starting position. Repeat for as many reps and sets as desired.'),
('Bodyweight Side Lunges', 'Strength', 'Glutes', 'Start off standing up straight with a slight bend in your knees. Step out to your side with your left leg and squat down through your hips.
Lower yourself towards the floor so that your front leg is parallel with the floor and hold for a count. Return back to the starting position. 
Repeat for as many reps and sets as desired.'),
('Prisoner Squats', 'Strength', 'Upper Legs', 'Start off by standing up straight with wide feet and your hands behind your head.
Slowly lower your body in a controlled squat, extending your hips and knees feeling a stretch in your thighs and glutes.
Return back to the starting position and repeat for as many reps and sets as desired.')
GO

INSERT INTO [dbo].[Exercise]  (Name, Type, MainMuscleWorked, Instructions) VALUES
('Bodyweight Standing Calf Raise', 'Strength', 'Lower Legs', 'Start off setting up either a step or a block next to either a support structure or smith machine.
Place the balls of your feet on the edge of the block/step and let your heels drop down towards the floor as far as possible.
Then slowly raise your heels up as high as possible, squeezing your calves and hold for a count. Return back to the starting position.
Repeat for as many reps and sets as desired.')
GO

/* Insert into flags table, all binary using Sets, Reps, Duration, Distance, Weight*/
INSERT INTO [dbo].[ExerciseFlag] (ExerciseId, FlagName) VALUES
(1, 'Sets'),(1, 'Reps'),(1, 'Weight'),
(2, 'Sets'),(2, 'Reps'),(2, 'Weight'),
(3, 'Sets'),(3, 'Reps'),
(4, 'Sets'),(4, 'Reps'),(4, 'Weight'),
(5, 'Sets'),(5, 'Reps'),
(6, 'Sets'),(6, 'Reps'),(6, 'Weight'),
(7, 'Sets'),(7, 'Reps'),(7, 'Weight'),
(8, 'Sets'),(8, 'Reps'),
(9, 'Sets'),(9, 'Reps'),(9, 'Weight'),
(10, 'Sets'),(10, 'Reps'),(10, 'Weight')
GO

INSERT INTO [dbo].[ExerciseFlag] (ExerciseId, FlagName) VALUES
(11, 'Sets'),(11, 'Reps'),
(12, 'Sets'),(12, 'Reps'),(12, 'Weight'),
(13, 'Sets'),(13, 'Reps'),(13, 'Weight'),
(14, 'Sets'),(14, 'Reps'),
(15, 'Sets'),(15, 'Reps'),
(16, 'Duration'),
(17, 'Sets'),(17, 'Reps'),(17, 'Weight'),
(18, 'Sets'),(18, 'Reps'),(18, 'Weight'),
(19, 'Sets'),(19, 'Reps'),(19, 'Weight'),
(20, 'Sets'),(20, 'Reps'),(20, 'Weight')
GO

INSERT INTO [dbo].[ExerciseFlag] (ExerciseId, FlagName) VALUES
(21, 'Sets'),(21, 'Reps'),(21, 'Weight'),
(22, 'Sets'),(22, 'Reps'),(22, 'Weight'),
(23, 'Sets'),(23, 'Reps'),
(24, 'Sets'),(24, 'Reps'),(24, 'Weight'),
(25, 'Sets'),(25, 'Reps'),(25, 'Weight'),
(26, 'Sets'),(26, 'Reps'),(26, 'Weight'),
(27, 'Sets'),(27, 'Reps'),(27, 'Weight'),
(28, 'Sets'),(28, 'Reps'),(28, 'Weight'),
(29, 'Sets'),(29, 'Reps'),
(30, 'Sets'),(30, 'Reps'),(30, 'Weight')
GO

INSERT INTO [dbo].[ExerciseFlag] (ExerciseId, FlagName) VALUES
(31, 'Sets'),(31, 'Reps'),(31, 'Weight'),
(32, 'Sets'),(32, 'Reps'),
(33, 'Sets'),(33, 'Reps'),
(34, 'Sets'),(34, 'Reps'),
(35, 'Sets'),(35, 'Reps'),
(36, 'Sets'),(36, 'Duration'),
(37, 'Sets'),(37, 'Reps'),
(38, 'Sets'),(38, 'Reps'),
(39, 'Sets'),(39, 'Reps'),
(40, 'Sets'),(40, 'Reps')
GO

INSERT INTO [dbo].[ExerciseFlag] (ExerciseId, FlagName) VALUES
(41, 'Sets'),(41, 'Reps')
GO

/* Insert into Equipment table, all binary using NoEquipment, Bench, Dumbells, BarbellRack, PullupBar, Spotter*/
INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, EquipmentName) VALUES
(1, 'Bench'),(1, 'Barbell Rack'),(1, 'Spotter'),
(2, 'Barbell Rack'),
(3, 'Pullup Bar'),
(4, 'Bench'),(4, 'Dumbells'),
(5, 'No Equipment'),
(6, 'Bench'),(6, 'Dumbells'),
(7, 'Bench'),(7, 'Dumbells'),
(8, 'Dumbells'),
(9, 'Ajustable Cable Machine'),
(10, 'Leg Press Machine')
GO

INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, EquipmentName) VALUES
(11, 'Leg Curl Machine'),
(12, 'Ajustable Cable Machine'),
(13, 'Barbell'),
(14, 'Box'),
(15, 'No Equipment'),
(16, 'No Equipment'),
(17, 'Bench'),(17, 'Dumbells'),
(18, 'Bench'),(18, 'Dumbells'),
(19, 'Dumbells'),
(20, 'Adjustable Cable Machine')
GO

INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, EquipmentName) VALUES
(21, 'EZ-Bar'), (21, 'Bench'),
(22, 'Leg Curl Machine'),
(23, 'Bench'),
(24, 'Bench'), (24, 'Barbell'),
(25, 'Barbell Rack'), (25, 'Barbell'),
(26, 'Dumbells'), (26, 'Bench'),
(27, 'Dumbells'),
(28, 'Dumbells'),(28, 'Bench'),
(29, 'No Equipment'),
(30, 'Bench'), (30, 'Barbell')
GO

INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, EquipmentName) VALUES
(31, 'Barbell'),
(32, 'No Equipment'),
(33, 'No Equipment'),
(34, 'No Equipment'),
(35, 'No Equipment'),
(36, 'No Equipment'),
(37, 'No Equipment'),
(38, 'No Equipment'),
(39, 'No Equipment'),
(40, 'No Equipment')
GO

INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, EquipmentName) VALUES
(41, 'No Equipment')
GO


/* Insert into Exercise Images table, lookup used for reference */
INSERT INTO [dbo].[ExerciseImage] (ExerciseId, ImageName) VALUES
(1, '1_1.jpg'),
(1, '1_2.jpg'),
(2, '2_1.jpg'),
(3, '3_1.jpg'),
(4, '4_1.jpg'),
(5, '5_1.jpg'),
(6, '6_1.jpg'),
(7, '7_1.jpg'),
(8, '8_1.jpg')
GO


/* This file is only for populating the lists of workouts, as such a list is exhaustive */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
*/

/* Create the table that contains various workouts, whether they are strength or cardio,
the muscle group that it focuses on, and approximately how long the full workout takes to complete */
INSERT INTO [dbo].[Workout] (Name, Type, MainMuscleFocus, TimeEstimate, ExpReward) VALUES
('Upper Body Hellhole', 'Strength', 'Chest', '30 Minutes', 50),
('Burning Back', 'Strength', 'Back', '45 Minutes', 50),
('Beginner Full Body Gym', 'Strength', 'Full Body', '60 Minutes', 50),
('Rest Day', 'None', 'Full Body', '24 Hours', 50),
('Beginner Upper Body Gym', 'Strength', 'Upper Body', '60 Minutes', 50),
('Beginner Lower Body Gym', 'Strength', 'Lower Body', '60 Minutes', 50),
('Beginner Push Gym', 'Strength', 'Biceps', '60 Minutes', 50),
('Beginner Pull Gym', 'Strength', 'Chest', '60 Minutes', 50),
('Beginner Legs Gym', 'Strength', 'Legs', '60 Minutes', 50),
('Beginner Chest, Triceps, Calves Gym', 'Strength', 'Chest, Triceps, Calves', '60 Minutes', 50),
('Beginner Legs and Abs Gym', 'Strength', 'Legs, Abs', '60 Minutes', 50),
('Beginner Sholders and Calves Gym', 'Strength','Shoulders, Calves', '60 Minutes', 50),
('Beginner Back, Biceps, Abs Gym', 'Strength', 'Back, Biceps, Abs', '60 Minutes', 50),
('Beginner Body-Only Chest and Arms', 'Strength', 'Chest, Biceps, Triceps', '30 Minutes', 50),
('Beginner Body-Only Core', 'Strength', 'Abs', '40 Minutes', 50),
('Beginner Body-Only Legs', 'Strength', 'Glutes, Hamstrings', '30 Minutes', 50)

/* Links each workout exercise to a workout, an exercise, and an order to complete the workout */
INSERT INTO [dbo].[WorkoutExercise] (WorkoutId, ExerciseId, OrderNumber) VALUES
(1,1,1),(1,5,2),(1,4,3),
(2,2,1),(2,3,2),(2,7,3),
(3,17,1),(3,9,2),(3,6,3),(3,10,4),(3,11,5),(3,12,6),(3,13,7),(3,14,8),(3,15,9),
(4,16,1),
(5,1,1),(5,18,2),(5,2,3),(5,9,4),(5,6,5),(5,19,6),(5,13,7),(5,20,8),(5,21,9),(5,12,10),(5,15,11),
(6,10,1),(6,11,2),(6,22,3),(6,14,4),(6,23,5),
(7,24,1),(7,18,2),(7,6,3),(7,25,4),(7,21,5),(7,26,6),
(8,25,1),(8,27,2),(8,28,3),(8,20,4),(8,29,5),(8,15,6),
(9,30,1),(9,10,2),(9,22,3),(9,31,4),(9,14,5),(9,23,6),
(10,21,1),(10,17,2),(10,18,3),(10,12,4),(10,26,5),(10,21,6),(10,14,7),(10,23,8),
(11,30,1),(11,10,2),(11,11,3),(11,31,4),(11,22,5),(11,29,6),(11,15,7),
(12,6,1),(12,25,2),(12,19,3),(12,23,4),
(13,2,1),(13,9,2),(13,27,3),(13,13,4),(13,28,5),(13,20,6),(13,15,7),
(14,32,1),(14,33,2),(14,5,3),(14,32,4),(14,33,5),(14,5,6),
(15,15,1),(15,34,2),(15,35,3),(15,36,4),(15,37,5),(15,15,6),(15,36,7),
(16,38,1),(16,39,2),(16,40,3),(16,41,4),(16,38,5),(16,39,6)
GO

INSERT INTO [dbo].[WorkoutPlan] (Name, Type, Description, DaysToComplete, NumberOfWorkouts) VALUES
('Chest and Back Plan', 'Upper-Body', 'The core of this plan works out your chest and back, with most of the workouts also 
strengthening your triceps.', 2, 2),
('4 Week Beginner Gym Plan', 'Full Body', 'Think of this as the accelerated guide to body-building.
In this plan, your first month of training will be demanding, but not so demanding as to cause injury. 
This program isn’t just for the true beginner who has never touched a weight before;
it’s also suitable for anyone who has taken an extended leave of absence from training.', 28, 18),
('3 Week Beginner Bodyweight Plan', 'Full Body', 'This plan is for those who need help getting back into a fitness plan or simply do not have access to any equipment to
work out with. All exercises in the plan require nothing more than your own motivation to complete. The plan takes places over the course of 3 weeks with a minor spike in
intensity in the third week.', 21, 14)


/* Table to connect the plan to a workout via PlanID and WorkoutID, 
as well as display which day of the plan the workout should be completed */
INSERT INTO [dbo].[WorkoutPlanWorkout] (PlanId, WorkoutId, DayOfPlan) VALUES
(1,1,1),(1,2,2),
/*4 Week Beginner Plan, org weekly*/
(2,3,1),(2,4,2),(2,3,3),(2,4,4),(2,3,5),(2,4,6),(2,4,7),
(2,5,8),(2,6,9),(2,4,10),(2,5,11),(2,6,12),(2,4,13),(2,4,14),
(2,7,15),(2,8,16),(2,9,17),(2,7,18),(2,8,19),(2,9,20),(2,4,21),
(2,10,22),(2,11,23),(2,4,24),(2,12,25),(2,13,26),(2,4,27),(2,4,28),
/*3 Week BW Beginner Plan*/
(3,14,1),(3,4,2),(3,4,3),(3,15,4),(3,4,5),(3,4,6),(3,16,7),
(3,4,8),(3,14,9),(3,16,10),(3,15,11),(3,14,12),(3,16,13),(3,4,14),
(3,14,15),(3,15,16),(3,16,17),(3,4,18),(3,14,19),(3,15,20),(3,16,21)
GO

-- data format: LEVEL, EXP NEEDED, max level is 20 for now
INSERT INTO [dbo].[LevelExp] (Level, Exp) VALUES
(1,0),
(2,100),
(3,200),
(4,300),
(5,400),
(6,500),
(7,600),
(8,700),
(9,800),
(10,900),
(11,1000),
(12,1100),
(13,1200),
(14,1300),
(15,1400),
(16,1500),
(17,1600),
(18,1700),
(19,1800),
(20,1900),
(21,99999999)
GO

/* Seed all avatar parts */
INSERT INTO [dbo].[Avatar] (Name, Imagefile, Type, Race) VALUES
('human1','human1.PNG', 'Body', 'human'),
('human2','human2.PNG', 'Body', 'human'),
('human3','human3.PNG', 'Body', 'human'),
('human4','human4.PNG', 'Body', 'human'),
('elf1', 'elf1.PNG', 'Body', 'elf'),
('elf2','elf2.PNG', 'Body','elf'),
('elf3','elf3.PNG', 'Body','elf'),
('elf4','elf4.PNG', 'Body','elf'),
('dwarf1','dwarf1.PNG', 'Body','dwarf'),
('dwarf2','dwarf2.PNG', 'Body','dwarf'),
('orc1','orc1.PNG', 'Body','orc'),
('orc2','orc2.PNG', 'Body','orc'),
('goblin1','goblin1.PNG', 'Body','goblin'),
('goblin2','goblin2.PNG', 'Body','goblin')
GO

/* Do All Weapon Inserts */
INSERT INTO [dbo].[Avatar] (Name, Imagefile, Type, Race) VALUES
('none', 'none.png', 'Weapon', 'human'),
('none', 'none.png', 'Weapon', 'elf'),
('none', 'none.png', 'Weapon', 'orc'),
('none', 'none.png', 'Weapon', 'dwarf'),
('none', 'none.png', 'Weapon', 'goblin'),
('ironsword','humansword1.PNG', 'Weapon', 'human'),
('ironsword','elfsword1.PNG', 'Weapon', 'elf'),
('ironsword','orcsword1.PNG', 'Weapon', 'orc'),
('ironsword','dwarfsword1.PNG', 'Weapon', 'dwarf'),
('ironsword','goblinsword1.PNG', 'Weapon', 'goblin'),
('ironaxe','humanaxe1.PNG','Weapon','human'),
('ironaxe','elfaxe1.PNG','Weapon','elf'),
('ironaxe','orcaxe1.PNG','Weapon','orc'),
('ironaxe','dwarfaxe1.PNG','Weapon','dwarf'),
('ironaxe','goblinaxe1.PNG','Weapon','goblin'),
('ironspear','humanspear1.PNG','Weapon','human'),
('ironspear','elfspear1.PNG','Weapon','elf'),
('ironspear','orcspear1.PNG','Weapon','orc'),
('ironspear','dwarfspear1.PNG','Weapon','dwarf'),
('ironspear','goblinspear1.PNG','Weapon','goblin')
GO

/* Do all Armor Inserts */
INSERT INTO [dbo].[Avatar] (Name, Imagefile, Type, Race) VALUES
('none', 'none.png', 'Armor', 'human'),
('none', 'none.png', 'Armor', 'elf'),
('none', 'none.png', 'Armor', 'orc'),
('none', 'none.png', 'Armor', 'dwarf'),
('none', 'none.png', 'Armor', 'goblin')
GO