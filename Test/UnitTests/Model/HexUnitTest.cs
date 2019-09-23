using System.Collections.Generic;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Model
{
    [TestClass]
    public class HexUnitTest
    {
        private Mock<Intersection> intersectionMock;
        private List<Intersection> intersections;

        [TestInitialize]
        public void InitializeTest()
        {
            intersectionMock = new Mock<Intersection>();
            intersections = new List<Intersection>
            {
                intersectionMock.Object
            };
        }

        [TestMethod]
        public void HexInitialization()
        {
            var newHex = new Hex(intersections, Item.Desert, 4);

            Assert.IsFalse(newHex.HasRobber);
            Assert.AreEqual(Item.Desert, newHex.Resource);
            Assert.AreEqual(4, newHex.RollNumber);
        }

        [TestMethod]
        public void DesertGivesNothing()
        {
            var hex = new Hex(intersections, Item.Desert, 4);
            var result = hex.DistributeDieRollResources(4);
            Assert.AreEqual(0,result.Count);
        }

        [TestMethod]
        public void RobberGivesNothing()
        {
            var hex = new Hex(intersections, Item.Ore, 4) {HasRobber = true};
            var result = hex.DistributeDieRollResources(4);
            Assert.AreEqual(0,result.Count);
        }

        [TestMethod]
        public void SettlementGivesOne()
        {
            intersectionMock.Setup(obj => obj.HasSettlement).Returns(true);
            var hex = new Hex(intersections, Item.Ore, 4);
          
            var result = hex.DistributeDieRollResources(4);
            Assert.AreEqual(1,result.Count);
            Assert.AreEqual(Item.Ore,result[0].Resource);
            Assert.AreEqual(1,result[0].Amount);
        }

        [TestMethod]
        public void CityGivesTwo()
        {
            intersectionMock.Setup(obj => obj.HasCity).Returns(true);
            var hex = new Hex(intersections, Item.Ore, 4);
          
            var result = hex.DistributeDieRollResources(4);
            var count = 0;
            foreach (var element in result)
            {
                Assert.AreEqual(Item.Ore, element.Resource);
                count += element.Amount;
            }
            Assert.AreEqual(2,count);
        }
    }
}
