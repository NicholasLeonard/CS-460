/* This is the DOWN Script for Workout Plans */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
	-REFACTOR: Changed all Foreign Keys to follow format FK_[Tableitisin]_[Tableitrefences]
	-REFACTOR: Plan is a reserved word ins SQL, changed table names to WorkoutPlan and WorkoutPlanWorkout to reflect this
*/

/* DROP all tables */
DROP TABLE IF EXISTS [dbo].[WorkoutPlan] 
DROP TABLE IF EXISTS [dbo].[WorkoutPlanWorkout]

GO