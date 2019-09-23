@mock_player
Feature: RollDice
Scenario: Prompt User
	When it is time for "Red" to roll the dice
	Then "Red" will be prompted to "roll dice."
	And the game will display "Red"'s resources

Scenario: Successful roll
	Given "Red" is ready to roll the dice
	And the next two dice rolls will be 4 & 4
	When "Red" rolls the dice
	Then the game is waiting for "Red" to trade
	
Scenario: Triggers the robber
	Given "Red" is ready to roll the dice
	And the next two dice rolls will be 2 & 5
	When "Red" rolls the dice
	Then the game is waiting for "Red" to rob people

Scenario: Obstinate player
	Given "Red" is ready to roll the dice
	When "Red" requests to end their turn
	Then the game is waiting for "Red" to roll the dice
	And the game will display error message "You have selected an invalid action or target for an action. Please try again."