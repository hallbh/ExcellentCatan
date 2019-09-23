using System.Collections.Generic;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Controller.TurnMachines.TurnZero;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Controller.TurnMachines.TurnZero
{
    [TestClass]
    public class PlaceInitialRoadUnitTest
    {
        private MockRepository mocks;
        private Mock<Player> playerZero;
        private Mock<Player> playerOne;
        private Mock<Player> playerTwo;
        private Mock<Player> playerThree;
        private List<Player> playerList;
        private Mock<GameBoard> board;
        private Mock<Bank> bank;
        private GameModel model;
        private Mock<Presenter> presenter;
        private PlaceInitialRoad state;

        [TestInitialize]
        public void SetupTests()
        {
            mocks = new MockRepository(MockBehavior.Loose);

            playerZero = mocks.Create<Player>(PlayerColor.Blue);
            playerOne =  mocks.Create<Player>(PlayerColor.Red);
            playerTwo =  mocks.Create<Player>(PlayerColor.Orange);
            playerThree =  mocks.Create<Player>(PlayerColor.White);
            playerList = new List<Player>
            {
                playerZero.Object,
                playerOne.Object,
                playerTwo.Object,
                playerThree.Object
            };
            board = mocks.Create<GameBoard>();

            bank = mocks.Create<Bank>();
            presenter = mocks.Create<Presenter>(Mock.Of<View>());
            model = new GameModel(board.Object, bank.Object, playerList,presenter.Object);

            state = new PlaceInitialRoad(model);
            var realStates = new HashSet<TurnState>
            {
                state
            };
            TestUtil.SetupStateDictionary(model, mocks, realStates);
            board.Setup(b => b.GetIntersection(It.IsAny<int>())).CallBase();
            board.Setup(b => b.GetPath(It.IsAny<int>())).CallBase();
            board.Setup(b => b.PlaceRoad(It.IsAny<GameModel>(),It.IsAny<int>())).CallBase();
        }

        private void SetupForTest(Player player, int intersectionIndex)
        {
            board.Object.GetIntersection(intersectionIndex).SetOwner(player);
            state.SetIntersectionIndex(intersectionIndex);
        }

        [TestMethod]
        public void BadRoadInput()
        {
            var action = new PlayerAction(ActionType.EndTurn, 0);
            var nextState = state.HandleInput(action);
            Assert.AreEqual(state, nextState);
            presenter.Verify(p => p.PromptError("That is not a path!"));
        }

        [TestMethod]
        public void RepeatsTheLastPlayer()
        {
            const int intersectionIndex = 12;
            const int pathIndex = 15;
            SetupForTest(playerThree.Object, intersectionIndex);
            model.ActivePlayer = playerThree.Object;

            var nextState = state.HandleInput(new PlayerAction(ActionType.Path, pathIndex));

            Assert.AreSame(playerThree.Object, model.ActivePlayer);
            Assert.IsInstanceOfType(nextState, typeof(PlaceInitialSettlement));
        }

        [TestMethod]
        public void GoesInReverseTheSecondRound()
        {
            const int intersectionIndex = 12;
            const int pathIndex = 15;
            SetupForTest(playerThree.Object, intersectionIndex);
            model.State<PlaceInitialRoad>().SecondRound = true;
            model.ActivePlayer = playerThree.Object;
            state.SetIntersectionIndex(intersectionIndex);

            var nextState = state.HandleInput(new PlayerAction(ActionType.Path, pathIndex));

            Assert.AreEqual(2, model.ActivePlayerIndex);
            Assert.AreSame(playerList[2], model.ActivePlayer);
            Assert.IsInstanceOfType(nextState, typeof(PlaceInitialSettlement));
        }

        [TestMethod]
        public void TurnZeroTransitionsToNormalPlay()
        {

            const int intersectionIndex = 12;
            const int pathIndex = 15;
            SetupForTest(playerZero.Object, intersectionIndex);
            model.State<PlaceInitialRoad>().SecondRound = true;
            model.ActivePlayerIndex = 0;
            state.SetIntersectionIndex(intersectionIndex);

            var nextState = state.HandleInput(new PlayerAction(ActionType.Path, pathIndex));

            Assert.AreSame(playerList[0], model.ActivePlayer);
            Assert.IsInstanceOfType(nextState, typeof(WaitRollDice));
        }
        
        [TestMethod]
        public void InitialRoadBuildingSetsOwner()
        {
            const int intersectionIndex = 9;
            const int pathIndex = 12;
            board.Object.GetIntersection(intersectionIndex).SetOwner(playerZero.Object);
            state.SetIntersectionIndex(intersectionIndex);

            var next = state.HandleInput(new PlayerAction(ActionType.Path, pathIndex));

            Assert.IsInstanceOfType(next, typeof(PlaceInitialSettlement));
            Assert.AreEqual(playerZero.Object,board.Object.GetPath(pathIndex).GetOwner());
            presenter.Verify(p => p.PromptError(""));
        }

        [TestMethod]
        public void RoadMayNotBePlacedNextToWrongSettlement()
        {
            const int firstSettlementIndex = 20;
            const int secondSettlementIndex = 44;
            const int pathIndex = 26; // Next to settlement 20
            board.Object.GetIntersection(firstSettlementIndex).SetOwner(playerZero.Object);
            board.Object.GetIntersection(secondSettlementIndex).SetOwner(playerZero.Object);
            state.SetIntersectionIndex(secondSettlementIndex);

            var next = state.HandleInput(new PlayerAction(ActionType.Path, pathIndex));

            Assert.AreEqual(state, next);
            Assert.AreEqual(board.Object.GetPath(pathIndex).GetOwner(), null);
            presenter.Verify(p =>  p.PromptError("Your road must be placed next to your new settlement."));
        }

        [TestMethod]
        public void PlacingDuplicateRoad()
        {
            board.Object.GetIntersection(12).SetOwner(playerZero.Object);
            board.Object.GetPath(15).SetOwner(playerOne.Object);
            state.SetIntersectionIndex(12);

            var next = state.HandleInput(new PlayerAction(ActionType.Path, 15));

            Assert.AreEqual(state, next);
            presenter.Verify(p =>  p.PromptError("You cannot place a road there because is already occupied."));

        }
        
        [TestMethod]
        public void PlaceSingleRoadIsNotAdjacentToSettlementFails()
        {
            board.Object.GetIntersection(12).SetOwner(playerZero.Object);
            board.Object.GetPath(15).SetOwner(playerZero.Object);

            state.SetIntersectionIndex(15);
 
            var next = state.HandleInput(new PlayerAction(ActionType.Path, 16));

 
            Assert.AreEqual(state, next);
            presenter.Verify(p =>  p.PromptError( "Your road must be placed next to your new settlement."));
        }
    }
}
