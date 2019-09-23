using System.Collections.Generic;
using Catan.Controller;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.IntegrationTests
{
    [TestClass]
    public class GamePlayTests
    {
        private readonly GameBoard gameBoard = new GameBoard();
        private readonly Player player1 = new Player(PlayerColor.Blue);
        private readonly Player player2 = new Player(PlayerColor.Red);
        private readonly Bank bank = new Bank();
        private readonly Presenter presenter = new Presenter(Mock.Of<View>());
        private GameModel gameModel;

        [TestInitialize]
        public void SetupTest()
        {
            gameModel = new GameModel(gameBoard, bank,  new List<Player> {player1, player2}, presenter);
            
            gameBoard.GetIntersection(8).SetOwner(player1);
            gameBoard.GetIntersection(8).UpgradeToCity();
        }

        private void ProcessRoll(int dieVal)
        {
            var requests = new List<ResourceRequest>();
            for (var i = 0; i < gameModel.Board.NumHexes; i++)
            {
                requests.AddRange(gameModel.Board.GetHex(i).DistributeDieRollResources(dieVal));
            }
            gameModel.Bank.SatisfyResourceRequests(requests);
        }

        [TestMethod]
        public void UpdatePlayerResources()
        {
            ProcessRoll(4);
            Assert.AreEqual(2, player1.GetAmount(Item.Brick));
        }

        [TestMethod]
        public void UpdatePlayerResourcesFails()
        {
            ProcessRoll(6);
            Assert.AreNotEqual(2, player1.GetAmount(Item.Brick));
        }

        [TestMethod]
        public void NoValidRoadPositions()
        {
            gameBoard.GetIntersection(10).SetOwner(player1);
            gameBoard.GetPath(7).SetOwner(player1);

            gameBoard.GetPath(1).SetOwner(player2);
            gameBoard.GetPath(2).SetOwner(player2);
            gameBoard.GetPath(12).SetOwner(player2);
            gameBoard.GetPath(13).SetOwner(player2);
            // Because in setup we put a city on 8
            gameBoard.GetPath(6).SetOwner(player2);
            gameBoard.GetPath(10).SetOwner(player2);
            gameBoard.GetPath(11).SetOwner(player2);

            Assert.IsFalse(gameBoard.CanPlaceRoadSomewhere(player1));
        }

        [TestMethod]
        public void ValidRoadPositions()
        {
            gameBoard.GetIntersection(10).SetOwner(player1);
            gameBoard.GetPath(7).SetOwner(player1);

            Assert.IsTrue(gameBoard.CanPlaceRoadSomewhere(player1));
        }

        [TestMethod]
        public void NoValidSettlementPositions()
        {
            // Mimic turn zero settlement placement
            gameBoard.GetIntersection(10).SetOwner(player1);
            gameBoard.GetPath(7).SetOwner(player1);

            Assert.IsFalse(gameBoard.CanPlaceSettlementSomewhere(player1));
        }

        [TestMethod]
        public void ValidSettlementPositions()
        {
            gameBoard.GetIntersection(10).SetOwner(player1);
            gameBoard.GetPath(7).SetOwner(player1);
            gameBoard.GetPath(2).SetOwner(player1);

            Assert.IsTrue(gameBoard.CanPlaceSettlementSomewhere(player1));
        }

        [TestMethod]
        public void NoValidCityPositions()
        {
            Assert.IsFalse(gameBoard.CanPlaceCitySomewhere(player1));
        }

        [TestMethod]
        public void ValidCityPositions()
        {
            gameBoard.GetIntersection(10).SetOwner(player1);

            Assert.IsTrue(gameBoard.CanPlaceCitySomewhere(player1));
        }
    }
}
