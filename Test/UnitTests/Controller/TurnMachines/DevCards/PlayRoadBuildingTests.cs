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
    public class PlayRoadBuildingTests
    {
        private MockRepository mocks;
        private Player playerZero;
        private Player playerOne;
        private List<Player> playerList;
        private Mock<Presenter> presenterMock;
        private GameBoard board;
        private GameModel model;
        private PlayRoadBuilding state;

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
            var boardMock = mocks.Create<GameBoard>();
            boardMock.Setup(b => b.GetPath(It.IsAny<int>())).CallBase();
            boardMock.Setup(b => b.GetIntersection(It.IsAny<int>())).CallBase();
            boardMock.Setup(b => b.PlaceRoad(It.IsAny<GameModel>(),It.IsAny<int>())).CallBase();
            board = boardMock.Object;
            board.GetIntersection(0).SetOwner(playerZero);
            var bankMock = mocks.Create<Bank>();
            bankMock.Setup(b => b.CanReceive(It.IsAny<ItemContainer>())).Returns(true);
            presenterMock = mocks.Create<Presenter>(Mock.Of<View>());
            model = new GameModel(board, bankMock.Object, playerList,
               presenterMock.Object);
            Mock.Get(board).Setup(b => b.CanPlaceRoadSomewhere(It.IsAny<Player>())).Returns(true);

            state = new PlayRoadBuilding(model);
            var realStates = new HashSet<TurnState>
            {
                state
            };
            TestUtil.SetupStateDictionary(model, mocks, realStates);
            state.ReturnStateType = typeof(TestUtil.TestState);
        }

        [TestMethod]
        public void CheckPrompt()
        {
            Assert.AreEqual(@"place a road.", state.Prompt);
        }

        [TestMethod]
        public void BadInput()
        {
            var next = state.HandleInput(new PlayerAction(ActionType.NoOp));
            presenterMock.Verify(p => p.PromptError( @"You have selected an invalid action or target for an action. Please try again."));
            Assert.AreEqual(state, next);
        }

        [TestMethod]
        public void FirstRoadTest()
        { 
            var next = state.HandleInput(new PlayerAction(ActionType.Path, 0));
            presenterMock.Verify(p=>p.ColorRoad(playerZero, 0));

            Assert.AreEqual(state, next);
            Assert.AreEqual(playerZero, board.GetPath(0).GetOwner());
        }

        [TestMethod]
        public void SecondRoadTest()
        {
            var next = state.HandleInput(new PlayerAction(ActionType.Path, 0));
            presenterMock.Verify(p => p.PromptUser(playerZero, @"place the second road."));
            var next2 = next.HandleInput(new PlayerAction(ActionType.Path, 1));
            presenterMock.Verify(p => p.ColorRoad(playerZero, 0));
            presenterMock.Verify(p => p.ColorRoad(playerZero, 1));

            Assert.AreEqual(state, next);
            Assert.IsInstanceOfType(next2, typeof(TestUtil.TestState));
            Assert.AreEqual(playerZero, board.GetPath(0).GetOwner());
            Assert.AreEqual(playerZero, board.GetPath(1).GetOwner());
        }

        [TestMethod]
        public void OnlyOneRoadLeft()
        {
            playerZero.UnsafeSetAmount(Item.Road, 1);
            var next = state.HandleInput(new PlayerAction(ActionType.Path, 0));
            Assert.AreEqual(state, next);

            var next2 = state.HandleInput(new PlayerAction(ActionType.Path, 1));
            Assert.IsInstanceOfType(next2, typeof(TestUtil.TestState));
            
            Assert.AreEqual(playerZero, board.GetPath(0).GetOwner());
            Assert.AreEqual(null, board.GetPath(1).GetOwner());
        }

        [TestMethod]
        public void NoRoadsLeft()
        {
            playerZero.UnsafeSetAmount(Item.Road, 0);
            var next = state.HandleInput(new PlayerAction(ActionType.Path, 0));

            Assert.IsInstanceOfType(next, typeof(TestUtil.TestState));
            Assert.AreEqual(null, board.GetPath(0).GetOwner());
        }

        [TestMethod]
        public void InvalidRoadPosition()
        {
            board.GetPath(50).SetOwner(playerOne);
            board.GetIntersection(4).SetOwner(playerZero);
            playerOne.UnsafeSetAmount(Item.Road, 15);
            Mock.Get(board).Setup(b => b.CanPlaceRoadSomewhere(playerZero)).Returns(true);
            var next = state.HandleInput(new PlayerAction(ActionType.Path, 50));
            presenterMock.Verify(p => p.PromptError(@"Your road must be adjacent to one of your cities, settlements, or roads, and cannot cross other player's settlements or cities."));
            Assert.AreEqual(state, next);
        }

        [TestMethod]
        public void OnlyOneValidRoadPlace()
        {
            Mock.Get(board).Setup(b => b.CanPlaceRoadSomewhere(It.IsAny<Player>())).Returns(true);
            Mock.Get(board).Setup(b => b.PlaceRoad(It.IsAny<GameModel>(), It.IsAny<int>())).Returns(true);
            board.GetPath(1).SetOwner(playerOne);
            board.GetPath(6).SetOwner(playerOne);

            var next = state.HandleInput(new PlayerAction(ActionType.Path, 0));
            var next1 = state.HandleInput(new PlayerAction(ActionType.Path, 0));

            Assert.AreEqual(state, next);
            Assert.IsInstanceOfType(next1, typeof(TestUtil.TestState));
        }

        [TestMethod]
        public void NoValidRoadPlace()
        {
            Mock.Get(board).Setup(b => b.CanPlaceRoadSomewhere(It.IsAny<Player>())).Returns(false);
            board.GetPath(0).SetOwner(playerOne);
            board.GetPath(6).SetOwner(playerOne);

            var next = state.HandleInput(new PlayerAction(ActionType.Path, 0));
            
            Assert.IsInstanceOfType(next, typeof(TestUtil.TestState));
        }
    }
}
