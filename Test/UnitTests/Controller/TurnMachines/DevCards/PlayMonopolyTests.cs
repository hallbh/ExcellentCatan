using System.Collections.Generic;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.DevCards;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Controller.TurnMachines.DevCards
{
    [TestClass]
    public class PlayMonopolyTests
    {
        private MockRepository mocks;
        private Mock<Player> playerZero;
        private Mock<Player> playerOne;
        private List<Player> playerList;
        private Mock<GameBoard> board;
        private Mock<Bank> bank;
        private Mock<Presenter> presenter;
        private GameModel model;
        private PlayMonopoly state;

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
            
            state = new PlayMonopoly(model);
            var realStates = new HashSet<TurnState>
            {
                state
            };
            TestUtil.SetupStateDictionary(model, mocks,realStates);
            state.ReturnStateType = typeof(TestUtil.TestState);
        }

        [TestMethod]
        public void CheckPrompt()
        {
            Assert.AreEqual(@"select a hex for the resource you would like to steal from everyone.", state.Prompt);
        }

        [TestMethod]
        public void BadInput()
        {
            var next = state.HandleInput(new PlayerAction(ActionType.NoOp));
            presenter.Verify(p => p.PromptError(@"You have selected an invalid action or target for an action. Please try again."));
            Assert.AreEqual(state, next);
        }

        [TestMethod]
        public void NormalFlowTest()
        {
            playerOne.Object.UnsafeSetAmount(Item.Lumber, 2);
            playerOne.Setup(p => p.Transfer(It.Is<ItemContainer>(i=> i.GetAmount(Item.Lumber)==2), playerZero.Object)).Verifiable();

            board.Setup(b => b.GetHex(0)).CallBase().Verifiable();
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));

            mocks.Verify();

            Assert.AreEqual(model.State<TestUtil.TestState>(), next);
        }

        [TestMethod]
        public void StealDesert()
        {
            board.Setup(b => b.GetHex(7)).CallBase().Verifiable();
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 7));

            presenter.Verify(p => p.PromptError(@"You have selected an invalid action or target for an action. Please try again."));
            mocks.Verify();

            Assert.AreEqual(state, next);
        }

        [TestMethod]
        public void InvalidInput()
        {
            var next = state.HandleInput(new PlayerAction(ActionType.RequestCity));

            mocks.Verify();

            Assert.AreEqual(state, next);
        }
    }
}
