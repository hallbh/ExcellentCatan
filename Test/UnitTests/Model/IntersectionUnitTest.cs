using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Model
{
    [TestClass]
    public class IntersectionUnitTest
    {
        private readonly Mock<Player> playerMock = new Mock<Player>(PlayerColor.Blue);
        private readonly Intersection intersection = new Intersection();

        [TestMethod]
        public void Initial()
        {
            Assert.IsFalse(intersection.HasSettlement);
            Assert.IsFalse(intersection.HasCity);
        }

        [TestMethod]
        public void HasSettlementAfterBuild()
        {
            intersection.SetOwner(playerMock.Object);
            Assert.IsTrue(intersection.HasSettlement);
        }

        [TestMethod]
        public void HasCityAfterUpgrade()
        {
            intersection.SetOwner(playerMock.Object);
            intersection.UpgradeToCity();
            Assert.IsTrue(intersection.HasCity);
        }
        
        [TestMethod]
        public void GetOwner()
        {
            intersection.SetOwner(playerMock.Object);
            Assert.AreSame(playerMock.Object, intersection.GetOwner());
        }
    }
}
