using System;
using System.Collections.Generic;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.IntegrationTests
{
    [TestClass]
    public class TurnManagerIntegrationTest
    {
        private MockRepository repository;
        private GameModel model;
        private Mock<Player> playerMock;
        private List<Player> players;
        private TurnManager manager;

        [TestInitialize]
        public void SetupTest()
        {
            repository = new MockRepository(MockBehavior.Loose);
            var boardMock = repository.Create<GameBoard>();
            boardMock.Setup(b => b.GetHex(It.IsAny<int>())).CallBase();
            var bankMock = repository.Create<Bank>();
            var viewMock = repository.Create<View>();
            var presenterMock = repository.Create<Presenter>(viewMock.Object);
            playerMock = repository.Create<Player>(PlayerColor.Blue);
            players = new List<Player>
            {
                playerMock.Object,
                repository.Create<Player>(PlayerColor.Orange).Object,
                repository.Create<Player>(PlayerColor.Red).Object,
                repository.Create<Player>(PlayerColor.White).Object
            };
            model = new GameModel(boardMock.Object, bankMock.Object, players, presenterMock.Object);
            manager = new TurnManager(model);
        }

        [TestMethod]
        public void WinBeforeTurn()
        {
            playerMock.SetupGet(p => p.CanWin).Returns(true);
            model.ActivePlayer = playerMock.Object;
            manager.CurrentState = new Build(model);
            manager.HandleAction(new PlayerAction(ActionType.EndTurn));
            Assert.IsInstanceOfType(manager.CurrentState, typeof(EndGame));
        }

        [TestMethod]
        public void WinDuringTurn()
        {
            model.ActivePlayer = playerMock.Object;
            manager.CurrentState = model.State<Build>();
            playerMock.SetupGet(p => p.CanWin).Returns(true);
            manager.HandleAction(new PlayerAction(ActionType.RollDice));
            Assert.IsInstanceOfType(manager.CurrentState, typeof(EndGame));
        }

        [TestMethod]
        public void NormalFlow()
        {
            var rollDice = model.State<WaitRollDice>();
            manager.CurrentState = rollDice;

            // Prevents sometimes failing test due to Robber State
            var rndMock = repository.Create<Random>();
            rndMock.Setup(p => p.Next(1, 6)).Returns(2);
            WaitRollDice.Rnd = rndMock.Object;
            manager.HandleAction(new PlayerAction(ActionType.RollDice));
            Assert.IsInstanceOfType(manager.CurrentState, typeof(Trade));
            manager.HandleAction(new PlayerAction(ActionType.Build));
            Assert.IsInstanceOfType(manager.CurrentState, typeof(Build));
            manager.HandleAction(new PlayerAction(ActionType.EndTurn));

            Assert.IsInstanceOfType(manager.CurrentState, typeof(WaitRollDice));
            Assert.AreEqual(players[1], model.ActivePlayer);
            Assert.AreEqual(1, (object) manager.Model.ActivePlayerIndex);
        }
    }
}