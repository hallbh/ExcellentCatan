using System.Collections.Generic;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.IntegrationTests
{
    [TestClass]
    public class InitialGameStateTest
    {
        private readonly GameBoard board = new GameBoard();
        [TestMethod]
        public void HexInitializationOnGameBoard() {

            Assert.IsTrue(board.GetHex(7).HasRobber);

            board.GetHexNumbers().TryGetValue(2, out var singleValue);
            Assert.IsNotNull(singleValue);
            Assert.IsTrue(singleValue.Contains(board.GetHex(17)));

            board.GetHexNumbers().TryGetValue(6, out var multipleValues);
            Assert.IsNotNull(multipleValues);
            Assert.IsTrue(multipleValues.Contains(board.GetHex(4)));
            Assert.IsTrue(multipleValues.Contains(board.GetHex(18)));
        }

        [TestMethod]
        public void HexResourceInitialization() {
            Assert.AreEqual(Item.Desert, board.GetHex(7).Resource);
            Assert.AreEqual(Item.Lumber, board.GetHex(0).Resource);
            Assert.AreEqual(Item.Ore, board.GetHex(4).Resource);
            Assert.AreEqual(Item.Grain, board.GetHex(2).Resource);
            Assert.AreEqual(Item.Brick, board.GetHex(3).Resource);
            Assert.AreEqual(Item.Wool, board.GetHex(1).Resource);
        }

        private void CheckHexIntersection(int hexIndex, int topLeft, int bottomLeft)
        {
            var result = false;
            var hex = board.GetHex(hexIndex);

            for (var i = 0; i < 3; i++) { 
                result = hex.GetIntersections().Contains(board.GetIntersection(topLeft + i)) || result;
                result = hex.GetIntersections().Contains(board.GetIntersection(bottomLeft + i)) || result;
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HexIntersection()
        {
            // Picked 5 random hexes to hard code intersections to verify correct construction.
            // Only checking top and bottom left indices because the other two are index+1 and index+2 respectively
            CheckHexIntersection(0, 0, 8);
            CheckHexIntersection(5, 11, 21);
            CheckHexIntersection(8, 18, 29);
            CheckHexIntersection(14, 32, 42);
            CheckHexIntersection(18, 43, 51);
        }

        private void CheckPathIntersection(int pathIndex, int int1, int int2)
        {
            var path = board.GetPath(pathIndex);

            if (path.GetIntersections().Count != 2)
            {
                Assert.Fail("Intersection count should be 2");
            }
            Assert.IsTrue(path.GetIntersections().Contains(board.GetIntersection(int1)));
            Assert.IsTrue(path.GetIntersections().Contains(board.GetIntersection(int2)));
        }

        [TestMethod]
        public void PathIntersection()
        {
            CheckPathIntersection(0, 0, 1);
            CheckPathIntersection(36, 22, 33);
            CheckPathIntersection(19, 9, 19);
            CheckPathIntersection(49, 28, 38);
            CheckPathIntersection(65, 45, 53);
        }

        private void CheckIntersectionPaths(int intIndex, int path1, int path2, int path3)
        {
            var intersection = board.GetIntersection(intIndex);

            if (path3 > 0) {
                if (intersection.GetPaths().Count != 3)
                {
                   Assert.Fail("Path count should be 3 if 3 paths are specified");
                }

                Assert.IsTrue(intersection.GetPaths().Contains(board.GetPath(path1)));
                Assert.IsTrue(intersection.GetPaths().Contains(board.GetPath(path2)));
                Assert.IsTrue(intersection.GetPaths().Contains(board.GetPath(path3)));
                return;
            }

            if (intersection.GetPaths().Count != 2)
            {
                Assert.Fail("Path count should be 2 if 2 paths are specified");
            }
            Assert.IsTrue(intersection.GetPaths().Contains(board.GetPath(path1)));
            Assert.IsTrue(intersection.GetPaths().Contains(board.GetPath(path2)));
        }

        [TestMethod]
        public void IntersectionPath()
        {
            CheckIntersectionPaths(0, 0, 6, -1);
            CheckIntersectionPaths(3, 2, 3, -1);
            CheckIntersectionPaths(9, 11, 12, 19);
            CheckIntersectionPaths(33, 36, 44, 45);
            CheckIntersectionPaths(47, 62, 66, -1);
        }

        [TestMethod]
        public void Harbor()
        {
            var h = new Harbor(Item.Any, new List<Intersection>());

            Assert.AreEqual(Item.Any, h.Resource);
        }

        [TestMethod]
        public void HarborInBoard()
        {
            Assert.IsTrue(board.GetHarbor(0).AdjacentIntersections.Contains(board.GetIntersection(0)));
            Assert.IsFalse(board.GetHarbor(0).AdjacentIntersections.Contains(board.GetIntersection(20)));
        }
    }
}
