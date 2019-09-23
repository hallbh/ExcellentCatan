using System.Collections.Generic;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Controller.TurnMachines
{
    [TestClass]
    public class DoTradeTest
    {
        private MockRepository mocks;
        private Player playerZero;
        private Player playerOne;
        private List<Player> playerList;
        private GameBoard board;
        private Bank bank;
        private Mock<Presenter> presenterMock;
        private GameModel model;
        private DoTrade state;

        [TestInitialize]
        public void SetupTests()
        {
            mocks = new MockRepository(MockBehavior.Loose);

            playerZero = new Player(PlayerColor.Blue);
            playerOne = new Player(PlayerColor.Red);
            playerList = new List<Player>
            {
                playerZero,
                playerOne
            };

            board = new GameBoard();
            bank = new Bank();
            presenterMock = new Mock<Presenter>(Mock.Of<View>());
            model = new GameModel(board, bank, playerList, presenterMock.Object);

            state = new DoTrade(model);
            var realStates = new HashSet<TurnState>
            {
                state
            };
            TestUtil.SetupStateDictionary(model, mocks, realStates);

            GivePlayerFourOfAll(playerZero);
        }

        private static void GivePlayerFourOfAll(Player player)
        {
            var resources = new List<Item> {Item.Lumber, Item.Brick, Item.Grain, Item.Ore, Item.Wool};
            foreach (var res in resources)
            {
                player.UnsafeSetAmount(res, 4);
            }
        }

        [TestMethod]
        public void TestDoTradePrompt()
        {
            Assert.AreEqual(@"Select the hex of the type of resource you would like to trade away", state.Prompt);
        }

        [TestMethod]
        public void TestDoTradeOnEnter()
        {
            Assert.IsFalse(state.ExchangeTypeSelected);
        }

        [TestMethod]
        public void FourToOneDoTrade()
        {
            state.SetTradeType(Item.Any, 4);
            DoTrade(5, 0);
        }

        [TestMethod]
        public void ThreeToOneDoTrade()
        {
            state.SetTradeType(Item.Any, 3);
            DoTrade(5, 1);
        }

        [TestMethod]
        public void FourToOneExchangeSimilarFail()
        {
            state.SetTradeType(Item.Any, 4);
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));
            var next1 = state.HandleInput(new PlayerAction(ActionType.Hex, 0));

            Assert.AreEqual(state, next);
            Assert.AreEqual(state, next1);
        }

        [TestMethod]
        public void FourToOneNotEnough()
        {
            state.SetTradeType(Item.Any, 4);
            model.ActivePlayer = playerOne;
            playerOne.UnsafeSetAmount(Item.Lumber, 0);

            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));
            presenterMock.Verify(p =>
                p.PromptError(
                    @"sorry, you don't have enough of that to trade. Select the hex of the type of resource you would like to trade away."));
            Assert.AreEqual(state, next);
        }

        [TestMethod]
        public void FourToOneNonHex()
        {
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));
            Assert.AreEqual(state, next);
        }

        [TestMethod]
        public void FourToOneDesert()
        {
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 7));
            Assert.AreEqual(state, next);
        }

        [TestMethod]
        public void FourToOneOutOfResource()
        {
            state.SetTradeType(Item.Any, 4);
            bank.UnsafeSetAmount(Item.Wool, 0);
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));
            var next1 = state.HandleInput(new PlayerAction(ActionType.Hex, 1));

            presenterMock.Verify(p =>
                p.PromptError(
                    "sorry, that resource has run out. Select a different hex for a resource you would like to receive."));

            Assert.AreEqual(state, next);
            Assert.AreEqual(state, next1);
        }

        private void DoTrade(int expectedWool, int expectedLumber)
        {
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));
            var next1 = next.HandleInput(new PlayerAction(ActionType.Hex, 1));

            Assert.AreEqual(state, next);
            Assert.IsInstanceOfType(next1, typeof(Trade));
            Assert.AreEqual(expectedWool, playerZero.GetAmount(Item.Wool));
            Assert.AreEqual(expectedLumber, playerZero.GetAmount(Item.Lumber));
        }

        [TestMethod]
        public void TwoToOneDoTrade()
        {
            state.SetTradeType(Item.Lumber, 2);
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 1));

            Assert.IsInstanceOfType(next, typeof(Trade));
            Assert.AreEqual(5, playerZero.GetAmount(Item.Wool));
            Assert.AreEqual(2, playerZero.GetAmount(Item.Lumber));
        }

        [TestMethod]
        public void BadInput()
        {
            var next = state.HandleInput(new PlayerAction(ActionType.NoOp));
            presenterMock.Verify(p => p.PromptError( @"You have selected an invalid action or target for an action. Please try again."));
            Assert.AreEqual(state, next);
        }

    }
}
