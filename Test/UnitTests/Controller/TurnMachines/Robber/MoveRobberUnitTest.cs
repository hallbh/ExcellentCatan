using System.Collections.Generic;
using System.Collections.Immutable;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Controller.TurnMachines.Robber;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Controller.TurnMachines.Robber
{
    [TestClass]
    public class MoveRobberUnitTest
    {        
        private Mock<Bank> bank;
        private Mock<GameBoard> board;
        private Mock<Player> playerZero;
        private Mock<Presenter> presenter;

        [TestInitialize]
        public void SetupTests()
        {
            var mocks = new MockRepository(MockBehavior.Loose);
            playerZero = mocks.Create<Player>(PlayerColor.Blue);
            var playerList = new List<Player>{
                playerZero.Object
            };
            bank = mocks.Create<Bank>();
            board = mocks.Create<GameBoard>();
            var view = mocks.Create<View>(MockBehavior.Loose);
            presenter = mocks.Create<Presenter>(view.Object);
            view.Setup(x => x.SetPlayerName(playerZero.Object.Color.ToString()));
            var model = new GameModel(board.Object, bank.Object, playerList,presenter.Object);
            
            var turnState = new MoveRobber(model);
            var realStates = new HashSet<TurnState>
            {
                turnState
            };
                
            TestUtil.SetupStateDictionary(model, mocks, realStates);
            board.Setup(b => b.GetHex(It.IsAny<int>())).CallBase();
            board.Setup(b => b.PlaceRobber(It.IsAny<int>())).Returns(true).Verifiable();
            turnState.ReturnStateType = typeof(Trade);
            turnState.HandleInput(new PlayerAction(ActionType.Hex, 1));
        }

        [TestMethod]
        public void ShouldCallBank()
        {
            board.Verify();
            bank.Verify(b => b.TakeBackCardsOnSevenRoll(It.IsAny<ImmutableList<Player>>()));
        }
    }
}
