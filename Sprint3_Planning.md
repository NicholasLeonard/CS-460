Sprint 3 Planning Sheet : Team Toaster Code 
=======================

## As a user I want to see a well formatted website with Dungeon related themes, graphics, and colors.
**Nicholas L. Developer**, **21 Effort Points**

### Description
-Stone and Vine theme
- Goblin pics on main page
-progress bar on workout plan is a green potion bottle
-porthole showing plan calendar
- select buttons for workout and plan progression are axe boxes or something

### Acceptance Criteria
If you go to the main page, you see some D & D themed pics and colors.
If you go to the exercise tutorial pages, the pics are on scrolls.

## As a user, I want to see and earn experience points from a workout.
**Chi L. Developer**, **13 Effort Points**

### Description
-default EXP point is 50 per workout
-added every time some one completes a workout
-fields added to our "User" table in db
-points should be displayed on the navigation bar, and on the user settings page.

### Acceptance Criteria
If the user is logged in, then the user can choose and start their workouts. Once the workouts are finished they will earn EXP points. The user should be able to see the amount of points that they have and it should be displayed on the navigation bar and on their user settings page. The user EXP data should be stored in the "User" table.

## As a user of the system, I would like to have a properly unit tested feature.
**Nicholas L. Developer**, **5 Effort Points**

## As a user of the system, I would like to have a properly unit tested feature.
**Chi L. Developer**, **5 Effort Points**

## As a user of the system, I would like to have a properly unit tested feature.
**Jace W. Developer**, **5 Effort Points**

## As a user of the system, I would like to have a properly unit tested feature.
**Alex B. Developer**, **5 Effort Points**

## As a user doing a workout, I want to complete a workout and have a history of my progress.
**Jace W. Developer**, **13 Effort Points**

### Description
A page that shows the workouts that you did in the past and time completed.
Needs
-saves completed workouts to a new user history table
-timestamp for when the workout was completed
Looks
-workout history page for the user to view what they've completed and when they completed it
Tests
-history database saved completed workouts successfully
-view of user history table with workouts and timestamp displays

### Acceptance Criteria
If you go to the user workout history page, you will see your previously completed workouts.
If you go to the user workout history page, you will see what time you completed the workout.

## As a logged in user, I want to have only one active workout at a time so that I can focus on it.
**Jace. W Developer**, **13 Effort Points**

### Description
Once you have started a workout or workout plan you shouldn't be able to start a new one unless you have finished or abandoned the previous one.
Needs
-Only one workout plan active at a time
-Only one workout active at a time
Looks
-Users will not be able to start a new workout/workout plan until they have completed/abandoned an active one
-Views restructured away from a table format, since users can only have one workout/workout plan instead of multiple
Tests
-Users are denied creating a new workout/workout plan when one is in progress

### Acceptance Criteria
If a user has a current workout or workout plan, they will not be able to start a new one.
If a user does not have a current workout or workout plan, they can create a new one.

## As a logged in user, I want to see my progress mapped to a calendar as I move through a workout plan.
**Nicholas L. Developer**, **13 Effort Points**

### Description
Displays a calendar on current workout plan that highlights number of days in the plan and displays the current day of the plan and the current day.
-detailed layout of workout
-display calendar for a workout plan
Looks
-calendar with marked workout days and times
-calendar with marked rest days

### Acceptance Criteria
If an account is just starting, then progress marks are displayed on the calendar.
If an account is two workout days into the the plan, then two progress marks are displayed on the calendar. etc.
If an account has finished the workout plan, then all progress marks are displayed on the calendar. 

## As a user, I want to accurately be able to track what stage of a workout I'm in so that I don't mistakenly believe I'm done.
**Jace W. Developer**, **21 Effort Points**

### Description
When progressing through a workout, the code shouldn't allow the user to prematurely complete the workout, despite more exercises being in it.
Needs
User should accurately see the progress move based on how many exercises are in the workout
When the user clicks an exercise on the Workout, they are given info on it and can navigate between exercises in the workout WITHOUT being sent to the exercise database entries (ie, the user workout view should be separate from the database view).
When the user navigates between exercises, they can do so WITHOUT returning to the workout page (IE each exercise has a next exercise and previous exercise button with the exception of the first and last ones).
At all points in the workout, the user can navigate back to the userworkout view and have their in progress data displayed correctly. The same can be said for each exercise in the workout

Looks
-User will see consistent stages in their workout based on where they are and how many exercises there are in the workout
Tests
-The user is prevented from completing a workout prematurely/in the middle of a workout

### Acceptance Criteria
If a user is progressing through a workout, if and only if they are at the last exercise of a workout, will they be able to complete it.

## As a user, I want to view a plethora of exercises and workouts.
**Alex B. Developer**, **21 Effort Points**

### Description
Adding seed data to the database that contains exercises and workouts and plans.
Data needs to be nationally recommended following the book posted by Alex in discord.

## As a user, I want workout plans to be displayed in an appealing and informative way.
**Alex B. Developer**, **8 Effort Points**

## Description
When I am looking at plans to start, relevant information and facts should be display, in preparation to set this up in a dungeon format.

Needs
All plans need descriptions talking about what they do and their focus
All plans need to display the rough of what the week looks like and a link to a calendar starting from the current day to the end of the plan showing workouts
All plans need a difficulty level

### Acceptance Criteria
If I click on plan to get more info, then I can see the description of the plan.
If I am viewing the details of a plan, then I can link to a rough calendar view of the plan.

## As a logged in user, I want to level up my character and earn loot.
**Chi L. Developer**, **22 Effort Points**

### Description
-The user level is displayed on navigation bar 
-The user level is displayed on the user settings page
-The user levels are depended on their current experience points
-Table for the amount of exp needed to reach the next level

### Acceptance Criteria
If the user reach certain exp points, then they can level up. The user level is displayed on both the navigation bar and user settings page. The data for amount of total exp points needed to reach certain levels should be stored in a separate table.