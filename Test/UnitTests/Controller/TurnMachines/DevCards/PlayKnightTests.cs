using System.Collections.Generic;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.DevCards;
using Catan.Controller.TurnMachines.Robber;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Controller.TurnMachines.DevCards
{
    [TestClass]
    public class PlayKnightTests
    {
        private MockRepository mocks;
        private Mock<Player> playerZero;
        private Mock<Player> playerOne;
        private List<Player> playerList;
        private Mock<GameBoard> board;
        private Mock<Bank> bank;
        private Mock<Presenter> presenter;
        private GameModel model;
        private PlayKnight state;

        [TestInitialize]
        public void SetupTests()
        {
            mocks = new MockRepository(MockBehavior.Loose);

            playerZero = mocks.Create<Player>(PlayerColor.Blue);
            playerOne = mocks.Create<Player>(PlayerColor.Red);
            playerList = new List<Player>
            {
                playerZero.Object,
                playerOne.Object
            };
            board = mocks.Create<GameBoard>();

            bank = mocks.Create<Bank>();
            presenter = mocks.Create<Presenter>(Mock.Of<View>());
            model = new GameModel(board.Object, bank.Object, playerList, presenter.Object);
            state = new PlayKnight(model);
            var realStates = new HashSet<TurnState>
            {
                state
            };
            TestUtil.SetupStateDictionary(model, mocks, realStates);
            state.ReturnStateType = typeof(TestUtil.TestState);
        }

        [TestMethod]
        public void BadInput()
        {
            var next = state.HandleInput(new PlayerAction(ActionType.NoOp));
            presenter.Verify(p => p.PromptError( @"You have selected an invalid action or target for an action. Please try again."));
            Assert.AreEqual(state, next);
        }
        
        [TestMethod]
        public void NormalFlow()
        {
            board.Setup(b => b.GetHex(It.IsAny<int>())).CallBase().Verifiable();
            board.Setup(b => b.PlaceRobber(0)).Returns(true).Verifiable();
            state.ReturnStateType = typeof(TestUtil.TestState);

            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));
            mocks.Verify();

            Assert.IsInstanceOfType(next, typeof(TestUtil.TestState));
        }

        [TestMethod]
        public void NoMoveRobber()
        {
            board.Setup(b => b.PlaceRobber(7)).Returns(false).Verifiable();

            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 7));
            mocks.Verify();

            Assert.AreEqual(state, next);
        }

        [TestMethod]
        public void InvalidInput()
        {
            var next = state.HandleInput(new PlayerAction(ActionType.EndTurn));
            
            mocks.Verify();

            Assert.AreEqual(state, next);
        }

        [TestMethod]
        public void StealFromOtherPlayer()
        {
            board.Setup(b => b.GetIntersection(0)).CallBase().Verifiable();
            board.Setup(b => b.GetHex(It.IsAny<int>())).CallBase().Verifiable();
            board.Setup(b => b.PlaceRobber(0)).Returns(true).Verifiable();

            board.Object.GetIntersection(0).SetOwner(playerOne.Object);

            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));

            mocks.Verify();

            Assert.IsInstanceOfType(next, typeof(Rob));
        }

        [TestMethod]
        public void TryStealFromSelf()
        {
            board.Setup(b => b.GetIntersection(0)).CallBase().Verifiable();
            board.Setup(b => b.GetHex(It.IsAny<int>())).CallBase().Verifiable();
            board.Setup(b => b.PlaceRobber(0)).Returns(true).Verifiable();

            board.Object.GetIntersection(0).SetOwner(playerZero.Object);

            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));

            mocks.Verify();

            Assert.IsInstanceOfType(next, typeof(TestUtil.TestState));
        }

        [TestMethod]
        public void DisplayRobbingPrompt() {
            state.OnEnter();
            presenter.Verify(p => p.PromptUser(playerZero.Object, "select a hex to place the Robber on."));
        }

    }
}
