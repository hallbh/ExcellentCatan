@longestRoad
Feature: LongestRoad
	The first player to five roads gains control of the longest road card.
	Whenever another player gains more roads, not an equal amount, of roads
	than the current owner, the player will gain control of the longest road.

Scenario: Basic Success
	Given "Blue" is ready to build
	And "Blue" owns path 1
	And "Blue" owns path 2
	And "Blue" owns path 3
	And "Blue" owns path 4
	And "Blue" has 1 brick
	And "Blue" has 1 lumber
	And "Blue" doesn't own the Longest Road
	When "Blue" builds a road on path 5
	Then The road is 5 paths long from path 5
	And "Blue" does own the Longest Road

Scenario: Loop of Six
	Given "Blue" is ready to build
	And "Blue" owns path 0
	And "Blue" owns path 1
	And "Blue" owns path 7
	And "Blue" owns path 12
	And "Blue" owns path 11
	And "Blue" has 1 brick
	And "Blue" has 1 lumber
	And "Blue" does own the Longest Road
	When "Blue" builds a road on path 6
	Then The road is 6 paths long from path 0
	And "Blue" does own the Longest Road

Scenario: Loop Seven
	Given "Blue" is ready to build
	And "Blue" owns path 0
	And "Blue" owns path 1
	And "Blue" owns path 6
	And "Blue" owns path 7
	And "Blue" owns path 12
	And "Blue" owns path 11
	And "Blue" has 1 brick
	And "Blue" has 1 lumber
	And "Blue" does own the Longest Road
	When "Blue" builds a road on path 19
	Then The road is 7 paths long from path 0
	And "Blue" does own the Longest Road

Scenario: Figure Eight
	Given "Blue" is ready to build
	And "Blue" owns path 0
	And "Blue" owns path 1
	And "Blue" owns path 6
	And "Blue" owns path 7
	And "Blue" owns path 12
	And "Blue" owns path 11
	And "Blue" owns path 3
	And "Blue" owns path 8
	And "Blue" owns path 13
	And "Blue" owns path 14
	And "Blue" has 1 brick
	And "Blue" has 1 lumber
	And "Blue" does own the Longest Road
	When "Blue" builds a road on path 2
	Then The road is 11 paths long from path 0
	And "Blue" does own the Longest Road

Scenario: Longest Road Broken
	Given "Blue" is ready to build
	And "Blue" owns path 0
	And "Blue" owns path 1
	And "Blue" owns path 2
	And "Blue" owns path 3
	And "Red" owns intersection 2
	And "Blue" has 1 brick
	And "Blue" has 1 lumber
	And "Blue" doesn't own the Longest Road
	When "Blue" builds a road on path 4
	Then The road is 3 paths long from path 2
	And The road is 2 paths long from path 0
	And "Blue" doesn't own the Longest Road

Scenario: One Road
	Given "Blue" is ready to build
	And "Blue" owns intersection 0
	And "Blue" has 1 brick
	And "Blue" has 1 lumber
	And "Blue" doesn't own the Longest Road
	When "Blue" builds a road on path 0
	Then The road is 1 paths long from path 0
	And "Blue" doesn't own the Longest Road

Scenario: Equal Length Not Overtaken
	Given "Blue" is ready to build
	And "Blue" owns path 0
	And "Blue" owns path 1
	And "Blue" owns path 2
	And "Blue" owns path 3
	And "Red" does own the Longest Road
	And the Longest Road is 5 paths long
	And "Blue" has 1 brick
	And "Blue" has 1 lumber
	When "Blue" builds a road on path 4
	Then The road is 5 paths long from path 2
	And "Blue" doesn't own the Longest Road
	And "Red" does own the Longest Road

Scenario: One Longer Overtaken
	Given "Blue" is ready to build
	And "Blue" owns path 0
	And "Blue" owns path 1
	And "Blue" owns path 2
	And "Blue" owns path 3
	And "Blue" owns path 4
	And "Red" does own the Longest Road
	And the Longest Road is 5 paths long
	And "Blue" has 1 brick
	And "Blue" has 1 lumber
	When "Blue" builds a road on path 5
	Then The road is 6 paths long from path 2
	And "Blue" does own the Longest Road
	And "Red" doesn't own the Longest Road

Scenario: Longest Road Broken And Overtaken
	Given "Blue" is ready to build
	And "Blue" owns path 0
	And "Blue" owns path 1
	And "Blue" owns path 7
	And "Blue" owns path 13
	And "Blue" owns path 20
	And "Red" owns path 25
	And "Red" owns path 26
	And "Red" owns path 27
	And "Red" owns path 28
	And "Red" owns path 29
	And "Red" owns path 30
	And "Red" owns path 31
	And "Red" does own the Longest Road
	And the Longest Road is 7 paths long 
	And "Blue" has 1 brick
	And "Blue" has 1 lumber
	And "Blue" has 1 wool
	And "Blue" has 1 grain
	When "Blue" builds a settlement on intersection 21
	Then The road is 3 paths long from path 25
	And The road is 4 paths long from path 31
	And The road is 5 paths long from path 0
	And "Red" doesn't own the Longest Road
	And "Blue" does own the Longest Road