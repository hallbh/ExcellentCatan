using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace Test.UnitTests.SpecFlowUnitTests.Model
{
    [Binding,Scope(Tag="mock_player")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedParameter.Global")]
    public sealed class BankSteps
    {
        private readonly ScenarioContext context;

        public BankSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
            if (!context.ContainsKey("ResourceRequest"))
            {
                context.Set(new List<ResourceRequest>());

            }
        }

        [Given(@"(.*)( .* )afford a new Development Card")]
        public void GivenThePlayerCanAfford(Mock<Player> playerMock, bool can)
        {
            playerMock.Setup(m => m.CanTransfer(It.IsAny<ItemContainer>())).Returns(can);
            if (can)
            {
                playerMock.Setup(m => m.Transfer(It.IsAny<ItemContainer>(), It.IsAny<ItemContainer>()))
                    .Callback((ItemContainer amt, ItemContainer dst) =>
                    {
                        foreach (Item i in Enum.GetValues(typeof(Item)))
                        {
                            var newAmount = dst.GetAmount(i) + amt.GetAmount(i);
                            dst.UnsafeSetAmount(i,newAmount);
                        }
                    });
            }
        }
        
        [Given(@"the bank has (.*) (.*)")]
        public void GivenTheBankHas(int num, Item resource)
        {
            context.Get<Bank>().UnsafeSetAmount(resource, num);
        }

        [Given(@"the bank has been setup")]
        [When(@"the bank has just been setup")]
        public void WhenTheBankHasJustBeenSetup()
        {
            context.Set(new Bank());
        }
        

        [When(@"(.*) asks the bank for a new (.*)")]
        public void WhenAsksTheBankForA(Mock<Player> playerMock, Item thing)
        {
            var bank = context.Get<Bank>();
            var player = playerMock.Object;
            var result =bank.BuyItem(player, thing);
            context.Set(result, "bankOutcome");
        }

        [When(@"(.*) asks the bank for a new Development Card")]
        public void WhenAsksTheBankForA(Mock<Player> playerMock)
        {
            ItemContainer.Rnd = new Random();
            var bank = context.Get<Bank>();
            var player = playerMock.Object;
            var result = bank.BuyDevCard(player);
            context.Set(result, "bankOutcome");
        }

        [Then(@"the bank should have (.*) ([^\s]*)\s*")]
        public void ThenTheBankHas(int count, Item resource)
        {
            Assert.AreEqual(count, context.Get<Bank>().GetAmount(resource));
        }
        
        [Then(@"(.*)( .* )take a (.*) from the bank")]
        public void ThenGetsA(Mock<Player> playerMock, bool gets, string thing)
        {
            Assert.AreEqual(gets,context.Get<bool>( "bankOutcome"));
        }

        [Given(@"player (.*) produced (.*) (.*)")]
        public void ProduceItem(Mock<Player> playerMock, int amount, Item resource)
        {
            playerMock.Setup(m => m.CanReceive(It.IsAny<ItemContainer>())).Returns(true);
            context.Get<List<ResourceRequest>>().Add(new ResourceRequest(playerMock.Object, resource, amount));
        }
        
        [When(@"the players get resources from the bank")]
        public void WhenThePlayersGetResourcesFromTheBank()
        {
            foreach (var player in context.Get<List<Player>>())
            {
                Mock.Get(player).Setup(p => p.CanReceive(It.IsAny<ItemContainer>())).Returns(true);
            }
            context.Get<Bank>().SatisfyResourceRequests(context.Get<List<ResourceRequest>>());
        }
        
        [Then(@"(.*) receives (.*) (.*)")]
        public void ThenPlayerReceivesItem(Mock<Player> playerMock, int amount, Item resource)
        {
            Assert.AreEqual(amount,playerMock.Object.GetAmount(resource));
        }
    }
}
