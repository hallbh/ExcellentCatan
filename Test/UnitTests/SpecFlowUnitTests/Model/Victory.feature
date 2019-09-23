@real_player
Feature: Victory
Scenario Template: Points Calculations
	Given "Blue" is rich
	And "Blue" has <settlements> Settlements
	And "Blue" has <cities> Citys
	And "Blue" has <victory_cards> VictoryPointCards
	And "Blue" has <longest_road> LongestRoadCards
	And "Blue" has <largest_army> LargestArmyCards
	When it is "Blue"'s turn
	Then "Blue" has <total_pts> victory points
	Examples: 
	| settlements | cities | victory_cards | longest_road | largest_army | total_pts |
	| 2           | 0      | 0             | 0            | 0            | 2         |
	| 2           | 1      | 0             | 0            | 0            | 4         |
	| 2           | 0      | 1             | 0            | 0            | 3         |
	| 2           | 0      | 0             | 1            | 0            | 4         |
	| 2           | 0      | 0             | 0            | 1            | 4         |
	| 2           | 1      | 1             | 1            | 1            | 9         |
	| 2           | 1      | 2             | 1            | 1            | 10        |
	| 2           | 1      | 2             | 1            | 1            | 10        |