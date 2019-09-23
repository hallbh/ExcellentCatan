using System;
using System.Collections.Generic;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

namespace Test.IntegrationTests.SpecFlowIntTests
{
    [Binding,Scope(Tag="integration")]
    public class LargestArmySteps
    {
        private readonly ScenarioContext context;
       
        public LargestArmySteps(ScenarioContext injectedContext)
        {
            context = injectedContext;

            if (!context.TryGetValue(out MockRepository mocks))
            {
                mocks = new MockRepository(MockBehavior.Loose);
                context.Set(mocks);
            }

            if (!context.TryGetValue(out GameBoard board))
            {
                board = new GameBoard();
                context.Set(board);
            }

            if (!context.TryGetValue(out Bank bank))
            {
                bank = new Bank();
                context.Set(bank);
            }

            if (!context.TryGetValue(out List<Player> players))
            {
                players = new List<Player>();
                foreach (PlayerColor color in Enum.GetValues(typeof(PlayerColor)))
                {
                    var key = color;
                    if (!context.TryGetValue(key.ToString(), out Player player))
                    {
                        player = new Player(key);
                        context.Set(player, key.ToString());
                    }
                    players.Add(player);
                }
                context.Set(players);
            }


            if (!context.TryGetValue(out Mock<Presenter> presenter))
            {
                presenter = mocks.Create<Presenter>(Mock.Of<View>());
                context.Set(presenter);
            }

            if (!context.TryGetValue(out GameModel model))
            {
                model = new GameModel(board, bank, players, presenter.Object);
                context.Set(model);
            }

            if (!context.TryGetValue(out TurnManager manager))
            {
                manager = new TurnManager(model);
                context.Set(manager);
            }
        }

        [Given(@"(.*) is ready to (.*)")]
        [When(@"it is time for (.*) to (.*)")]
        public void WhenItIsTimeForThePlayerTo(Player player, string action)
        {
            TurnState currentState;
            var model = context.Get<GameModel>();
            model.ActivePlayer = player;
            switch (action.Trim())
            {
                case "build":
                    currentState = new Build(model);
                    break;
                case "trade":
                    currentState = new Trade(model);
                    break;
                default:
                    throw new ArgumentException("Unhandled case");
            }

            context.Get<TurnManager>().CurrentState = currentState;
        }

        [Given(@"(.*) has the largest army")]
        public void GivenHasLargestArmy(Player p)
        {
            var bank = context.Get<Bank>();
            bank.Transfer(new ItemContainer(
                new Dictionary<Item, int> {{Item.LargestArmyCard, 1}}),
                p);
        }

        [Given(@"(.*) has played (.*) knight[s]?")]
        public void GivenHasPlayedKnights(Player p, int amount)
        {
            p.DiscardPile.UnsafeSetAmount(Item.KnightCard, amount);
        }

        [Given(@"(.*) has (.*) knight card[s]?")]
        public void GivenHasKnightCard(Player p, int amount)
        {
            p.UnsafeSetAmount(Item.KnightCard, amount);
            context.TryGetValue(out GameModel model);
            model.ActivePlayerIndex = 0;
        }


        [When(@"(.*) plays a knight")]
        public void WhenPlaysAKnight(Player p)
        {
            var manager = context.Get<TurnManager>();
            manager.HandleAction(
                new PlayerAction(ActionType.PlayDevCard, 0, Item.KnightCard));
        }

        [Then(@"The bank( .* )have the largest army")]
        public void BankLargestArmy(bool has)
        {
            var bank = context.Get<Bank>();
            var actual = bank.GetAmount(Item.LargestArmyCard) == 1;
            Assert.AreEqual(has, actual);
        }

        [Then(@"(.*)( .* )have largest army")]
        public void PlayerLargestArmy(Player p, bool has)
        {
            Assert.AreEqual(has, p.HasLargestArmy);
        }

        [Then(@"(.*) has played (.*) knight[s]?")]
        public void ThenHasPlayedKnight(Player p, int amount)
        {
            Assert.AreEqual(amount, p.DiscardPile.GetAmount(Item.KnightCard));
        }

        [Then(@"the game will display error message ""(.*)""")]
        public void ThenDisplayError(string message)
        {
            context.Get<Mock<Presenter>>().Verify(p => p.PromptError(message));
        }

        [Then(@"(.*) will be prompted to ""(.*)""")]
        public void ThenPlayerWillBePromptedTo(Mock<Player> playerMock, string message)
        {
            context.Get<Mock<Presenter>>().Verify(p => p.PromptUser(playerMock.Object, message));
        }
    }
}
