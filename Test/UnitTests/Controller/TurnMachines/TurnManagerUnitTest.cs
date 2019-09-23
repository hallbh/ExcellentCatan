using System;
using System.Collections.Generic;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.DevCards;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Controller.TurnMachines.TurnZero;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Controller.TurnMachines
{
    [TestClass]
    public class TurnManagerUnitTest
    {
        private MockRepository repository;
        private GameModel model;
        private Mock<Bank> bankMock;
        private Mock<Presenter> presenterMock;
        private Mock<GameBoard> boardMock;
        private Mock<View> viewMock;
        private List<Player> players;
        private Mock<Player> playerMock;
        private TurnManager manager;

        [TestInitialize]
        public void SetupTest()
        {
            repository = new MockRepository(MockBehavior.Loose);
            boardMock = repository.Create<GameBoard>();
            boardMock.Setup(b => b.GetHex(It.IsAny<int>())).CallBase();
            bankMock = repository.Create<Bank>();
            viewMock = repository.Create<View>();
            presenterMock = repository.Create<Presenter>(viewMock.Object);
            playerMock = repository.Create<Player>(PlayerColor.Blue);
            players = new List<Player>
            {
                playerMock.Object,
                repository.Create<Player>(PlayerColor.Orange).Object,
                repository.Create<Player>(PlayerColor.Red).Object,
                repository.Create<Player>(PlayerColor.White).Object
            };
            model = new GameModel(boardMock.Object, bankMock.Object, players, presenterMock.Object);
            TestUtil.SetupStateDictionary(model, repository, new HashSet<TurnState>());
            manager = new TurnManager(model);
        }

        [TestMethod]
        public void StartsWithPlaceSingleSettlement()
        {
            Assert.IsInstanceOfType(manager.CurrentState, typeof(PlaceInitialSettlement));
        }

        private void TestCard(Item has, Item plays, Type expectedType,  ActionType action = ActionType.PlayDevCard)
        {
            playerMock.Object.UnsafeSetAmount(has, 1);
            model.ActivePlayerIndex = 0; // Simulate turn having started
            manager.HandleAction(new PlayerAction(action, -1, plays));
            Assert.IsInstanceOfType(manager.CurrentState, expectedType);

        }

        [TestMethod]
        public void DevCardKnightCard()
        {
            TestCard(Item.KnightCard, Item.KnightCard, typeof(PlayKnight));
        }

        [TestMethod]
        public void DevCardYearOfPlentyCard()
        {
            TestCard(Item.YearOfPlentyCard, Item.YearOfPlentyCard, typeof(PlayYearOfPlenty));
        }

        [TestMethod]
        public void DevCardMonopoly()
        {
            TestCard(Item.MonopolyCard, Item.MonopolyCard, typeof(PlayMonopoly));
        }

       [TestMethod]
        public void DevCardRoadBuildingCard()
        {
            TestCard(Item.RoadBuildingCard, Item.RoadBuildingCard, typeof(PlayRoadBuilding));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Should error if unexpected ActionType is passed in")]
        public void DevCardInvalidActionType()
        {
            manager.HandleDevCard(new PlayerAction(ActionType.PlayDevCard, -1, Item.Desert));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Didn't throw on Invalid Dev Card Type")]
        public void DevCardInvalidValue()
        {
            manager.HandleAction(new PlayerAction(ActionType.PlayDevCard, -1, Item.Road));
        }

        [TestMethod]
        public void DevCardNoCard()
        {
            manager.HandleAction(new PlayerAction(ActionType.PlayDevCard, -1, Item.RoadBuildingCard));
            presenterMock.Verify(p=>p.PromptUser(playerMock.Object, "You do not have any of that kind of card to play!"));
        }

        [TestMethod]
        public void DevCardBoughtThisTurn()
        {
            // Simulate turn having started
            model.ActivePlayerIndex = 0; 
            
            // Turn started, now give the player the card
            playerMock.Object.UnsafeSetAmount(Item.RoadBuildingCard, 1);

            manager.HandleAction(new PlayerAction(ActionType.PlayDevCard, -1, Item.RoadBuildingCard));
            presenterMock.Verify(p=>p.PromptUser(playerMock.Object, "You cannot play a dev card that you bought this turn!"));
            Assert.AreEqual(model.State<PlaceInitialSettlement>(),manager.CurrentState);
        }

        [TestMethod]
        public void DevCardOnlyOnePerTurn()
        {
            playerMock.Object.UnsafeSetAmount(Item.KnightCard, 2);
            // Simulate turn having started
            model.ActivePlayerIndex = 0; 
            
            manager.HandleAction(new PlayerAction(ActionType.PlayDevCard, -1, Item.KnightCard));
            manager.HandleAction(new PlayerAction(ActionType.PlayDevCard, -1, Item.KnightCard));
            presenterMock.Verify(p=>p.PromptError(@"You have already played a dev card this turn!" ));
        }

        [TestMethod]
        public void Victory()
        {
            playerMock.Setup(p => p.CanWin).Returns(true);
            manager.HandleAction(new PlayerAction(ActionType.Build));
            Assert.IsInstanceOfType(manager.CurrentState, typeof(EndGame));
        }
    }
}