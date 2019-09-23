using System.Collections.Generic;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

// ReSharper disable InconsistentNaming

namespace Test.UnitTests.Model
{
    [TestClass]
    public class PlayerUnitTest
    {
        private readonly Player p = new Player(PlayerColor.White);
        private readonly Mock<Bank> bankMock = new Mock<Bank>(MockBehavior.Loose);

        [TestInitialize]
        public void SetupTest()
        {
            bankMock.Setup(b => b.CanTransfer(It.IsAny<ItemContainer>())).Returns(true);
            bankMock.Setup(b => b.CanReceive(It.IsAny<ItemContainer>())).Returns(true);
        }

        [TestMethod]
        public void GetNumberOfVictoryPoints()
        {
            Assert.AreEqual(2, p.VictoryPoints);
        }

        [TestMethod]
        public void GetPlayerName()
        {
            Assert.AreEqual(PlayerColor.White, p.Color);
        }

        [TestMethod]
        public void InitialResources()
        {
            Item[] resources = {Item.Lumber, Item.Brick, Item.Grain, Item.Ore, Item.Wool};
            foreach (var resource in resources)
            {
                Assert.AreEqual(0, p.GetAmount(resource), $"Resource {resource} should be zero");
            }
        }

        [TestMethod]
        public void BuyCitySuccess()
        {
            p.UnsafeSetAmount(Item.Grain, 2);
            p.UnsafeSetAmount(Item.Ore, 3);
            p.Transfer(Bank.CostOf(Item.City), bankMock.Object);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.City))); 
            Assert.AreEqual(1, p.GetAmount(Item.City));
        }

        [TestMethod]
        public void BuyCitySuccessWithLeftoverGrain()
        {
            // Checks Side Effect to kill mutants
            p.UnsafeSetAmount(Item.Grain, 4);
            p.UnsafeSetAmount(Item.Ore, 3);
            p.Transfer(Bank.CostOf(Item.City), bankMock.Object);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.City))); 
            Assert.AreEqual(1, p.GetAmount(Item.City));
        }

        [TestMethod]
        public void BuyCitySuccessWithLeftoverOre()
        {
            // Checks Side Effect to kill mutants
            p.UnsafeSetAmount(Item.Grain, 2);
            p.UnsafeSetAmount(Item.Ore, 6);
            p.Transfer(Bank.CostOf(Item.City), bankMock.Object);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.City))); 
            Assert.AreEqual(1, p.GetAmount(Item.City));
        }


        [TestMethod]
        public void BuyCityFailureByOre()
        {
            p.UnsafeSetAmount(Item.Grain, 2);
            p.UnsafeSetAmount(Item.Ore, 2);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.City)));
        }

        [TestMethod]
        public void BuyCityFailureByGrain()
        {
            p.UnsafeSetAmount(Item.Grain, 1);
            p.UnsafeSetAmount(Item.Ore, 3);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.City)));
        }


        [TestMethod]
        public void BuyCityFailureByCount()
        {
            p.UnsafeSetAmount(Item.Grain, 20);
            p.UnsafeSetAmount(Item.Ore, 20);
            p.UnsafeSetAmount(Item.Settlement, 5);
            p.Transfer(Bank.CostOf(Item.City), bankMock.Object);
            Assert.AreEqual(1, p.GetAmount(Item.City));
            p.Transfer(Bank.CostOf(Item.City), bankMock.Object);
            Assert.AreEqual(2, p.GetAmount(Item.City));
            p.Transfer(Bank.CostOf(Item.City), bankMock.Object);
            Assert.AreEqual(3, p.GetAmount(Item.City));
            p.Transfer(Bank.CostOf(Item.City), bankMock.Object);
            Assert.AreEqual(4, p.GetAmount(Item.City));
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.City)));
        }

        [TestMethod]
        public void BuySettlementSuccess()
        {
            p.UnsafeSetAmount(Item.Brick, 1);
            p.UnsafeSetAmount(Item.Lumber, 1);
            p.UnsafeSetAmount(Item.Grain, 1);
            p.UnsafeSetAmount(Item.Wool, 1);
            p.Transfer(Bank.CostOf(Item.Settlement), bankMock.Object);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Settlement))); 
            Assert.AreEqual(3, p.GetAmount(Item.Settlement));
        }

        [TestMethod]
        public void BuySettlementSideEffectBrick()
        {
            p.UnsafeSetAmount(Item.Brick, 1);
            p.UnsafeSetAmount(Item.Lumber, 2);
            p.UnsafeSetAmount(Item.Grain, 2);
            p.UnsafeSetAmount(Item.Wool, 2);
            p.Transfer(Bank.CostOf(Item.Settlement), bankMock.Object);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Settlement))); 
            Assert.AreEqual(3, p.GetAmount(Item.Settlement));
        }

        [TestMethod]
        public void BuySettlementSideEffectLumber()
        {
            p.UnsafeSetAmount(Item.Brick, 2);
            p.UnsafeSetAmount(Item.Lumber, 1);
            p.UnsafeSetAmount(Item.Grain, 2);
            p.UnsafeSetAmount(Item.Wool, 2);
            p.Transfer(Bank.CostOf(Item.Settlement), bankMock.Object);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Settlement))); 
            Assert.AreEqual(3, p.GetAmount(Item.Settlement));
        }

        [TestMethod]
        public void BuySettlementSideEffectGrain()
        {
            p.UnsafeSetAmount(Item.Brick, 2);
            p.UnsafeSetAmount(Item.Lumber, 2);
            p.UnsafeSetAmount(Item.Grain, 1);
            p.UnsafeSetAmount(Item.Wool, 2);
            p.Transfer(Bank.CostOf(Item.Settlement), bankMock.Object);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Settlement))); 
            Assert.AreEqual(3, p.GetAmount(Item.Settlement));
        }

        [TestMethod]
        public void BuySettlementSideEffectWool()
        {
            p.UnsafeSetAmount(Item.Brick, 2);
            p.UnsafeSetAmount(Item.Lumber, 2);
            p.UnsafeSetAmount(Item.Grain, 2);
            p.UnsafeSetAmount(Item.Wool, 1);
            p.Transfer(Bank.CostOf(Item.Settlement), bankMock.Object);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Settlement))); 
            Assert.AreEqual(3, p.GetAmount(Item.Settlement));
        }

        [TestMethod]
        public void BuySettlementFailureByBrick()
        {
            p.UnsafeSetAmount(Item.Lumber, 1);
            p.UnsafeSetAmount(Item.Grain, 1);
            p.UnsafeSetAmount(Item.Wool, 1);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Settlement)));
            Assert.AreEqual(2, p.GetAmount(Item.Settlement));
        }

        [TestMethod]
        public void BuySettlementFailureByLumber()
        {
            p.UnsafeSetAmount(Item.Brick, 1);
            p.UnsafeSetAmount(Item.Grain, 1);
            p.UnsafeSetAmount(Item.Wool, 1);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Settlement)));
            Assert.AreEqual(2, p.GetAmount(Item.Settlement));
        }

        [TestMethod]
        public void BuySettlementFailureByGrain()
        {
            p.UnsafeSetAmount(Item.Brick, 1);
            p.UnsafeSetAmount(Item.Lumber, 1);
            p.UnsafeSetAmount(Item.Wool, 1);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Settlement)));
            Assert.AreEqual(2, p.GetAmount(Item.Settlement));
        }

        [TestMethod]
        public void BuySettlementFailureByWool()
        {
            p.UnsafeSetAmount(Item.Brick, 1);
            p.UnsafeSetAmount(Item.Lumber, 1);
            p.UnsafeSetAmount(Item.Grain, 1);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Settlement)));
            Assert.AreEqual(2, p.GetAmount(Item.Settlement));
        }

        [TestMethod]
        public void BuySettlementFailureByCount()
        {
            p.UnsafeSetAmount(Item.Brick, 6);
            p.UnsafeSetAmount(Item.Lumber, 6);
            p.UnsafeSetAmount(Item.Grain, 6);
            p.UnsafeSetAmount(Item.Wool, 6);
            p.Transfer(Bank.CostOf(Item.Settlement), bankMock.Object);
            p.Transfer(Bank.CostOf(Item.Settlement), bankMock.Object);
            p.Transfer(Bank.CostOf(Item.Settlement), bankMock.Object);
            Assert.AreEqual(5, p.GetAmount(Item.Settlement));
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Settlement)));
            Assert.AreEqual(5, p.GetAmount(Item.Settlement));
        }

        [TestMethod]
        public void BuyRoadSuccess()
        {
            p.UnsafeSetAmount(Item.Brick, 1);
            p.UnsafeSetAmount(Item.Lumber, 1);
            p.Transfer(Bank.CostOf(Item.Road), bankMock.Object);
            Assert.AreEqual(0, p.GetAmount(Item.Brick));
            Assert.AreEqual(0, p.GetAmount(Item.Lumber));
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Road)));
            Assert.AreEqual(3, p.GetAmount(Item.Road));
        }

        [TestMethod]
        public void BuyRoadSuccessExtraBrick()
        {
            p.UnsafeSetAmount(Item.Brick, 2);
            p.UnsafeSetAmount(Item.Lumber, 1);
            p.Transfer(Bank.CostOf(Item.Road), bankMock.Object);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Road))); 
            Assert.AreEqual(3, p.GetAmount(Item.Road));
        }

        [TestMethod]
        public void BuyRoadSuccessExtraLumber()
        {
            p.UnsafeSetAmount(Item.Brick, 1);
            p.UnsafeSetAmount(Item.Lumber, 2);
            p.Transfer(Bank.CostOf(Item.Road), bankMock.Object);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Road)));
            Assert.AreEqual(3, p.GetAmount(Item.Road));
        }

        [TestMethod]
        public void BuyRoadFailureByBrick()
        {
            p.UnsafeSetAmount(Item.Lumber, 1);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Road)));
            Assert.AreEqual(2, p.GetAmount(Item.Road));
        }

        [TestMethod]
        public void BuyRoadFailureByLumber()
        {
            p.UnsafeSetAmount(Item.Brick, 1);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Road)));
            Assert.AreEqual(2, p.GetAmount(Item.Road));
        }

        [TestMethod]
        public void BuyRoadFailureByCount()
        {
            p.UnsafeSetAmount(Item.Brick, 14);
            p.UnsafeSetAmount(Item.Lumber, 14);
            p.UnsafeSetAmount(Item.Road, 15);
            Assert.IsFalse(p.CanTransfer(Bank.CostOf(Item.Road)));
            Assert.AreEqual(15, p.GetAmount(Item.Road));
        }

        [TestMethod]
        public void CanWinWith10VictoryPoints()
        {
            p.UnsafeSetAmount(Item.VictoryPointCard, 10);
            Assert.IsTrue(p.CanWin);
        }


        private bool LimitedItemTestHelper(Item resource, int startingAmt, int toAdd)
        {
            p.UnsafeSetAmount(resource, startingAmt);
            return p.CanReceive(new ItemContainer(new Dictionary<Item, int>
            {
                {resource, toAdd}
            }));
        }

        [TestMethod]
        public void CanReceive4thCity()
        {
            Assert.IsTrue(LimitedItemTestHelper(Item.City, 3, 1));
        }

        [TestMethod]
        public void CannotReceive5thCity()
        {
            Assert.IsFalse(LimitedItemTestHelper(Item.City, 4, 1));
        }

        [TestMethod]
        public void CannotReceive5thCityLump()
        {
            Assert.IsFalse(LimitedItemTestHelper(Item.City, 3, 2));
        }

        [TestMethod]
        public void CanReceive5thSettlement()
        {
            Assert.IsTrue(LimitedItemTestHelper(Item.Settlement, 3, 1));
        }

        [TestMethod]
        public void CannotReceive6thSettlement()
        {
            Assert.IsFalse(LimitedItemTestHelper(Item.Settlement, 5, 1));
        }

        [TestMethod]
        public void CannotReceive6thSettlementLump()
        {
            Assert.IsFalse(LimitedItemTestHelper(Item.Settlement, 0, 6));
        }

        [TestMethod]
        public void CanReceive15thRoad()
        {
            Assert.IsTrue(LimitedItemTestHelper(Item.Road, 14, 1));
        }

        [TestMethod]
        public void CannotReceive15thRoad()
        {
            Assert.IsFalse(LimitedItemTestHelper(Item.Road, 15, 1));
        }

        [TestMethod]
        public void CannotReceive16thRoadLump()
        {
            Assert.IsFalse(LimitedItemTestHelper(Item.Road, 0, 16));
        }

        [TestMethod]
        public void DiscardErrorsIfAttemptToTransferPositiveOut()
        {
            Assert.IsFalse(p.DiscardPile.CanTransfer(Item.Desert.Count()));
        }

        [TestMethod]
        public void DiscardErrorsIfAttemptToReceiveNegativeOut()
        {
            Assert.IsFalse(p.DiscardPile.CanReceive(Item.Desert.Count(-1)));
        }

        [TestMethod]
        public void CanDiscardAmt()
        {
            p.DiscardPile.Transfer(Item.Desert.Count(-1), new ItemContainer());
        }

    }
}
