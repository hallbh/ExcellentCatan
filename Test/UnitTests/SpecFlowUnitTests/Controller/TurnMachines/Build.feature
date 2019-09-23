@mock_player
Feature: Build
Scenario: Prompt User:
	When it is time for "Orange" to build
	Then "Orange" will be prompted to "begin building or end turn."

Scenario: End Turn
	Given "Orange" is ready to build
	When "Orange" requests to end their turn
	Then it is "Red"'s turn
	And the error prompt is cleared

Scenario: End Turn (wraps to beginning)
	Given "White" is ready to build
	When "White" requests to end their turn
	Then it is "Blue"'s turn

	
Scenario: An invalid transition
	Given "Orange" is ready to build
	When "Orange" rolls the dice
	Then the game is waiting for "Orange" to build
	
Scenario Outline: Can place and can afford to build
	Given <name> is ready to build
	And <name> can place <action>
	And <name> can afford <action>
	When <name> requests <action>
	Then <name>'s request for <action> is handled
	And the game is waiting for <name> to <new_state>
	Examples: 
	| name     | action             | new_state           |
	| "Orange" | a new city         | select a city       |
	| "Orange" | a new settlement   | select a settlement |
	| "Orange" | a new road         | select a road       |

Scenario Outline: Dev Card Buy
	Given <name> is ready to build
	And <name> can place <action>
	And <name> can afford <action>
	When <name> requests <action>
	Then <name>'s request for <action> is handled
	And the game is waiting for <name> to <new_state>
	And the game will display <name>'s resources
	Examples:
	| name     | action             | new_state           |
	| "Orange" | a development card | build               |

Scenario Outline: Can't afford to build
	Given <name> is ready to build
	And <name> can place <action>
	And <name> cannot afford <action>
	When <name> requests <action>
	Then <name>'s request for <action> is handled
	And the game is waiting for <name> to <new_state>
	And the game will display error message "choose something you can afford! Begin building or end turn."
	Examples: 
	| name     | action             | new_state |
	| "Orange" | a new city         | build     |
	| "Orange" | a new settlement   | build     |
	| "Orange" | a new road         | build     |
	| "Orange" | a development card | build     |

	Scenario Outline: No valid placement locations
	Given <name> is ready to build
	And <name> cannot place <action>
	When <name> requests <action>
	Then the game is waiting for <name> to <new_state>
	And the game will display error message "sorry, there are no valid places for you to build that. Begin building or end turn."
	Examples: 
	| name     | action             | new_state |
	| "Orange" | a new city         | build     |
	| "Orange" | a new settlement   | build     |
	| "Orange" | a new road         | build     |
