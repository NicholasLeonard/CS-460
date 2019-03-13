###CS Team Toaster Files
##Project Proposal: Power Level Workout


####What is new/original about this idea? What are related websites/apps? (Be able to answer the question: isn’t somebody already doing this?)

	A “gamified” workout web app that adds “rpg-lite” mechanics to a fitness regime. The user makes an account and goes through “dungeons” as workout regimen and “encounters” as workouts to do in that regimen. This makes it easier to motivate the user into sticking to a fitness routine as they play the game and develop their “characters” by improving their diet and activity level. “Gamification” of regular activities is developing field with examples like “rpg-lite” todo lists and the “Zombie Run” running app. Where our app differs is it actual provides form to these workout routines and gives the user direction via regimen suggestion rather than letting the user plan everything on their own.


####Why is this idea worth doing? Why is it useful and not boring?
	
	The reason the project is worth doing is because fitness is an ever important topic in daily living and motivation is a major factor in the issues of fitness. By presenting valid and supported knowledge about fitness in an environment that is both fun to participate in and structured properly for new and experienced users, we can help encourage proper practice and physical health improvements in the user. The idea is useful because it helps the user get health and fun because the gamification improves user participation.

####What are a few major features?

    Major features include:
    User Accounts that store fitness data of the user and other relevant information
    “Dungeons” or Workout routines adjusted to user, with scaling difficulty based on fitness level
    “Encounters” or workouts focused around user’s access to workout equipment and other items
    “Leveling” that is user stats that can scale up AND down based on their fitness level compared to either their goals, the national average, or both.
    Pictures/Videos with examples on how to do each and every exercise in a workout
    Pulling user data from Fitbit User API to fill out user accounts and update workout info
    Achievements in the form of leveling, gear, and stats for completing workouts and meeting goals consistently  
    Social Features, like party dungeons, raids, and custom dungeons, to allow users to work out and level up with friends and family

####What resources will be required for you to complete this project that are not already included in the class. i.e. you already have the Microsoft stack, server, database so what else would you need? Additional API’s, frameworks or platforms you’ll need to use.

	The primary API we would choose to implement is the Fitbit user account API. By using this particular API we can properly transfer information about the user’s fitness from the fitbit account to our website. This information is generated when the user makes an account and would simplify our project. In the future we would also like to use the Fitbit Body and Weight API and Fitbit Activity API for tracking weight and workouts between the two sites. Ultimately we want to build on the existing fitbit integration to the website to allow the user to get credit for their workouts from fitbit in our site as well as easily manage stats using the fitbit API.

####What algorithmic content is there in this project? i.e. what algorithm(s) will you have to develop or implement in order to do something central to your project idea? (Remember, this isn’t just a software engineering course, it is your CS degree capstone course!)

	The algorithmic content of the project is scaling the user’s level of fitness to the content of the workouts while staying in the recommended level of activity set by government institutions. Each “Dungeon” will generate workouts that the user can do with both their level of fitness and available workout equipment. The algorithm would take in multiple pieces of user data and generate workouts from routines with tagged sub-categories (legs, abs, body, etc). These routines would take into account completion time, difficulty, etc. In short, the algorithm dynamically handles workout routine generation on a large number of factors from the user to the “dungeon” they are in.

####Rate the topic with a difficulty rating of 1-10. One being supremely easy to implement (not necessarily short though). Ten would require the best CS students using lots of what they learned in their CS degree, plus additional independent learning, to complete successfully.

	Depending on the difficulty of the project, I would rate this topic as a difficulty of 7, difficult enough to implement via the API integration and possible social features, but not too difficult to conceptualize and algorithmically if the devs do proper research on fitness topics.