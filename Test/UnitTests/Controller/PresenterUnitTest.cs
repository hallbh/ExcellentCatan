using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Controller
{
    [TestClass]
    public class PresenterUnitTest
    {
        private readonly MockRepository mocks = new MockRepository(MockBehavior.Loose);
        private Mock<View> view;
        private Mock<Player> player;
        private const int Index = 4;
        private const int Value = 4;
        private Presenter presenter;

        [TestInitialize]
        public void InitializeTest()
        {
            view = mocks.Create<View>();
            player = mocks.Create<Player>(PlayerColor.Red);
            presenter = new Presenter(view.Object);
        }

        [TestMethod]
        public void TestMainLoop()
        {
            view.Setup(v => v.HasNextPlayerAction()).Returns(true).Verifiable();
            view.Setup(v => v.GetNextPlayerAction()).Returns(new PlayerAction(ActionType.Exit)).Verifiable();
            presenter.MainLoop();
            view.Verify();
        }

        [TestMethod]
        public void ColorsRoad()
        {
            presenter.ColorRoad(player.Object, Index);

            view.Verify(v => v.ColorRoad(PlayerColor.Red, Index));
            view.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ColorsSettlement()
        {
            presenter.ColorSettlement(player.Object, Index);

            view.Verify(v => v.ColorSettlement(PlayerColor.Red, Index));
            view.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void SetCity()
        {
            presenter.SetCity(Index);

            view.Verify(v => v.SetCity(Index));
            view.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void SetRobberPosition()
        {
            presenter.SetRobberPosition(Index);

            view.Verify(v => v.SetRobberPosition(Index));
            view.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void RollDiceValue()
        {
            presenter.RollDiceValue(Value);

            view.Verify(v => v.SetDiceRoll(Value.ToString()));
            view.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void PromptUser()
        {
            presenter.PromptUser(player.Object, "test message");
            view.Verify(v => v.SetPromptLabel("Red, test message"));
            view.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void DisplayPlayerResources()
        {
            var itemDictionary = new Dictionary<Item, int>
            {
                {Item.Lumber, 1},
                {Item.Brick, 3},
                {Item.Grain, 4},
                {Item.Ore, 2},
                {Item.Wool, 1},
                {Item.KnightCard, 10},
                {Item.YearOfPlentyCard, 1},
                {Item.RoadBuildingCard, 0},
                {Item.MonopolyCard, 2},
                {Item.VictoryPointCard, 5}
            }.ToImmutableDictionary();
            foreach (var pair in itemDictionary)
            {
                player.Object.UnsafeSetAmount(pair.Key, pair.Value);
            }

            presenter.DisplayPlayerResources(player.Object);

            view.Verify(v => v.SetPlayerName("Red"));
            foreach (var resource in itemDictionary)
            {
                view.Verify(v => v.SetResource(resource.Key,It.IsAny<string>()));
            }

            view.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ProcessPlayerActionsHappyPath()
        {
            view.SetupSequence(v => v.HasNextPlayerAction()).Returns(true).Returns(false);
            // Easier not to mock PlayerAction due to data class & properties
            var action = new PlayerAction(ActionType.Hex, 1);
            view.SetupSequence(v => v.GetNextPlayerAction()).Returns(action)
                .Throws(new InvalidOperationException("GetNextPlayerAction should only be called once in this test"));
            
            var model = new GameModel(Mock.Of<GameBoard>(),Mock.Of<Bank>(), new List<Player>{player.Object}, presenter);
            var manager = mocks.Create<TurnManager>( model);
            manager.Setup(m => m.HandleAction(action));
            presenter.RegisterTurnManager(manager.Object);

            presenter.ProcessPlayerActions();

            Assert.IsFalse(presenter.GameOver);
        }

        [TestMethod]
        public void ProcessPlayerActionsReturnsTrueWhenDone()
        {
            view.SetupSequence(v => v.HasNextPlayerAction()).Returns(true).Returns(false);
            view.Setup(v => v.GetNextPlayerAction()).Returns(new PlayerAction(ActionType.Exit));

            presenter.ProcessPlayerActions();
            
            Assert.IsTrue(presenter.GameOver);
        }

        [TestMethod]
        public void DisplayPlayerVictory()
        {
            presenter.DisplayPlayerVictory(player.Object);
            view.Verify(v => v.DisplayPlayerVictory(PlayerColor.Red,"Red Wins!"));
        }

        [TestMethod]
        public void SetupHexEnglish()
        {
            var hexMock = mocks.Create<Hex>(new List<Intersection>(), Item.Brick, 6);
            presenter.SetupHex(4,hexMock.Object);
            view.Verify(v=>v.SetupHex(4,"Brick: 6",Item.Brick));
        }

        [TestMethod]
        public void SetupHarbor()
        {
            var harborMock = mocks.Create<Harbor>(Item.Any, new List<Intersection> {new Intersection(), new Intersection()});
            presenter.SetupHarbor(0, harborMock.Object);
            view.Verify(v => v.SetupHarbor(0, "3: 1", Item.Any));
        }

        [TestMethod]
        public void PromptError()
        {
            presenter.PromptError("test message");
            view.Verify(v => v.SetErrorPromptLabel("test message"));
            view.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void DisplayLargestArmyOwner()
        {
            presenter.DisplayLargestArmyOwner("test message");
            view.Verify(v => v.SetLargestArmyOwner("test message"));
            view.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void DisplayLongestRoadOwner()
        {
            presenter.DisplayLongestRoadOwner("test message");
            view.Verify(v => v.SetLongestRoadOwner("test message"));
            view.VerifyNoOtherCalls();
        }
    }
}
