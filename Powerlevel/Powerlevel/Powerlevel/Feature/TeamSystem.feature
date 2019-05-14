Feature: TeamSystem
	In order to test team up system is working
	As a developer
	I want to ensure functionality is working and bug free

Scenario:  User can team up with mutliple members
	Given I have logged in and navigated to other user's profile
	And I have not already teamed up with the user
	When I press the join team button
	Then it should redirect the user to their own user profile page
