using System;
using System.Collections.Generic;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Model
{
    [TestClass]
    public class GameModelUnitTest
    {
        // See also: Model/SpecFlowUtil/Victory.feature

        private MockRepository mocks;
        private Mock<GameBoard> boardMock;
        private Mock<Bank> bankMock;
        private Mock<Presenter> presenterMock;
        private Player player;
        private Player otherPlayer;
        private GameModel model;
        
        [TestInitialize]
        public void SetupTest()
        {
            mocks = new MockRepository(MockBehavior.Loose) {DefaultValue = DefaultValue.Mock};
            boardMock = mocks.Create<GameBoard>();
            bankMock = mocks.Create<Bank>();
            var playerMock = mocks.Create<Player>(PlayerColor.Blue);
            player = playerMock.Object;
            var otherPlayerMock = mocks.Create<Player>(PlayerColor.Red);
            otherPlayer = otherPlayerMock.Object;
            var players = new List<Player>
            {
                player,
                otherPlayer
            };
            presenterMock = mocks.Create<Presenter>(Mock.Of<View>());
            model = new GameModel(boardMock.Object, bankMock.Object, players, presenterMock.Object);
            TestUtil.SetupStateDictionary(model, mocks, new HashSet<TurnState>());
        }

        [TestMethod]
        public void GetPlayerReturnsCorrectPlayers()
        {
            Assert.AreSame(model.Players[0], player);
            Assert.AreSame(model.Players[1], otherPlayer);
        }

        [TestMethod]
        public void CheckNullReturnState()
        {
            TurnState state = new Build(model);
            Assert.ThrowsException<InvalidOperationException>(() => state.ReturnState);
        }
    }
}
