using System;
using System.Collections.Generic;
using System.IO;
using Catan.Controller;
using Catan.Properties;
using Newtonsoft.Json;
using static Catan.Model.Item;
namespace Catan.Model
{
    public class GameBoard
    {
        private List<Intersection> intersections;
        private List<Path> paths;
        private List<Hex> hexes;
        private List<Harbor> harbors;
        private Dictionary<int, LinkedList<Hex>> hexNumbers;
        private readonly ItemContainer longestRoadContainer = 
            new ItemContainer(new Dictionary<Item, int> {{LongestRoadCard, 1}});

        private struct LongestRoadBundle
        {
            public readonly Intersection Intersection;
            public readonly Player Owner;
            public readonly List<Path> VisitedPaths;

            public LongestRoadBundle(Intersection intersection, Player owner, List<Path> visitedPaths)
            {
                Intersection = intersection;
                Owner = owner;
                VisitedPaths = visitedPaths;
            }
        }

        public int NumIntersections => intersections.Count;
        public int NumPaths => paths.Count;
        public int NumHarbors => harbors.Count;
        public int NumHexes => hexes.Count;

        /*
         * This constructor builds the board in such a matter that intersections, paths, and hexes
         * are numbered from left to right, top to bottom. That is to say, the top 3 hexes are hexes
         * 0, 1, 2, the top row of paths are 0-5, and the top row of intersections are 0-6. Then the board
         * structure is hard coded according to this.
         * */
        public GameBoard()
        {
            SetupIntersections();
            SetupPaths();
            SetupHexes();
            SetupHexNumbers();
            SetupHarbors();
        }

        public void InitializeView(Presenter presenter)
        {
            for (var i = 0; i < NumHexes; i++)
            {
                presenter.SetupHex( i, GetHex(i));
            }

            for (var i = 0; i < NumHarbors; i++)
            {
                presenter.SetupHarbor(i, GetHarbor(i));
            }
            presenter.SetRobberPosition(7);
        }

        private void SetupIntersections()
        {
            intersections = new List<Intersection>();

            for (var i = 0; i < 54; i++)
            {
                intersections.Add(new Intersection());
            }
        }
        
        private void SetupPaths()
        {
            paths = new List<Path>();
            var stream = typeof(GameBoard).Assembly.GetManifestResourceStream(@"Catan.Resources.MapSetup.json");
            using (var r = new StreamReader(stream ?? throw new InvalidOperationException(@"Manifest resource stream was null")))
            {
                var json = r.ReadToEnd();
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                var array = jsonObj.paths;
                foreach (var item in array)
                {
                    var adjacentIntersections = new List<Intersection>
                    {
                        intersections[(int) item[0]], intersections[(int) item[1]]
                    };
                    paths.Add(new Path(adjacentIntersections));

                }
            }
        }

        private void SetupHexes()
        {
            hexes = new List<Hex>();
            var resources = new List<Item>
            {
                Lumber, Wool, Grain, Brick, Ore, Brick, Wool, Desert, Lumber, Grain, Lumber,
                Grain, Brick, Wool, Wool, Ore, Ore, Grain, Lumber
            };

            var rollNumbers = new List<int>
            {
                11, 12, 9, 4, 6, 5, 10, 0, 3, 11, 4, 8, 8, 10, 9, 3, 5, 2, 6
            };
            for (var i = 0; i < 19; i++)
            {
                var adjacentIntersections = new List<Intersection>();
                int topLeft;
                int topBottomDiff;
                
                if (i < 3 || i > 15)
                {
                    topLeft = i < 3 ? i * 2 : i * 2 + 7;
                    topBottomDiff = 8;
                }
                else if (i < 7 || i > 11)
                {
                    topLeft = i < 7 ? i * 2 + 1 : i * 2 + 4;
                    topBottomDiff = 10;
                }
                else
                {
                    topLeft = i * 2 + 2;
                    topBottomDiff = 11;
                }

                adjacentIntersections.Add(intersections[topLeft]);
                adjacentIntersections.Add(intersections[topLeft + 1]);
                adjacentIntersections.Add(intersections[topLeft + 2]);
                adjacentIntersections.Add(intersections[topLeft + topBottomDiff]);
                adjacentIntersections.Add(intersections[topLeft + topBottomDiff + 1]);
                adjacentIntersections.Add(intersections[topLeft + topBottomDiff + 2]);

                hexes.Add(new Hex(adjacentIntersections, resources[i], rollNumbers[i]));
            }

        }

        private void SetupHexNumbers()
        {
            hexNumbers = new Dictionary<int, LinkedList<Hex>>
            {
                {0, new LinkedList<Hex>()},
                {2, new LinkedList<Hex>()},
                {3, new LinkedList<Hex>()},
                {4, new LinkedList<Hex>()},
                {5, new LinkedList<Hex>()},
                {6, new LinkedList<Hex>()},
                {8, new LinkedList<Hex>()},
                {9, new LinkedList<Hex>()},
                {10, new LinkedList<Hex>()},
                {11, new LinkedList<Hex>()},
                {12, new LinkedList<Hex>()}
            };
            foreach (var hex in hexes)
            {
                hexNumbers[hex.RollNumber].AddLast(hex);
            }

            hexes[7].HasRobber = true;
        }

        private void SetupHarbors()
        {
            harbors = new List<Harbor>
            {
                new Harbor(Any, new List<Intersection> {intersections[0], intersections[1]}),
                new Harbor(Wool, new List<Intersection> {intersections[3], intersections[4]}),
                new Harbor(Any, new List<Intersection> {intersections[14], intersections[15]}),
                new Harbor(Any, new List<Intersection> {intersections[26], intersections[37]}),
                new Harbor(Brick, new List<Intersection> {intersections[45], intersections[46]}),
                new Harbor(Lumber, new List<Intersection> {intersections[50], intersections[51]}),
                new Harbor(Any, new List<Intersection> {intersections[47], intersections[48]}),
                new Harbor(Grain, new List<Intersection> {intersections[28], intersections[38]}),
                new Harbor(Ore, new List<Intersection> {intersections[7], intersections[17]})
            };
        }

        public virtual Intersection GetIntersection(int index)
        {
            return intersections[index];
        }

        public virtual Path GetPath(int index)
        {
            return paths[index];
        }

        public virtual Hex GetHex(int index)
        {
            return hexes[index];
        }

        internal Dictionary<int, LinkedList<Hex>> GetHexNumbers()
        {
            return hexNumbers;
        }

        public virtual Harbor GetHarbor(int index)
        {
            return harbors[index];
        }

        public virtual bool CanPlaceSettlementSomewhere(Player player)
        {
            for (var i = 0; i < intersections.Count; i++)
            {
                if (CanPlaceSettlementAtIndex(player, i)) return true;
            }

            return false;
        }

        private bool CanPlaceSettlementAtIndex(Player player, int index)
        {
            foreach (var path in intersections[index].GetPaths())
            {
                var valid = true;
                var adjacentToPath = false;
                foreach (var i in path.GetIntersections())
                {
                    adjacentToPath = adjacentToPath || path.GetOwner() == player;
                    if (i.HasSettlement || i.HasCity)
                    {
                        valid = false;
                    }
                }

                if (valid && adjacentToPath) return true;
            }

            return false;
        }

        public virtual bool PlaceSettlement(Player player, int index)
        {
            var validIntersection = CanPlaceSettlementAtIndex(player, index);
            if (validIntersection) intersections[index].SetOwner(player);
            return validIntersection;
        }

        public virtual bool PlaceInitialSettlement(Player player, int index)
        {
            foreach (var p in intersections[index].GetPaths())
            {
                foreach (var i in p.GetIntersections())
                {
                    if (i.HasSettlement || i.HasCity)
                    {
                        return false;
                    }
                }
            }
            intersections[index].SetOwner(player);

            return true;
        }

        public virtual bool CanPlaceCitySomewhere(Player player)
        {
            foreach (var intersection in intersections)
            {
                if (intersection.HasSettlement && intersection.GetOwner() == player) return true;
            }

            return false;
        }

        public virtual bool PlaceCity(Player player, int intersectionIndex)
        {
            if (intersections[intersectionIndex].GetOwner() != player)
            {
                return false;
            }

            intersections[intersectionIndex].UpgradeToCity();
            return true;
        }

        public virtual bool CanPlaceRoadSomewhere(Player player)
        {
            foreach (var path in paths)
            {
                if (path.GetOwner() != null) continue;
                foreach (var intersection in path.GetIntersections())
                {
                    if (intersection.GetOwner() == player) return true;
                    if (intersection.GetOwner() == null)
                    {
                        foreach (var adjPath in intersection.GetPaths())
                        {
                            if (adjPath == path) continue;
                            if (adjPath.GetOwner() == player) return true;
                        }
                    }
                }
            }

            return false;
        }

        public virtual bool PlaceRoad(GameModel model, int pathIndex)
        {
            var adjIntersections = paths[pathIndex].GetIntersections();

            if (paths[pathIndex].GetOwner() != null)
            {
                return false;
            }

            foreach (var i in adjIntersections)
            { 
                if (i.GetOwner() == model.ActivePlayer)
                {
                    SetRoadOwnedAtPath(model, pathIndex);
                    return true;
                }

                // Check if path is adjacent to a path owned by player,
                // but not across an intersection owned by a different player
                var adjPaths = i.GetPaths();
                foreach (var path in adjPaths)
                {
                    if (path.GetOwner() == model.ActivePlayer && i.HasSettlement == false && i.HasCity == false)
                    {
                        SetRoadOwnedAtPath(model, pathIndex);
                        return true;
                    }
                }
            }
            
            return false;
        }

        private void SetRoadOwnedAtPath(GameModel model, int pathIndex)
        {
            var path = paths[pathIndex];
            path.SetOwner(model.ActivePlayer);
            CheckLongestRoadAtPath(model, path);
        }

        public void CheckLongestRoad(GameModel model)
        {
            // Hard reset on the owner of the longest road
            foreach (var player in model.Players)
            {
                if (player.HasLongestRoad) player.Transfer(longestRoadContainer, model.Bank);
            }
            model.Presenter.DisplayLongestRoadOwner(Resources.Player_None);
            model.LongestRoadLength = 4;
            
            foreach (var path in paths) CheckLongestRoadAtPath(model, path);
        }

        public void CheckLongestRoadAtPath(GameModel model, Path path)
        {
            var length = GetLengthOfRoad(path);
            
            if (length <= model.LongestRoadLength) return;

            ItemContainer owner = model.Bank;
            foreach (var player in model.Players)
            {
                if (player.HasLongestRoad) owner = player;
            }

            model.LongestRoadLength = length;
            if (path.GetOwner().GetAmount(LongestRoadCard) == 1) return;
            owner.Transfer(longestRoadContainer, path.GetOwner());
            model.Presenter.DisplayLongestRoadOwner(path.GetOwner().Color.LocalizedString());
        }
        
        public int GetLengthOfRoad(Path path)
        {
            if (!path.HasRoad()) return 0;
            
            var visitedPaths = new List<Path> { path };
            CalculateLengthFrom(new LongestRoadBundle(path.GetIntersections()[0], path.GetOwner(), visitedPaths));
            CalculateLengthFrom(new LongestRoadBundle(path.GetIntersections()[1], path.GetOwner(), visitedPaths));

            // Traverse the list of paths from every path that only is connected on one intersection (From all endings)
            // If no such paths exist, there are cycles, and we have to check from every path in the list of visitedPaths
            var toReturn = 1;
            
            foreach (var p in visitedPaths)
            {
                visitedPaths = new List<Path> { p };
                var left = CalculateLengthFrom(new LongestRoadBundle(p.GetIntersections()[0], p.GetOwner(), visitedPaths));
                var right = CalculateLengthFrom(new LongestRoadBundle(p.GetIntersections()[1], p.GetOwner(), visitedPaths));
                toReturn = Math.Max(toReturn, left + 1 + right);
            }

            return toReturn;
        }

        private int CalculateLengthFrom(LongestRoadBundle bundle)
        {
            var maxLength = 0;
            if (bundle.Intersection.GetOwner() != bundle.Owner && bundle.Intersection.GetOwner() != null)
            {
                return maxLength;
            }
            foreach (var adjPath in bundle.Intersection.GetPaths())
            { 
                
                if (adjPath.GetOwner() == bundle.Owner && !bundle.VisitedPaths.Contains(adjPath))
                {
                    bundle.VisitedPaths.Add(adjPath);
                    // Travel away from the intersection passed in
                    var nextFork = adjPath.GetIntersections()[0] == bundle.Intersection
                        ? adjPath.GetIntersections()[1]
                        : adjPath.GetIntersections()[0];
                    // Add 1 to the result of the recursive calculation to account for the path just traversed
                    maxLength = Math.Max(maxLength, 1 + CalculateLengthFrom(new LongestRoadBundle(nextFork, bundle.Owner, bundle.VisitedPaths)));
                }
            }

            return maxLength;
        }

        public virtual List<ResourceRequest> GetInitialResourceRequests()
        {
            var requests = new List<ResourceRequest>();
            for (var i = 0; i < NumHexes; i++)
            {
                requests.AddRange(GetHex(i).DistributeInitialResources());
            }

            return requests;
        }

        public virtual bool PlaceRobber(int index)
        {
            if (hexes[index].HasRobber) {
                return false;
            }

            foreach(var hex in hexes)
            {
                hex.HasRobber = false;
            }

            hexes[index].HasRobber = true;
            return true;
        }

        public bool CheckAdjacencyBetweenHexAndIntersection(int hexIdx, int intersectionIdx)
        {
            var adjacentIntersections = GetHex(hexIdx).GetIntersections();
            return adjacentIntersections.Contains(GetIntersection(intersectionIdx));
        }


        public bool HexBorderedByDifferentPlayer(int idx, Player player)
        {
            return GetHex(idx).GetIntersections().Exists(x => x.GetOwner() != null && x.GetOwner() != player);
        }
    }
}
