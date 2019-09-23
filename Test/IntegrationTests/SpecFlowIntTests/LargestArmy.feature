@integration
Feature: LargestArmy

Scenario: PlayFirstKnight
	Given "Blue" is ready to build
	And "Blue" has played 0 knights
	And "Blue" has 1 knight card
	When "Blue" plays a knight
	Then "Blue" doesn't have largest army
	And "Blue" has played 1 knight

Scenario: PlayThirdKnight
	Given "Blue" is ready to trade
	And "Blue" has played 2 knights
	And "Blue" has 1 knight card
	When "Blue" plays a knight
	Then "Blue" has played 3 knights
	And "Blue" does have largest army
	And The bank doesn't have the largest army
	And the game will display error message "You have received the Largest Army Card."

Scenario: SecondPlayerToThirdKnight
	Given "Blue" is ready to trade
	And "Red" has played 3 knights
	And "Red" has the largest army
	And "Blue" has played 2 knights
	And "Blue" has 1 knight card
	When "Blue" plays a knight
	Then "Red" does have largest army
	And "Blue" doesn't have largest army
	And "Blue" has played 3 knights

Scenario: OvertakingLargestArmy
	Given "Blue" is ready to trade
	And "Red" has played 3 knights
	And "Red" has the largest army
	And "Blue" has played 3 knights
	And "Blue" has 1 knight card
	When "Blue" plays a knight
	Then "Red" doesn't have largest army
	And "Blue" does have largest army
	And "Blue" has played 4 knights
	And the game will display error message "You have received the Largest Army Card."

Scenario: AlreadyOwnLA
	Given "Blue" is ready to build
	And "Blue" has played 3 knights
	And "Blue" has the largest army
	And "Blue" has 1 knight card
	When "Blue" plays a knight
	Then "Blue" does have largest army
	And "Blue" has played 4 knights