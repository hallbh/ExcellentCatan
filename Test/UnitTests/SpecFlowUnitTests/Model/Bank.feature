@mock_player
Feature: Bank
Scenario Outline: Initial Bank Resources
When the bank has just been setup
Then the bank should have <num> <card>
Examples: 
| num | card             |
| 19  | Lumber           |
| 19  | Ore              |
| 19  | Wool             |
| 19  | Brick            |
| 19  | Grain            |
| 14  | KnightCard       |
| 5   | VictoryPointCard |
| 2   | RoadBuildingCard |
| 2   | YearOfPlentyCard |
| 2   | MonopolyCard     |
| 1   | LongestRoadCard  |
| 1   | LargestArmyCard  |

Scenario Outline: Simple Buy Attempt
Given the bank has been setup
And the bank has <lumber> Lumber
And the bank has <ore> Ore
And the bank has <wool> Wool
And the bank has <brick> Brick
And the bank has <grain> Grain
And <name> <can_afford> afford a new <thing>
When <name> asks the bank for a new <thing>
Then <name> <can_afford> take a <thing> from the bank
And the bank should have <new_lumber> Lumber
And the bank should have <new_ore> Ore
And the bank should have <new_wool> Wool
And the bank should have <new_brick> Brick
And the bank should have <new_grain> Grain
Examples: 
| name   | lumber | ore | wool | brick | grain | can_afford | thing            | new_lumber | new_ore | new_wool | new_brick | new_grain |
| "Blue" | 12     | 12  | 12   | 12    | 12    | can        | Road             | 13         | 12      | 12       | 13        | 12        |
| "Blue" | 12     | 12  | 12   | 12    | 12    | cannot     | Road             | 12         | 12      | 12       | 12        | 12        |
| "Blue" | 12     | 12  | 12   | 12    | 12    | can        | Settlement       | 13         | 12      | 13       | 13        | 13        |
| "Blue" | 12     | 12  | 12   | 12    | 12    | cannot     | Settlement       | 12         | 12      | 12       | 12        | 12        |
| "Blue" | 12     | 12  | 12   | 12    | 12    | can        | City             | 12         | 15      | 12       | 12        | 14        |
| "Blue" | 12     | 12  | 12   | 12    | 12    | cannot     | City             | 12         | 12      | 12       | 12        | 12        |

Scenario Outline: Dev Card Buy Attempt
Given the bank has been setup
And the bank has 12 Lumber
And the bank has 12 Ore
And the bank has 12 Wool
And the bank has 12 Brick
And the bank has 12 Grain
And the bank has <knights> KnightCard
And the bank has <vp> VictoryPointCard
And the bank has <roadbuild> RoadBuildingCard
And the bank has <plenty> YearOfPlentyCard
And the bank has <monopoly> MonopolyCard
And <name> <can_afford> afford a new Development Card
When <name> asks the bank for a new Development Card
Then <name> <can_take> take a Development Card from the bank
And the bank should have <new_lumber> Lumber
And the bank should have <new_ore> Ore
And the bank should have <new_wool> Wool
And the bank should have <new_brick> Brick
And the bank should have <new_grain> Grain
Examples: 
| name   | knights | vp | roadbuild | plenty | monopoly | can_afford | can_take | new_lumber | new_ore | new_wool | new_brick | new_grain |
| "Blue" | 14      | 5  | 2         | 2      | 2        | can        | can      | 12         | 13      | 13       | 12        | 13        |
| "Blue" | 14      | 5  | 2         | 2      | 2        | cannot     | cannot   | 12         | 12      | 12       | 12        | 12        |
| "Blue" | 0       | 0  | 0         | 0      | 0        | can        | cannot   | 12         | 12      | 12       | 12        | 12        |

Scenario Outline: Dev Card Buy Attempt - Edge Cases
Given the bank has been setup
And the bank has 12 Lumber
And the bank has 12 Ore
And the bank has 12 Wool
And the bank has 12 Brick
And the bank has 12 Grain
And the bank has <knights> KnightCard
And the bank has <vp> VictoryPointCard
And the bank has <roadbuild> RoadBuildingCard
And the bank has <plenty> YearOfPlentyCard
And the bank has <monopoly> MonopolyCard
And <name> <can_afford> afford a new Development Card
When <name> asks the bank for a new Development Card
Then <name> <can_take> take a <should_get> from the bank
And the bank should have <new_lumber> Lumber
And the bank should have <new_ore> Ore
And the bank should have <new_wool> Wool
And the bank should have <new_brick> Brick
And the bank should have <new_grain> Grain
Examples: 
| name   | knights | vp | roadbuild | plenty | monopoly | can_afford | can_take | should_get       | new_lumber | new_ore | new_wool | new_brick | new_grain |
| "Blue" | 1       | 0  | 0         | 0      | 0        | can        | can      | KnightCard       | 12         | 13      | 13       | 12        | 13        |
| "Blue" | 0       | 1  | 0         | 0      | 0        | can        | can      | VictoryPointCard | 12         | 13      | 13       | 12        | 13        |
| "Blue" | 0       | 0  | 1         | 0      | 0        | can        | can      | RoadBuildingCard | 12         | 13      | 13       | 12        | 13        |
| "Blue" | 0       | 0  | 0         | 1      | 0        | can        | can      | YearOfPlentyCard | 12         | 13      | 13       | 12        | 13        |
| "Blue" | 0       | 0  | 0         | 0      | 1        | can        | can      | MonopolyCard     | 12         | 13      | 13       | 12        | 13        |


Scenario Outline: Simple Resource Requests
Given the bank has been setup
And player "Red" produced <red_prod> <red_type> 
And player "Blue" produced <blue_prod> <blue_type>
And the bank has <lumber> Lumber
And the bank has <ore> Ore
And the bank has <wool> Wool
And the bank has <brick> Brick
And the bank has <grain> Grain
When the players get resources from the bank
Then "Red" receives <red_recv> <red_type>
Then "Blue" receives <blue_recv> <blue_type>
Examples: 
| lumber | ore | wool | brick | grain | red_type | red_prod | red_recv | blue_type | blue_prod | blue_recv |
| 19     | 19  | 19   | 19    | 19    | Ore      | 6        | 6        | Wool      | 6         | 6         |
| 19     | 19  | 19   | 19    | 19    | Ore      | 6        | 6        | Ore       | 6         | 6         |
| 19     | 12  | 19   | 19    | 19    | Ore      | 6        | 6        | Ore       | 6         | 6         |
| 19     | 11  | 19   | 19    | 19    | Ore      | 6        | 0        | Ore       | 6         | 0         |
| 19     | 4   | 19   | 19    | 19    | Ore      | 5        | 0        | Wool      | 6         | 6         |
