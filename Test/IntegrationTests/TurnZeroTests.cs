using System.Collections.Generic;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Controller.TurnMachines.TurnZero;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.IntegrationTests
{
    [TestClass]
    public class TurnZeroTests
    {
        private MockRepository mocks;
        private Mock<GameBoard> board;
        private GameModel model;
        private List<Player> playerList;
        private Mock<View> view;
        private Mock<Presenter> presenter;
        private TurnManager manager;
        private PlayerAction intersectionAction;
        private PlayerAction pathAction;

        [TestInitialize]
        public void SetupTests()
        {
            mocks = new MockRepository(MockBehavior.Loose);
            playerList = new List<Player>
            {
                new Player(PlayerColor.Blue),
                new Player(PlayerColor.Orange),
                new Player(PlayerColor.Red),
                new Player(PlayerColor.White)
            };

            board = mocks.Create<GameBoard>();
            view = mocks.Create<View>(MockBehavior.Loose);
            view.Setup(x => x.SetPlayerName(playerList[0].Color.ToString()));
            presenter = mocks.Create<Presenter>(view.Object);
            const int intersectionIndex = 12;
            const int pathIndex = 15;
            board.Setup(b => b.PlaceInitialSettlement(It.IsAny<Player>(), intersectionIndex)).Returns(true);
            board.Setup(b => b.GetIntersection(It.IsAny<int>())).CallBase();
            board.Setup(b => b.GetPath(15))
                .Returns(new Path(new List<Intersection> {board.Object.GetIntersection(12)}));
            board.Setup(b => b.PlaceRoad(It.IsAny<GameModel>(), It.IsAny<int>())).Returns(true);
            model = new GameModel(board.Object, Mock.Of<Bank>(), playerList, presenter.Object);
            manager = new TurnManager(model);
            intersectionAction = new PlayerAction(ActionType.Intersection, intersectionIndex);
            pathAction = new PlayerAction(ActionType.Path, pathIndex);
        }

        [TestMethod]
        public void EndEnterSpecialState()
        {
            model.State<PlaceInitialRoad>().SecondRound = true;
            var state1 = manager.CurrentState;
            Assert.IsInstanceOfType(state1, typeof(PlaceInitialSettlement));
            var state2 = state1.HandleInput(intersectionAction);
            Assert.IsInstanceOfType(state2, typeof(PlaceInitialRoad));
            var state3 = state2.HandleInput(pathAction);
            Assert.IsInstanceOfType(state3, typeof(WaitRollDice));
        }

        private void DoTurn(int expectedPlayerBefore, int expectedPlayerAfter)
        {
            Assert.AreEqual(expectedPlayerBefore, model.ActivePlayerIndex);
            Assert.AreEqual(playerList[expectedPlayerBefore], model.ActivePlayer);
            manager.HandleAction(intersectionAction);
            manager.HandleAction(pathAction);
            Assert.AreEqual(expectedPlayerAfter, model.ActivePlayerIndex);
            Assert.AreEqual(playerList[expectedPlayerAfter], model.ActivePlayer);
        }

        [TestMethod]
        public void TurnZeroEnds()
        {
            DoTurn(0, 1);
            DoTurn(1, 2);
            DoTurn(2, 3);
            DoTurn(3, 3);
            DoTurn(3, 2);
            DoTurn(2, 1);
            DoTurn(1, 0);
            DoTurn(0, 0);
        }
    }
}