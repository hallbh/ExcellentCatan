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
    public class TradeTestSimple
    {
        private MockRepository mocks;
        private Mock<Player> playerZero;
        private Mock<Player> playerOne;
        private List<Player> playerList;
        private Mock<GameBoard> board;
        private Mock<Bank> bank;
        private Mock<Presenter> presenter;
        private GameModel model;
        private Trade state;

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
            state = new Trade(model);
            var realStates = new HashSet<TurnState>
            {
                state
            };
            TestUtil.SetupStateDictionary(model, mocks, realStates);
            state.ReturnStateType = typeof(TestUtil.TestState);
        }

        [TestMethod]
        public void CanActivePlayerTrade()
        {
            Assert.IsFalse(state.CanActivePlayerTrade(4, Item.Any));
            playerZero.Object.UnsafeSetAmount(Item.Lumber, 4);

            Assert.IsTrue(state.CanActivePlayerTrade(4, Item.Any));
        }

        [TestMethod]
        public void CanActivePlayerTradeSpecific()
        {
            Assert.IsFalse(state.CanActivePlayerTrade(2, Item.Lumber));
            playerZero.Object.UnsafeSetAmount(Item.Lumber, 4);

            Assert.IsTrue(state.CanActivePlayerTrade(2, Item.Lumber));
        }
    }
}
