@mock_player
Feature: Trade

Scenario: Prompt User To Trade
	When it is time for "Orange" to trade
	Then "Orange" will be prompted to "select harbor or 4:1 to trade or move to build phase"

Scenario: Trade at Harbor Enough Resources
	Given "Red" is ready to trade
	And "Red" owns intersection 0
	And "Red" is rich
	When "Red" requests to trade at a harbor
	Then the game is waiting for "Red" to do trade

Scenario: Basic Trade Enough Resources
	Given "Red" is ready to trade
	And "Red" is rich
	When "Red" requests to do basic trade
	Then the game is waiting for "Red" to do trade

Scenario: Trade at Harbor Not Enough Resources
	Given "Red" is ready to trade
	And "Red" owns intersection 0
	When "Red" requests to trade at a harbor
	Then the game is waiting for "Red" to trade

Scenario: Trade at Harbor Don't Own
	Given "Red" is ready to trade
	And "Red" doesn't own a harbor
	When "Red" requests to trade at a harbor
	Then the game will display error message "Sorry, you don't have a settlement or city next to that harbor."

Scenario: Basic Trade Not Enough Resources
	Given "Red" is ready to trade
	When "Red" requests to do basic trade
	Then the game is waiting for "Red" to trade
	And the game will display error message "sorry, you don't have enough resources to trade that way."

Scenario: Exit Trade 
	Given "Red" is ready to trade
	When "Red" requests to build
	Then the game is waiting for "Red" to build

Scenario: Bank Is Out Of Resources Basic
	Given "Red" is ready to trade
	And the bank is destitute
	When "Red" requests to do basic trade
	Then the game will display error message "sorry, the bank is out of resources. Move to build phase."

Scenario: Bank Is Out Of Resources Harbor
	Given "Red" is ready to trade
	And the bank is destitute
	When "Red" requests to trade at a harbor
	Then the game will display error message "sorry, the bank is out of resources. Move to build phase."

Scenario: Obstinate Player
	Given "Red" is ready to trade
	When "Red" requests to end their turn
	Then the game is waiting for "Red" to trade
	And the game will display error message "You have selected an invalid action or target for an action. Please try again."
