Feature: UserLoginTest
	In order to access the features of the Powerlevel website
	as an aspiring fitness gamer
	I want to be able to login to Powerlevel, the greatest fitness website in the world

	@ScopedBinding
	Scenario: Logging in with valid credentials on Powerlevel should allow me to use the sites features
	Given I have navigated to the user login page on the Powerlevel website
	And I have entered my username and password credentials
	When I press the Log in button
	Then I should navigate to the Powerlevel homepage