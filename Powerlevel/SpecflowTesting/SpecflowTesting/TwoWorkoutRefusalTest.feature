Feature: TwoWorkoutRefusalTest
	In order to workout on the Powerlevel website
	as an aspiring fitness gamer
	I want to be able to create one, and only one workout, without making a second one on accident

	@ScopedBinding
	Scenario: Creating a first workout should take me to the Confirmation page, redirecting to the Create page to try and create a second workout should be prevented and return me to the index page
	Given I have logged into the Powerlevel website and have navigated to the Create Free Workout page
	And I have selected the workout I would like to create
	When I press the Start Workout button
	Then I am taken to the Confirmation page
	When I manually redirect to the Create Free Workout page and press the Start Workout button again
	Then I am taken to the Index page
	Then I abandon the single workout
