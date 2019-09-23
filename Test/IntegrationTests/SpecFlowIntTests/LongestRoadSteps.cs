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
    [Binding,Scope(Tag="longestRoad")]
    public class LongestRoadSteps
    {
        private readonly ScenarioContext context;

        public LongestRoadSteps(ScenarioContext injectedContext)
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


            if (!context.TryGetValue(out Presenter presenter))
            {
                presenter = context.Get<MockRepository>().Create<Presenter>(Mock.Of<View>()).Object;
                context.Set(presenter);
            }

            if (!context.TryGetValue(out GameModel model))
            {
                model = new GameModel(context.Get<GameBoard>(),
                                      context.Get<Bank>(),
                                      context.Get<List<Player>>(),
                                      context.Get<Presenter>());
                context.Set(model);
            }

            if (!context.TryGetValue(out TurnManager manager))
            {
                manager = new TurnManager(context.Get<GameModel>());
                context.Set(manager);
            }

        }

        [Given(@"(.*) is ready to build")]
        public void ReadyToBuild(Player player)
        {
            var model = context.Get<GameModel>();
            var currentState = new Build(model);
            context.Get<TurnManager>().CurrentState = currentState;
        }

        [Given(@"(.*) owns path (.*)")]
        public void GivenOwnsPath(Player player, int pathIndex)
        {
            var board = context.Get<GameBoard>();
            board.GetPath(pathIndex).SetOwner(player);
        }

        [Given(@"the Longest Road is (.*) paths long")]
        public void GivenTheLongestRoadIsPathsLong(int numPaths)
        {
            var model = context.Get<GameModel>();
            model.LongestRoadLength = numPaths;
        }


        [Given(@"(.*) owns intersection (.*)")]
        public void GivenOwnsIntersection(Player player, int intersectionIndex)
        {
            var board = context.Get<GameBoard>();
            board.GetIntersection(intersectionIndex).SetOwner(player);
        }


        [Given(@"(.*) has (.*) (.*)")]
        public void GivenHasLumber(Player player, int amount, Item resource)
        {
            player.UnsafeSetAmount(resource, amount);
        }
        
        [Given(@"(.*)( .* )own the Longest Road")]
        public void GivenDoesnTOwnTheLongestRoad(Player player, bool does)
        {
            if (does)
            {
                context.Get<Bank>().Transfer(new ItemContainer(
                    new Dictionary<Item, int> {{Item.LongestRoadCard, 1}}), player);
            }
        }
        
        [When(@"(.*) builds a road on path (.*)")]
        public void WhenBlueBuildsARoadOnPath(Player player, int pathIndex)
        {
            context.Get<TurnManager>().HandleAction(new PlayerAction(ActionType.RequestRoad));
            context.Get<TurnManager>().HandleAction(new PlayerAction(ActionType.Path, pathIndex));
        }

        [When(@"(.*) builds a settlement on intersection (.*)")]
        public void WhenBuildsASettlementOnIntersection(Player player, int intersectionIndex)
        {
            context.Get<TurnManager>().HandleAction(new PlayerAction(ActionType.RequestSettlement));
            context.Get<TurnManager>().HandleAction(new PlayerAction(ActionType.Intersection, intersectionIndex));
        }


        [Then(@"(.*)( .* )own the Longest Road")]
        public void ThenBlueDoesOwnTheLongestRoad(Player player, bool does)
        {
            Assert.AreEqual(does, player.HasLongestRoad);
        }

        [Then(@"The road is (.*) paths long from path (.*)")]
        public void ThenTheLongestRoadIsPathsLong(int length, int pathIndex)
        {
            var board = context.Get<GameBoard>();
            Assert.AreEqual(length, context.Get<GameBoard>().GetLengthOfRoad(board.GetPath(pathIndex)));
        }

    }
}
