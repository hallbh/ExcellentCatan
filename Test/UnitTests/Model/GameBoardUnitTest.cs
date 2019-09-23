using System.Collections.Generic;
using Catan.Controller;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Model
{
    [TestClass]
    public class GameBoardUnitTest
    {
        private MockRepository repository;
        private Mock<Player> playerMock;
        private GameModel model;
        private Player player;
        private Mock<Player> secondPlayerMock;
        private Player secondPlayer;
        private readonly GameBoard board = new GameBoard();

        [TestInitialize]
        public void SetupTest()
        {
            repository = new MockRepository(MockBehavior.Loose);
            playerMock = repository.Create<Player>(PlayerColor.Blue);
            player = playerMock.Object;
            secondPlayerMock = repository.Create<Player>(PlayerColor.Red);
            secondPlayer = secondPlayerMock.Object;
            model = new GameModel(board, 
                new Bank(), 
                new List<Player> {player, secondPlayer},
                new Presenter(Mock.Of<View>()));
        }
        // game board keep track of all tiles/the numbers on tiles
        // each TILE keeps track of its 6 INTERSECTIONS to check for settlers when distributing resources
        // intersections have 2 or 3 adjacent paths, intersection holds either CITY or SETTLEMENT/intersection
        //   can have a HARBOR, PATHS have ROADS and 2 adjacent intersections

        [TestMethod]
        public void BoardGeneration()
        {
            Assert.AreEqual(54, board.NumIntersections);
            Assert.AreEqual(72, board.NumPaths);
            Assert.AreEqual(19, board.NumHexes);
        }

        [TestMethod]
        public void PlaceRoadNextToRoad()
        {
            // Given
            const int intersectionIndex = 9;
            const int pathIndex = 12;
            const int targetPathIndex = 13;
            board.GetIntersection(intersectionIndex).SetOwner(player);
            board.GetPath(pathIndex).SetOwner(player);
            // When
            var result = board.PlaceRoad(model, targetPathIndex);
            // Then 
            Assert.IsTrue(result);
        }  

        [TestMethod]
        public void PlacingDuplicateRoad()
        {
            board.GetIntersection(12).SetOwner(player);
            board.GetPath(15).SetOwner(secondPlayer);
            playerMock.Setup(p => p.Equals(secondPlayer)).Returns(false);

            Assert.IsFalse(board.PlaceRoad(model, 15));
        }

        [TestMethod]
        public void RoadIsNotAdjacentToAnything()
        {
            const int intersectionIndex = 12;

            board.PlaceSettlement(player, intersectionIndex);
            board.PlaceRoad(model, 15);
            Assert.IsFalse(board.PlaceRoad(model, 17));
        }

        [TestMethod]
        public void PlaceSettlementAlreadyOccupiedTurnZero()
        {
            const int intersectionIndex = 12;
            board.GetIntersection(intersectionIndex).SetOwner(playerMock.Object);
            board.PlaceInitialSettlement(player, intersectionIndex);

            Assert.IsFalse(board.PlaceSettlement(secondPlayer, intersectionIndex + 1));
        }

        [TestMethod]
        public void MayNotPlaceSettlementOnePathAwayTurnZero()
        {
            const int intersectionIndex = 12;
            board.PlaceInitialSettlement(player, intersectionIndex);

            Assert.IsFalse(board.PlaceSettlement(secondPlayer, intersectionIndex + 1));
        }

        [TestMethod]
        public void MayPlaceSettlementMoreThanOnePathAwayTurnZero()
        {
            board.PlaceInitialSettlement(player, 12);
            Assert.IsTrue(board.PlaceInitialSettlement(secondPlayer, 14));
        }

        [TestMethod]
        public void PlaceDuplicateSettlementTurnZero()
        {
            const int intersectionIndex = 12;

            board.PlaceInitialSettlement(player, intersectionIndex);
            Assert.IsFalse(board.PlaceSettlement(secondPlayer, intersectionIndex));
        }

        [TestMethod]
        public void MustPlaceSettlementNextToARoadFail()
        {
            Assert.IsFalse(board.PlaceSettlement(player, 12));
        }

        [TestMethod]
        public void MayNotPlaceSettlementOnePathAway()
        {
            const int intersectionIndex = 12;
            board.GetPath(15).SetOwner(player);
            board.PlaceSettlement(player, intersectionIndex);

            Assert.IsFalse(board.PlaceSettlement(secondPlayer, intersectionIndex + 1));
        }

        [TestMethod]
        public void MayPlaceSettlementMoreThanOnePathAway()
        {
            board.GetPath(15).SetOwner(player);
            board.PlaceSettlement(player, 12);
            board.GetPath(16).SetOwner(player);
            Assert.IsTrue(board.PlaceSettlement(player, 14));
        }

        [TestMethod]
        public void PlaceDuplicateSettlement()
        {
            const int intersectionIndex = 12;

            board.GetPath(15).SetOwner(player);
            board.PlaceSettlement(player, intersectionIndex);
            Assert.IsFalse(board.PlaceSettlement(secondPlayer, intersectionIndex));
        }

        [TestMethod]
        public void PlaceRoadAcrossEnemySettlementFails()
        {
            // Given
            const int intersectionIndex = 1;
            const int firstRoadIndex = 0;
            const int secondRoadIndex = 1;
            var player2 = new Player(PlayerColor.Red);

            board.GetIntersection(intersectionIndex).SetOwner(player2);
            board.GetPath(firstRoadIndex).SetOwner(player);
            // When
            var result = board.PlaceRoad(model, secondRoadIndex);
            // Then
            Assert.IsFalse(result);
        }  

        [TestMethod]
        public void CannotPlaceCityOnOtherSettlement()
        {
            const int intersectionIndex = 12;

            board.PlaceSettlement(player, intersectionIndex);
            Assert.IsFalse(board.PlaceCity(secondPlayer, intersectionIndex));
        }

        [TestMethod]
        public void PlaceCityUpgradesCity()
        {
            const int intersectionIndex = 12;
            board.GetIntersection(intersectionIndex).SetOwner(player);
            board.PlaceCity(player, intersectionIndex);
            Assert.IsTrue(board.GetIntersection(intersectionIndex).HasCity);
        }

        [TestMethod]
        public void RobberMustMove()
        {
            const int intersectionIndex = 12;
            board.PlaceRobber(intersectionIndex);
            Assert.IsFalse(board.PlaceRobber(intersectionIndex));
        }

        [TestMethod]
        public void PlaceRobberSetsRobberAndRestoresOtherHex()
        {
            const int intersectionIndex = 12;
            board.PlaceRobber(10);
            board.PlaceRobber(intersectionIndex);
            Assert.IsTrue(board.GetHex(intersectionIndex).HasRobber);
            Assert.IsFalse(board.GetHex(10).HasRobber);
        }

        [TestMethod]
        public void InitializeGuiCallsPresenter()
        {
            var presenterMock = repository.Create<Presenter>(Mock.Of<View>());
            board.InitializeView(presenterMock.Object);
            for (var i = 0; i < 19; i++)
            {
                var x = i;
                presenterMock.Verify(p => p.SetupHex(x, board.GetHex(x)));
            }

            for (var i = 0; i < 9; i++)
            {
                var x = i;
                presenterMock.Verify(p => p.SetupHarbor(x, board.GetHarbor(x)));
            }

            presenterMock.Verify(p => p.SetRobberPosition(7));
            presenterMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void GetInitialResources()
        {
            board.GetIntersection(20).SetOwner(playerMock.Object);

            var requests = board.GetInitialResourceRequests();

            Assert.AreEqual(Item.Ore, requests[0].Resource);
            Assert.AreEqual(Item.Lumber, requests[1].Resource);
            Assert.AreEqual(Item.Grain, requests[2].Resource);

            foreach (var req in requests)
            {
                Assert.AreEqual(1, req.Amount);
            }
        }
    }
}