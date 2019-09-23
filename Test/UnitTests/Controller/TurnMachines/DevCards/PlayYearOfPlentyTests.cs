using System;
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
    public class PlayYearOfPlentyTests
    {
        private MockRepository mocks;
        private Mock<Player> playerZero;
        private Mock<Player> playerOne;
        private List<Player> playerList;
        private Mock<GameBoard> board;
        private Mock<Bank> bank;
        private Mock<Presenter> presenter;
        private GameModel model;
        private PlayYearOfPlenty state;

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
            
            state = new PlayYearOfPlenty(model);
            var realStates = new HashSet<TurnState>
            {
                state
            };
            
            board.Setup(b => b.GetHex(It.IsAny<int>())).CallBase();
            TestUtil.SetupStateDictionary(model, mocks, realStates);
            state.ReturnStateType = typeof(TestUtil.TestState);
        }

        private void SetupVerifiableBankTransfer()
        {
            
            bank.Setup(b => b.CanTransfer(It.IsAny<ItemContainer>())).Returns(true).Verifiable();
            bank.Setup(b => b.Transfer(It.IsAny<ItemContainer>(), It.IsAny<ItemContainer>()))
                .Callback<ItemContainer, ItemContainer>(
                    (amounts, dest) =>
                    {
                        foreach (var pair in amounts.GetMatchingItems(ItemHelper.ResourceCards))
                        {
                            dest.UnsafeSetAmount(pair.Key, dest.GetAmount(pair.Key) + pair.Value);
                        }

                    }).Verifiable();
        }

        [TestMethod] // Basis path coverage
        public void BadInput()
        {
            SetupVerifiableBankTransfer();
            var next = state.HandleInput(new PlayerAction(ActionType.RequestSettlement));

            presenter.Verify(p => p.PromptError("You must select a hex corresponding to the resource you wish to receive (Desert doesn't count!)."));

            Assert.AreEqual(state, next);
        }

        [TestMethod]
        public void OnEnter()
        {
            SetupVerifiableBankTransfer();
            state.OnEnter();
            presenter.Verify(p=> p.PromptUser(playerZero.Object,"select a hex for the first resource you would like to receive."));
        }

        [TestMethod]
        public void NormalFlow()
        {
            SetupVerifiableBankTransfer();

            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));
            presenter.Verify(p=> p.PromptUser(playerZero.Object,"select a hex for the second resource you would like to receive."));
            var next2 = next.HandleInput(new PlayerAction(ActionType.Hex, 0));

            mocks.Verify();

            Assert.IsInstanceOfType(next2, typeof(TestUtil.TestState));
        }

        [TestMethod]
        public void DesertFirstTurn()
        {
            SetupVerifiableBankTransfer();

            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 7));
            
            presenter.Verify(p=> p.PromptError("You must select a hex corresponding to the resource you wish to receive (Desert doesn't count!)."));

            Assert.AreEqual(state, next);
        }

        [TestMethod]
        public void DesertSecondTurn()
        {
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));
            var next2 = next.HandleInput(new PlayerAction(ActionType.Hex, 7));

            
            presenter.Verify(p=> p.PromptError("You must select a hex corresponding to the resource you wish to receive (Desert doesn't count!)."));
            
            Assert.AreEqual(state, next);
            Assert.AreEqual(state, next2);
        }

        [TestMethod] // Only one of one resource remains, and the player can take it
        public void OneLeft()
        {
            SetupVerifiableBankTransfer();
            
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));
            bank.Setup(b => b.CanTransfer(It.IsAny<ItemContainer>())).Returns(false);// No more lumber
            var next1 = next.HandleInput(new PlayerAction(ActionType.Hex, 0));
            bank.Setup(b => b.CanTransfer(It.IsAny<ItemContainer>())).Returns(true);
            var next2 = next1.HandleInput(new PlayerAction(ActionType.Hex, 1));

            mocks.Verify();

            Assert.AreEqual(state, next);
            Assert.AreEqual(state, next1);
            Assert.IsInstanceOfType(next2, typeof(TestUtil.TestState));
        }

        [TestMethod] 
        public void NoLumber()
        {
            bank.Setup(b => b.CanTransfer(It.IsAny<ItemContainer>())).Returns(false).Verifiable();
            
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));

            mocks.Verify();

            Assert.AreEqual(state, next);
        }

        private void ZeroBankContents()
        {
            foreach (Item item in Enum.GetValues(typeof(Item)))
            {
                bank.Object.UnsafeSetAmount(item, 0);
            }
        }
        
        [TestMethod]
        public void OnlyOneResourceInBank()
        {
            ZeroBankContents();
            playerZero.Setup(p => p.CanReceive(It.IsAny<ItemContainer>())).CallBase();
            bank.Object.UnsafeSetAmount(Item.Lumber, 1);
            bank.Setup(b => b.CanTransfer(It.IsAny<ItemContainer>())).CallBase().Verifiable();
            bank.Setup(b => b.Transfer(It.IsAny<ItemContainer>(), It.IsAny<ItemContainer>())).CallBase().Verifiable();
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));
            var next1 = next.HandleInput(new PlayerAction(ActionType.Hex, 0));

            presenter.Verify(p=> p.PromptError("sorry, there are no remaining resources."));
            mocks.Verify();
            
            Assert.IsInstanceOfType(next1, typeof(TestUtil.TestState));
        }

        [TestMethod]
        public void NoResources()
        {
            ZeroBankContents();
            var next = state.HandleInput(new PlayerAction(ActionType.Hex, 0));
            
            presenter.Verify(p=> p.PromptError( "sorry, there are no remaining resources."));
            mocks.Verify();
            
            Assert.IsInstanceOfType(next, typeof(TestUtil.TestState));
        }
    }
}
