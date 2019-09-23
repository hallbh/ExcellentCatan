using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Controller.TurnMachines.Robber;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace Test.UnitTests.SpecFlowUnitTests.Controller.TurnMachines
{
    [Binding, Scope(Tag = "mock_player")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedParameter.Global")]
    public class GamePlaySteps
    {
        private readonly ScenarioContext context;

        public GamePlaySteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
            if (!context.TryGetValue(out MockRepository mocks))
            {
                mocks = new MockRepository(MockBehavior.Loose);
                context.Set(mocks);
            }

            if (!context.TryGetValue(out Mock<Random> _))
            {
                context.Set(mocks.Create<Random>());
            }

            if (!context.TryGetValue(out Mock<Bank> bank))
            {
                bank = mocks.Create<Bank>();
                context.Set(bank);
            }

            if (!context.TryGetValue(out Mock<GameBoard> board))
            {
                board = mocks.Create<GameBoard>();
                context.Set(board);
            }

            if (!context.TryGetValue(out List<Player> players))
            {
                players = new List<Player>();
                foreach (PlayerColor color in Enum.GetValues(typeof(PlayerColor)))
                {
                    var mockKey = color + "_mock";
                    if (!context.TryGetValue(mockKey, out Mock<Player> _))
                    {
                        var playerMock = context.Get<MockRepository>().Create<Player>(color);
                        context.Set(playerMock, mockKey);
                        players.Add(playerMock.Object);
                    }
                }
                context.Set(players);
            }

            if (!context.TryGetValue(out Mock<View> view))
            {
                view = mocks.Create<View>();
                context.Set(view);
            }

            if (!context.TryGetValue(out Mock<Presenter> presenter))
            {
                presenter = mocks.Create<Presenter>(view.Object);
                context.Set(presenter);
            }

            if (!context.TryGetValue(out GameModel _))
            {
                context.Set(new GameModel(board.Object, bank.Object, players, presenter.Object));
            }
            
            ItemContainer.Rnd = new Random();
        }

        [StepArgumentTransformation(@"""(.*)""")]
        public Mock<Player> ToPlayerMock(PlayerColor color)
        {
            var mockKey = color + "_mock";
            return context.Get<Mock<Player>>(mockKey);
        }

        [Given(@"(.*) doesn't own a harbor")]
        public void DoesntOwnHarbor(Mock<Player> player)
        {
            var board = context.Get<Mock<GameBoard>>();
            board.Setup(b => b.GetHarbor(It.IsAny<int>())).Returns(new Harbor(Item.Any, new List<Intersection>()));
        }


        [Given(@"(.*)( .* )afford a new (.*)")]
        public void GivenThePlayerCanAfford(Mock<Player> playerMock, bool can, Item item)
        {
            var player = playerMock.Object;
            if (context.TryGetValue(out Mock<Bank> bankMock))
            {
                bankMock.Setup(b => b.BuyItem(player, item)).Returns(can);
            }

            playerMock.Setup(m => m.CanTransfer(It.IsAny<ItemContainer>())).Returns(can);
            if (can)
            {
                playerMock.Setup(m => m.Transfer(It.IsAny<ItemContainer>(), It.IsAny<ItemContainer>()))
                    .Callback((ItemContainer amt, ItemContainer dst) =>
                    {
                        foreach (Item i in Enum.GetValues(typeof(Item)))
                        {
                            var newAmount = dst.GetAmount(i) + amt.GetAmount(i);
                            dst.UnsafeSetAmount(i, newAmount);
                        }
                    });
            }
        }

        [Given(@"(.*)( .* )place a development card")]
        public void GivenCanPlaceDev(Mock<Player> playerMock, bool can)
        { // Handles the case for development card to allow for usage of scenario outline
        }

        [Given(@"(.*)( .* )place a new (.*)")]
        public void GivenCanPlaceANew(Mock<Player> playerMock, bool can, Item item)
        {
            var player = playerMock.Object;
            var boardMock = context.Get<Mock<GameBoard>>();

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (item)
            {
                case Item.City:
                    boardMock.Setup(b => b.CanPlaceCitySomewhere(player)).Returns(can);
                    break;
                case Item.Road:
                    boardMock.Setup(b => b.CanPlaceRoadSomewhere(player)).Returns(can);
                    break;
                case Item.Settlement:
                    boardMock.Setup(b => b.CanPlaceSettlementSomewhere(player)).Returns(can);
                    break;
            }
        }


        [Given(@"(.*)( .* )afford a development card")]
        public void GivenThePlayerCanAfford(Mock<Player> playerMock, bool can)
        {
            playerMock.Setup(m => m.CanTransfer(It.IsAny<ItemContainer>())).Returns(can);
            if (can)
            {
                var bankMock = context.Get<Mock<Bank>>();
                bankMock.Setup(b => b.BuyDevCard(playerMock.Object)).Returns(true);
                playerMock.Setup(m => m.Transfer(It.IsAny<ItemContainer>(), It.IsAny<ItemContainer>()))
                    .Callback((ItemContainer amt, ItemContainer dst) =>
                    {
                        foreach (Item i in Enum.GetValues(typeof(Item)))
                        {
                            var newAmount = dst.GetAmount(i) + amt.GetAmount(i);
                            dst.UnsafeSetAmount(i, newAmount);
                        }
                    });
            }
        }

        [Given(@"(.*) is rich")]
        public void GivenRichPlayer(Mock<Player> player)
        {
            var playerResources = new List<Item>
            {
                Item.Brick, Item.Grain, Item.Lumber, Item.Ore, Item.Wool
            };
            foreach (var resource in playerResources)
            {
                player.Object.UnsafeSetAmount(resource, 19);
            }
        }

        [Given(@"the next two dice rolls will be (\d*) & (\d*)")]
        public void GivenTheNextDiceRollsWillBe(int first, int second)
        {
            if (first < 1 || first > 6 || second < 1 || second > 6)
            {
                throw new ArgumentException("These are 6 sided dice, value returned must be in range 1 to 6");
            }

            var currentState = context["CurrentState"];
            Assert.IsInstanceOfType(currentState, typeof(WaitRollDice));
            var rndMock = context.Get<Mock<Random>>();
            WaitRollDice.Rnd = rndMock.Object;
            rndMock.SetupSequence(r => r.Next(1, 7)).Returns(first).Returns(second);
            context.Get<Mock<Bank>>().Setup(b => b.SatisfyResourceRequests(It.IsAny<List<ResourceRequest>>()));
        }

        private void UpdateTurnState(ActionType actionType, int index = -1,Item value = Item.Any)
        {
            var action = new PlayerAction(actionType,index,value);
            var newState = context.Get<TurnState>("CurrentState").HandleInput(action);
            context["NewState"] = newState;
        }

        [Given(@"(.*) owns intersection (.*)")]
        public void GivenOwnsIntersection(Mock<Player> ownerMock, int intersectionIndex)
        {
            var board = context.Get<Mock<GameBoard>>();
            board.Setup(b => b.GetIntersection(0)).CallBase();
            board.Object.GetIntersection(0).SetOwner(ownerMock.Object);

            board.Setup(b => b.GetHarbor(0)).Returns(
                new Harbor(Item.Any, new List<Intersection> {board.Object.GetIntersection(0)}));
        }

        [Given(@"the bank is destitute")]
        public void GivenTheBankIsDestitute()
        {
            context.Get<Mock<Bank>>().Object.UnsafeSetAmount(Item.Lumber, 0);
            context.Get<Mock<Bank>>().Object.UnsafeSetAmount(Item.Brick, 0);
            context.Get<Mock<Bank>>().Object.UnsafeSetAmount(Item.Grain, 0);
            context.Get<Mock<Bank>>().Object.UnsafeSetAmount(Item.Ore, 0);
            context.Get<Mock<Bank>>().Object.UnsafeSetAmount(Item.Wool, 0);
        }

        [Given(@"(.*) is ready to (.*)")]
        [When(@"it is time for (.*) to (.*)")]
        public void WhenItIsTimeForThePlayerTo(Mock<Player> playerMock, string action)
        {
            var player = playerMock.Object;
            TurnState currentState;
            var model= context.Get<GameModel>();
            model.ActivePlayer = player;
            switch (action.Trim())
            {
                case "build":
                    currentState = new Build(model);
                    break;
                case "place a city":
                    currentState = new WaitCity(model);
                    break;
                case "place a settlement":
                    currentState = new WaitSettlement(model);
                    break;
                case "place a road":
                    currentState = new WaitRoad(model);
                    break;
                case "roll the dice":
                    currentState = new WaitRollDice(model);
                    break;
                case "trade":
                    currentState = new Trade(model);
                    break;
                case "doTrade":
                    currentState = new DoTrade(model);
                    break;
                case "rob people":
                    currentState = new MoveRobber(model)
                    {
                        ReturnStateType = typeof(Trade)
                    };
                    break;
                case "steal a resource":
                    var rob = new Rob(model)
                    {
                        ReturnStateType = typeof(Trade)
                    };
                    rob.SetSelectedHex(2);
                    currentState = rob;
                    break;
                default:
                    throw new ArgumentException("Unhandled case");
            }

            currentState.OnEnter();
            context["CurrentState"] = currentState;
            if (context.TryGetValue(out TurnManager manager))
            {
                manager.CurrentState = currentState;
            }
        }

        [When(@"(.*) selects a( .* )(.*)")]
        public void WhenThePlayerSelectsA(Mock<Player> playerMock, bool valid, string type)
        {
            var boardMock = context.Get<Mock<GameBoard>>();
            var player = playerMock.Object;
            ActionType actionType;
            switch (type.Trim())
            {
                case "settlement":
                    actionType = ActionType.Intersection;
                    boardMock.Setup(b => b.PlaceSettlement(player, It.IsAny<int>())).Returns(valid);
                    break;
                case "city":
                    actionType = ActionType.Intersection;
                    boardMock.Setup(b => b.PlaceCity(player, It.IsAny<int>())).Returns(valid);
                    break;
                case "road":
                    actionType = ActionType.Path;
                    boardMock.Setup(b => b.PlaceRoad(context.Get<GameModel>(), It.IsAny<int>())).Returns(valid);
                    break;
                case "hex":
                    actionType = ActionType.Hex;

                    boardMock.Setup(b => b.PlaceRobber(It.IsAny<int>())).Returns(valid);
                    break;
                default:
                    throw new ArgumentException("Unhandled type");
            }
            UpdateTurnState(actionType, 2);
        }

        [When(@"(.*) requests (.*)")]
        [When(@"(.*) (rolls the dice)")]
        [When(@"(.*) (makes a trade)")]
        public void WhenThePlayerRequests(Mock<Player> playerMock, string request)
        {
            ActionType actionType;
            switch (request.Trim())
            {
                case "to do basic trade":
                    actionType = ActionType.RequestTradeBasic;
                    break;
                case "to trade at a harbor":
                    actionType = ActionType.RequestTradeHarbor;
                    UpdateTurnState(actionType, 0);
                    return;
                case "to build":
                    actionType = ActionType.Build;
                    break;
                case "rolls the dice":
                    actionType = ActionType.RollDice;
                    context.TryGetValue(out Mock<GameBoard> board);
                    board.Setup(b => b.GetHex(It.IsAny<int>())).CallBase();
                    break;
                case "a new city":
                    actionType = ActionType.RequestCity;
                    break;
                case "a new settlement":
                    actionType = ActionType.RequestSettlement;
                    break;
                case "a new road":
                    actionType = ActionType.RequestRoad;
                    break;
                case "to end their turn":
                    actionType = ActionType.EndTurn;
                    break;
                case "a development card":
                    actionType = ActionType.RequestDevCard;
                    break;
                default:
                    throw new ArgumentException("Request type not handled");
            }
            UpdateTurnState(actionType);
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

        [Then(@"the game will display (.*)'s resources")]
        public void ThenTheGameWillDisplayThePlayersResources(Mock<Player> playerMock)
        {
            context.Get<Mock<Presenter>>().Verify(p => p.DisplayPlayerResources(playerMock.Object));
        }

        [Then(@"(.*)'s request for a new (.*) is handled")]
        public void ThenTheRequestIsHandled(Mock<Player> playerMock, Item item)
        {
            var bankMock = context.Get<Mock<Bank>>();
            var player = playerMock.Object;
            bankMock.Verify(b => b.BuyItem(player, item));
        }

        [Then(@"(.*)'s request for a development card is handled")]
        public void ThenTheRequestIsHandledDevCard(Mock<Player> playerMock)
        {
            var bankMock = context.Get<Mock<Bank>>();
            var player = playerMock.Object;
            bankMock.Verify(b => b.BuyDevCard(player));
        }

        [Then(@"the game is waiting for (.*) to (.*)")]
        public void ThenTheGameIsWaitingForThePlayerTo(Mock<Player> _, string newState)
        {
            Type type;
            switch (newState.Trim())
            {
                case "build":
                    type = typeof(Build);
                    break;
                case "select a city":
                    type = typeof(WaitCity);
                    break;
                case "select a settlement":
                    type = typeof(WaitSettlement);
                    break;
                case "select a road":
                    type = typeof(WaitRoad);
                    break;
                case "trade":
                    type = typeof(Trade);
                    break;
                case "do trade":
                    type = typeof(DoTrade);
                    break;
                case "roll the dice":
                    type = typeof(WaitRollDice);
                    break;
                case "rob people":
                    type = typeof(MoveRobber);
                    break;
                case "steal a resource":
                    type = typeof(Rob);
                    break;
                default:
                    throw new ArgumentException("Unhandled case");
            }

            Assert.IsInstanceOfType(context["NewState"], type);
        }

        [Then(@"it is (.*)'s turn")]
        public void ThenItIsTheNextPlayersTurn(Mock<Player> playerMock)
        {
            var model = context.Get<GameModel>();
            Assert.AreSame(playerMock.Object, model.ActivePlayer);
        }


        [Then(@"the Robber moved to the new location")]
        public void ThenTheRobberMovedToTheNewLocation()
        {
            context.Get<Mock<Presenter>>().Verify(p => p.SetRobberPosition(It.IsAny<int>()));
        }

        [Given(@"(.*)( .* )own an adjacent settlement")]
        public void GivenOwnsAnAdjacentSettlement(Mock<Player> playerMock, bool does)
        {
            var player = playerMock.Object;
            context.TryGetValue(out MockRepository mocks);

            var intersection = mocks.Create<Intersection>();
            intersection.Setup(i => i.GetOwner()).Returns(player);
            var index = does ? 12 : 23;
            var list = new List<Intersection>();
            if (does)
            {
                list.Add(intersection.Object);
            }
            var hex = mocks.Create<Hex>(list, Item.Desert, 1);
            context.TryGetValue(out Mock<GameBoard> board);
            board.Setup(b => b.GetHex(2)).Returns(hex.Object);
            board.Setup(b => b.GetIntersection(index)).Returns(intersection.Object);
        }

        [Given(@"(.*) has (\d*) (.*)")]
        public void GivenHasItem(Mock<Player> playerMock, int num, Item resourceCard)
        {
            playerMock.Object.UnsafeSetAmount(resourceCard, num);
        }

        
        [When(@"(.*) selects an empty intersection")]
        public void WhenSelectsAnEmptyIntersection(Mock<Player> playerMock)
        {
            context.TryGetValue(out MockRepository mocks);
            var intersection = mocks.Create<Intersection>();
            intersection.Setup(i => i.GetOwner()).Returns((Player) null);
            
            context.TryGetValue(out Mock<GameBoard> board);

            board.Setup(b => b.GetHex(It.IsAny<int>())).Returns(mocks.Create<Hex>(new List<Intersection>(),Item.Desert, 0).Object);
            board.Setup(b => b.GetIntersection(12)).Returns(intersection.Object);

            UpdateTurnState(ActionType.Intersection,12);
        }

        [When(@"(.*) selects (.*)'s non-adjacent settlement")]
        public void WhenSelectsSNonAdjacentSettlement(Mock<Player> player1Mock, Mock<Player> player2Mock)
        {
            UpdateTurnState(ActionType.Intersection, 23);
        }

        [When(@"(.*) selects (.*)'s adjacent settlement")]
        public void WhenSelectsSSettlement(Mock<Player> player1Mock, Mock<Player> player2Mock)
        {
            UpdateTurnState(ActionType.Intersection,12);
        }

        [Then(@"(.*) takes (.*) (.*) from (.*)")]
        public void ThenTakesARandomResourceCardFrom(Mock<Player> player1Mock, int num, Item resourceCard, Mock<Player> player2Mock)
        {
            player2Mock.Verify(p => p.Transfer(It.Is<ItemContainer>(i => i.GetAmount(resourceCard) == num), player1Mock.Object));
        }

        [Given(@"(.*) has played a (.*)")]
        public void GivenHasPlayedItem(Mock<Player> playerMock, Item item)
        {
            context.TryGetValue(out GameModel model);
            var manager = new TurnManager(model);
            context.Set(manager);
            model.ActivePlayer = playerMock.Object;
            manager.HandleDevCard(new PlayerAction(ActionType.PlayDevCard, value: item));
        }

        [When(@"(.*) attempts to play a (.*)")]
        public void WhenAttemptsToPlayAKnightCard(Mock<Player> playerMock, Item item)
        {
            var manager = context.Get<TurnManager>();
            manager.HandleDevCard(new PlayerAction(ActionType.PlayDevCard, value: item));
            context["NewState"] = manager.CurrentState;
        }

        [Then(@"the error prompt is cleared")]
        public void ErrorPromptClear()
        {
            context.Get<Mock<Presenter>>().Verify(p => p.PromptError(@""));
        }


    }
}
