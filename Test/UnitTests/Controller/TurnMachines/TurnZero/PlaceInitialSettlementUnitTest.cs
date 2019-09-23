using System.Collections.Generic;
using Catan.Controller;
using Catan.Controller.TurnMachines.TurnZero;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Controller.TurnMachines.TurnZero
{
    [TestClass]
    public class PlaceInitialSettlementUnitTest
    {
        private MockRepository mocks;
        private GameModel model;
        private Mock<GameBoard> board;
        private Mock<Player> playerZero;
        private Mock<View> view;
        private Mock<Presenter> presenter;
        private Mock<Bank> bankMock;
        private List<Player> players;
        private PlaceInitialSettlement initialState;

        [TestInitialize]
        public void SetupTests()
        {
            mocks = new MockRepository(MockBehavior.Loose);
            playerZero = mocks.Create<Player>(PlayerColor.Blue);
            board = mocks.Create<GameBoard>();

            view = mocks.Create<View>(MockBehavior.Loose);
            presenter = mocks.Create<Presenter>(view.Object);
            view.Setup(x => x.SetPlayerName(playerZero.Object.Color.ToString()));
            players = new List<Player>
            {
                playerZero.Object,
                mocks.Create<Player>(PlayerColor.Orange).Object,
                mocks.Create<Player>(PlayerColor.Red).Object,
                mocks.Create<Player>(PlayerColor.White).Object
            };
            bankMock = mocks.Create<Bank>();
            model = new GameModel(board.Object, bankMock.Object, players, presenter.Object);
            mocks.Create<PlaceInitialRoad>();
            initialState = new PlaceInitialSettlement(model);
        }

        [TestMethod]
        public void Prompt()
        {
            initialState.OnEnter();
            presenter.Verify(p => p.PromptUser(playerZero.Object, "place a settlement."));
        }

        [TestMethod]
        public void BadInput()
        {
            var action = new PlayerAction(ActionType.Hex, 0);
            board.Setup(b => b.PlaceInitialSettlement(playerZero.Object, 0)).Returns(true);

            var nextState = initialState.HandleInput(action);

            Assert.AreEqual(initialState, nextState);
            presenter.Verify(p =>  p.PromptError("settlements must be placed on intersections."));
        }

        [TestMethod]
        public void ValidLoc()
        {
            board.Setup(b => b.PlaceInitialSettlement(playerZero.Object, 0)).Returns(true);
            view.Setup(x => x.ColorSettlement(PlayerColor.Blue, 0));

            var action = new PlayerAction(ActionType.Intersection, 0);

            var nextState = initialState.HandleInput(action);

            Assert.IsTrue(nextState is PlaceInitialRoad);
            presenter.Verify(p => p.ColorSettlement(playerZero.Object, 0));
        }

        [TestMethod]
        public void InvalidLoc()
        {
            board.Setup(b => b.PlaceInitialSettlement(playerZero.Object, 0)).Returns(false);

            var action = new PlayerAction(ActionType.Intersection, 0);
            var nextState = initialState.HandleInput(action);

            Assert.AreSame(initialState, nextState);
            presenter.Verify(p =>  p.PromptError("your settlement must be at least two roads away from other settlements."));
        }
    }
}
