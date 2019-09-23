# 376-ExcellentCatan

Please note - we did most of the project via pair programming. 
Ben and Charlie ended up driving more often.
As a result, our commit & line counts are higher, but these metrics are not the 
most representation of our respective levels of effort or amount of time put in, 
which were relatively even.

# Settlers of Catan: Definition of Done BVA

## Resource Distribution
### Resource Cards
 * If there are NO resource cards remaining, no players receive any resource cards.
 * If there are not enough of a resource card for everyone to get their share, then no one receives any of that resource for that turn.
 * The resource terrain that the robber sits on will produce NO resource cards for any settlements or cities on that terrain piece.
### Maritime Trade
 * If the player does not have a city or settlement on a harbour, then the player must trade in 4 identical resources in order to select any 1 resource of the players choosing.
   - If a player does not own 4 identical resources, the player will not have the ability to participate in 4:1 trade
   - If 4 identical resources are not selected, then the player will be notified and prompted to try again.
   - If the players target card is not available, then the player will be notified and prompted to try again.
   - If none of the above errors occur, the player will receive the targeted resource card and also lose 4 of the selected resource type.
 * If the player has a city or settlement on a harbour, then 3 identical resources can be traded in for 1 resource of the players choosing.
   - If a player does not own 3 identical resources, the player will not have the ability to participate in 3:1 trade
   - If 3 identical resources are not selected, then the player will be notified and prompted to try again.
   - If the players target card is not available, then the player will be notified and prompted to try again.
   - If none of the above errors occur, the player will receive the targeted resource card and also lose 3 of the selected resource type.
 * If the player has a city or settlement on a special harbour, then 2 resources of the type specified by the harbor can be traded in for 1 resource as specified by the special harbour.
   - If a player does not own 2 resources of the specified type, the player will not have the ability to participate in 2:1 special trade
   -  If 2 identical resources of the specified type are not selected, then the player will be notified and prompted to try again.
   -  If the specified target resource is not available, then the player will be notified and prompted to try again.
   -  If none of the above errors occur, the player will receive the specified resource and also lose 2 of the specified resource type.
### Robber
 * Any player who rolls a 7 must move the robber, the robber can be placed on any terrain hex on the board that it was not previously occupying.
 * On a roll of 7, if a player has less than 7 resources, they keep all their resources.
 * On a roll of 7, if a player has exactly 7 resources, they keep all their resources.
 * On a roll of 7, If a player has greater than 7 cards:
   -  If a player has an EVEN number of cards, they lose exactly half of them.
   -  If a player has an ODD number of cards, they lose half of their cards, rounded down (i.e. if a player has 9 cards, they will lose 4).

## Building Placement
### Roads
 * A road cannot be placed on a path that is not directly adjacent to another road or settlement that the player owns.
 * A road cannot be placed on a path that already has a road.
 * The first player to build a path containing 5 consecutive roads will gain the Longest Road Card.
   -  Any player gaining 1 more consecutive road than the owner of the Longest Road Card immediately takes ownership of the Longest Road Card.
   -  If another player splits the longest road in any way, the current holder of the Longest Road Card will lose ownership.
### Settlements
 * A settlement cannot be placed within 2 paths of another settlement.
 * A settlement must be placed adjacent to a road owned by the player.
 * No player may place more than 5 settlements on the board.
### Cities
 * A city must replace an existing settlement that the player owns.
 * No player may place more than 4 cities on the board.
 
## Development Cards
 * Only one development card may be played per turn.
 * A development card may not be played the turn it is purchased.
### Knight Card
 * When a player plays a knight card, they must move the robber.
 * The first player to reach 3 knights will gain the Largest Army Card.
   -  Any player gaining 1 more knight than the owner of the Largest Army Card immediately takes ownership of the Largest Army Card.
   -  When a player plays a knight card such that their army is the same size as the owner of the largest army, they do not gain the Largest Army Card.
### Road Building Card
 * If the road building card is played and the player has 14 or 15 roads, they will be able to construct 1 or 0 roads respectively.
### Year of Plenty Card and Monopoly Card
 * Year of Plenty and Monopoly cards are subject to the resource gain rules, specifically when the type of resource requested runs out (see Resource Distribution section).

## Victory Points
 * If a player has less than 10 Victory Points, they cannot win the game.
 * If a player has greater than or equal to 10 Victory Points on their turn, they will win the game.
 