using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Model
{
    [TestClass]
    public class BankUnitTest
    {
        private readonly Bank bank = new Bank();
        private readonly Mock<Player> playerMock = new Mock<Player>(PlayerColor.Blue);

        [TestInitialize]
        public void SetupTest()
        {
            ItemContainer.Rnd = new Random();
        }

        private void SetupMock(bool canAfford)
        {
            playerMock.Setup(p => p.CanTransfer(It.IsAny<ItemContainer>())).Returns(canAfford);
            playerMock.Setup(m => m.Transfer(It.IsAny<ItemContainer>(), It.IsAny<ItemContainer>()))
                .Callback((ItemContainer amt, ItemContainer dst) =>
                {
                    foreach (Item item in Enum.GetValues(typeof(Item)))
                    {
                        var newAmount = dst.GetAmount(item) + amt.GetAmount(item);
                        dst.UnsafeSetAmount(item, newAmount);
                    }
                });
        }

        [TestMethod]
        public void BuyCitySuccess()
        {
            SetupMock(true);

            var result = bank.BuyItem(playerMock.Object, Item.City);

            Assert.IsTrue(result);
            Assert.AreEqual(19, bank.GetAmount(Item.Lumber));
            Assert.AreEqual(22, bank.GetAmount(Item.Ore));
            Assert.AreEqual(19, bank.GetAmount(Item.Wool));
            Assert.AreEqual(19, bank.GetAmount(Item.Brick));
            Assert.AreEqual(21, bank.GetAmount(Item.Grain));
        }

        [TestMethod]
        public void BuyCityFailure()
        {
            SetupMock(false);

            var result = bank.BuyItem(playerMock.Object, Item.City);

            Assert.IsFalse(result);
            Assert.AreEqual(19, bank.GetAmount(Item.Lumber));
            Assert.AreEqual(19, bank.GetAmount(Item.Ore));
            Assert.AreEqual(19, bank.GetAmount(Item.Wool));
            Assert.AreEqual(19, bank.GetAmount(Item.Brick));
            Assert.AreEqual(19, bank.GetAmount(Item.Grain));
        }

        [TestMethod]
        public void BuySettlementSuccess()
        {
            SetupMock(true);

            var result = bank.BuyItem(playerMock.Object, Item.Settlement);

            Assert.IsTrue(result);
            Assert.AreEqual(20, bank.GetAmount(Item.Lumber));
            Assert.AreEqual(19, bank.GetAmount(Item.Ore));
            Assert.AreEqual(20, bank.GetAmount(Item.Wool));
            Assert.AreEqual(20, bank.GetAmount(Item.Brick));
            Assert.AreEqual(20, bank.GetAmount(Item.Grain));
        }

        [TestMethod]
        public void BuySettlementFailure()
        {
            SetupMock(false);

            var result = bank.BuyItem(playerMock.Object, Item.Settlement);

            Assert.IsFalse(result);
            Assert.AreEqual(19, bank.GetAmount(Item.Lumber));
            Assert.AreEqual(19, bank.GetAmount(Item.Ore));
            Assert.AreEqual(19, bank.GetAmount(Item.Wool));
            Assert.AreEqual(19, bank.GetAmount(Item.Brick));
            Assert.AreEqual(19, bank.GetAmount(Item.Grain));
        }


        [TestMethod]
        public void BuyRoadSuccess()
        {
            SetupMock(true);

            var result = bank.BuyItem(playerMock.Object, Item.Road);

            Assert.IsTrue(result);
            Assert.AreEqual(20, bank.GetAmount(Item.Lumber));
            Assert.AreEqual(19, bank.GetAmount(Item.Ore));
            Assert.AreEqual(19, bank.GetAmount(Item.Wool));
            Assert.AreEqual(20, bank.GetAmount(Item.Brick));
            Assert.AreEqual(19, bank.GetAmount(Item.Grain));
        }

        [TestMethod]
        public void BuyRoadFailure()
        {
            SetupMock(false);

            var result = bank.BuyItem(playerMock.Object, Item.Road);

            Assert.IsFalse(result);
            Assert.AreEqual(19, bank.GetAmount(Item.Lumber));
            Assert.AreEqual(19, bank.GetAmount(Item.Ore));
            Assert.AreEqual(19, bank.GetAmount(Item.Wool));
            Assert.AreEqual(19, bank.GetAmount(Item.Brick));
            Assert.AreEqual(19, bank.GetAmount(Item.Grain));
        }

        [TestMethod]
        public void RoadResources()
        {
            var container = Bank.CostOf(Item.Road);

            Assert.AreEqual(-1, container.GetAmount(Item.Road));
            Assert.AreEqual(1, container.GetAmount(Item.Brick));
            Assert.AreEqual(1, container.GetAmount(Item.Lumber));
        }

        [TestMethod]
        public void SettlementResources()
        {
            var container = Bank.CostOf(Item.Settlement);

            Assert.AreEqual(-1, container.GetAmount(Item.Settlement));
            Assert.AreEqual(1, container.GetAmount(Item.Brick));
            Assert.AreEqual(1, container.GetAmount(Item.Lumber));
            Assert.AreEqual(1, container.GetAmount(Item.Grain));
            Assert.AreEqual(1, container.GetAmount(Item.Wool));
        }

        [TestMethod]
        public void CityResources()
        {
            var container = Bank.CostOf(Item.City);
            
            Assert.AreEqual(-1, container.GetAmount(Item.City));
            Assert.AreEqual(1, container.GetAmount(Item.Settlement));
            Assert.AreEqual(2, container.GetAmount(Item.Grain));
            Assert.AreEqual(3, container.GetAmount(Item.Ore));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Should error on unhandled cases")]
        public void InvalidCostOf()
        {
            var container = Bank.CostOf(Item.Desert);
            container.UnsafeSetAmount(Item.Brick, 1);
        }
        
        [TestMethod]
        public void SatisfyResourceRequests()
        {
            playerMock.Setup(p => p.CanReceive(It.IsAny<ItemContainer>())).Returns(true);
            var request = new ResourceRequest(playerMock.Object, Item.Lumber, 1);
            var requests = new List<ResourceRequest> {request};

            bank.SatisfyResourceRequests(requests);

            Assert.AreEqual(1, playerMock.Object.GetAmount(Item.Lumber));
            Assert.AreEqual(18, bank.GetAmount(Item.Lumber));
        }

        private int RobPlayerWithXResources(int numOre, int numBrick) {
            SetupMock(true);
            var stolenCount = 0;
            playerMock.Object.UnsafeSetAmount(Item.Ore, numOre);
            playerMock.Object.UnsafeSetAmount(Item.Brick, numBrick);
            if (numOre + numBrick > 7)
            {
                playerMock.Setup(p => p.Transfer(It.IsAny<ItemContainer>(), bank))
                    .Callback((ItemContainer amt, ItemContainer dest) =>
                    {
                        foreach (var item in amt.GetMatchingItems(ItemHelper.ResourceCards))
                        {
                            if (item.Value == 0)
                            {
                                continue;
                            }

                            Assert.IsTrue(item.Key == Item.Ore || item.Key == Item.Brick);
                            var newAmt = dest.GetAmount(item.Key) + item.Value;
                            stolenCount += item.Value;
                            dest.UnsafeSetAmount(item.Key, newAmt);
                        }
                    });
            }
            var players = ImmutableList.Create(playerMock.Object);
            bank.TakeBackCardsOnSevenRoll(players);
            return stolenCount;
        }
        
        [TestMethod]
        public void RobPlayerWith7Resources()
        {
            var stolenCount = RobPlayerWithXResources(7, 0);
            Assert.AreEqual(0, stolenCount);
        }

        [TestMethod]
        public void RobPlayerWith8Resources()
        {
            var stolenCount = RobPlayerWithXResources(4, 4);
            Assert.AreEqual(4, stolenCount);
        }

        [TestMethod]
        public void RobPlayerWith9ResourcesRoundsDown()
        {
            var stolenCount = RobPlayerWithXResources(4, 5);
            Assert.AreEqual(4, stolenCount);
        }
    }
}
