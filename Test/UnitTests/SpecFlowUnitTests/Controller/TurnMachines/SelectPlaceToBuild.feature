
@mock_player
Feature: Select Place To Build
Scenario Outline: Prompt User
	When it is time for <name> to place a <type>
	Then <name> will be prompted to <prompt>
	Examples: 
	| name     | type       | prompt                |
	| "Orange" | city       | "place a city."       |
	| "Orange" | settlement | "place a settlement." |
	| "Orange" | road       | "place a road."       |

Scenario Outline: Selection State Transitions
	Given <name> is ready to place a <type>
	When <name> selects a <validity> <type>
	Then the game is waiting for <name> to <new_state>
	Examples: 
	| name     | type       | validity | new_state           |
	| "Orange" | city       | valid    | build               |
	| "Orange" | city       | invalid  | select a city       |
	| "Orange" | settlement | valid    | build               |
	| "Orange" | settlement | invalid  | select a settlement |
	| "Orange" | road       | valid    | build               |
	| "Orange" | road       | invalid  | select a road       |


Scenario Outline: Selection Prompts
	Given <name> is ready to place a <type>
	When <name> selects a invalid <type>
	Then the game will display error message <prompt>
	Examples: 
	| name     | type       | prompt                                                                                                                            |
	| "Orange" | city       | "You must select a city you own to upgrade."                                                                                      |
	| "Orange" | settlement | "Your settlement must be placed next to a road you own, at least two roads away from another settlement."                         |
	| "Orange" | road       | "Your road must be adjacent to one of your cities, settlements, or roads, and cannot cross other player's settlements or cities." |

Scenario Outline: Selection Prompts on wrong selection
	Given <name> is ready to place a <type>
	When <name> selects a invalid <other_type>
	Then the game will display error message "You have selected an invalid action or target for an action. Please try again."
	Examples: 
	| name     | type       | other_type |
	| "Orange" | city       | road       |
	| "Orange" | settlement | road       |
	| "Orange" | road       | city       |