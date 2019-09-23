using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
// ReSharper disable UnusedParameter.Global

namespace Test.UnitTests.SpecFlowUnitTests.Model
{
    [Binding, Scope(Tag = "real_player")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class VictorySteps
    {
        private readonly ScenarioContext context;

        public VictorySteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
        
        [StepArgumentTransformation(@"""(.*)""")]
        public Player ToPlayer(PlayerColor color)
        {
            if (!context.ContainsKey(color.ToString()))
            {
                context.Set(new Player(color), color.ToString());
            }

            return context.Get<Player>(color.ToString());
        }


        [Given(@"(.*) is rich")]
        public void GivenRichPlayer(Player player)
        {
            var playerResources = new List<Item>
            {
                Item.Brick, Item.Grain, Item.Lumber, Item.Ore, Item.Wool
            };
            foreach (var resource in playerResources)
            {
                player.UnsafeSetAmount(resource, 19);
            }
        }

        [Given(@"(.*) has (\d*) (.*)s")]
        public void GivenPlayerHas(Player player, int count,Item type)
        {
            player.UnsafeSetAmount(type, count);
        }
        
        [When(@"it is (.*)'s turn")]
        public void WhenItIsPlayersTurn(Player player)
        {
        }

        [Then(@"(.*) has \s*(\d*)\s* victory points")]
        public void ThenPlayerHasVictoryPoints(Player player, int expectedPoints)
        {
            Assert.AreEqual(expectedPoints, player.VictoryPoints);
        }
    }
}
