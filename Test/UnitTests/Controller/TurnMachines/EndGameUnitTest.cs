using System.Collections.Generic;
using Catan.Controller;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Controller.TurnMachines
{
    [TestClass]
    public class EndGameUnitTest
    {
        private MockRepository mocks;
        private EndGame currentState;
        private Mock<Presenter> presenterMock;
        private Player player;

        [TestInitialize]
        public void SetupTest()
        {
            mocks = new MockRepository(MockBehavior.Default);
            presenterMock = mocks.Create<Presenter>(Mock.Of<View>());
            player = mocks.Create<Player>(PlayerColor.Red).Object;
            var modelMock = mocks.Create<GameModel>(null, null,  new List<Player>{player}, presenterMock.Object, null);
            currentState = new EndGame(modelMock.Object);
        }
        [TestMethod]
        public void IgnoresInput()
        {
            var nextState = currentState.HandleInput(new PlayerAction(ActionType.Intersection));
            Assert.AreSame(currentState,nextState);
        }

        [TestMethod]
        public void OnEnter()
        {
            currentState.OnEnter();
            presenterMock.Verify(p=>p.DisplayPlayerVictory(player));
        }


        [TestMethod]
        public void NoPrompt()
        {
            Assert.AreEqual("",currentState.Prompt);
        }
    }
}
