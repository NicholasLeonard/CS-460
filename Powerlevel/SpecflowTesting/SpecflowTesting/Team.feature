Feature: Team
	In order to have a fair competition
	As a user
	I want to not be able to team up with myself, so that I won't recieve more exp by abusing the team-up system

@mytag
Scenario: User can't team up with themselves
	Given I have logged in
	And navgated to my user profile
	When I click the teamup button
	Then the page remain unchanged
