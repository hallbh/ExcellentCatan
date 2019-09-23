
@mock_player
Feature: Robber
Scenario: Time to place robber
	When it is time for "Red" to rob people
	Then "Red" will be prompted to "select a hex to place the Robber on."

Scenario: Invalid location selection
	Given "Red" is ready to rob people
	When "Red" selects a invalid hex
	Then the game is waiting for "Red" to rob people
	Then the game will display error message "select a DIFFERENT hex to place the Robber on."

Scenario: Valid location selection
	Given "Red" is ready to rob people
	And "Blue" does own an adjacent settlement
	When "Red" selects a valid hex
	Then the game is waiting for "Red" to steal a resource
	And the Robber moved to the new location
	And the game will display "Red"'s resources
	
Scenario: Valid location selection but no adjacent settlements
	Given "Red" is ready to rob people
	And "Blue" doesn't own an adjacent settlement
	When "Red" selects a valid hex
	Then the game is waiting for "Red" to trade
	And the Robber moved to the new location

Scenario: Time to select target
	When it is time for "Red" to steal a resource
	Then "Red" will be prompted to "select an adjacent city or settlement to steal a resource from."
	
Scenario: Obstinate player
	Given "Red" is ready to rob people
	When "Red" requests to end their turn
	Then the game is waiting for "Red" to rob people
	And the game will display error message "You have selected an invalid action or target for an action. Please try again."


Scenario: Obstinate player 2
	Given "Red" is ready to steal a resource
	When "Red" requests to end their turn
	Then the game is waiting for "Red" to steal a resource	
	And the game will display error message "You have selected an invalid action or target for an action. Please try again."


Scenario: Valid Steal Resource
	Given "Red" is ready to steal a resource
	And "Blue" does own an adjacent settlement
	And "Blue" has 1 Brick
	When "Red" selects "Blue"'s adjacent settlement
	Then "Red" takes 1 Brick from "Blue"
	And the game is waiting for "Red" to trade

Scenario: Valid Steal Resource but target is broke
	Given "Red" is ready to steal a resource
	And "Blue" does own an adjacent settlement
	And "Blue" has 0 Brick
	When "Red" selects "Blue"'s adjacent settlement
	Then the game is waiting for "Red" to trade
	Then the game will display error message "what a pity! that player didn't have any resources."

Scenario: Non-adjacent settlement
	Given "Red" is ready to steal a resource
	And "Blue" doesn't own an adjacent settlement
	And "Blue" has 1 Brick
	When "Red" selects "Blue"'s non-adjacent settlement
	Then the game is waiting for "Red" to steal a resource
	And the game will display error message "that city is not adjacent! Select an adjacent city or settlement!"


Scenario: No settlement at location
	Given "Red" is ready to steal a resource
	When "Red" selects an empty intersection
	Then the game is waiting for "Red" to steal a resource
	And the game will display error message "there is no city or settlement there! Select an adjacent city or settlement!"

Scenario: Steal from self
	Given "Red" is ready to steal a resource
	And "Red" does own an adjacent settlement
	When "Red" selects "Red"'s adjacent settlement
	Then the game is waiting for "Red" to steal a resource
	And the game will display error message "stealing from yourself is not a valid choice! Select an adjacent city or settlement!"
	# See BankUnitTest for handling of giving resources back to the bank; TODO do we want to give players choice