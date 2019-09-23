using System.Collections.Generic;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Model
{
    [TestClass]
    public class PathUnitTest
    {
        private readonly Mock<Player> playerMock = new Mock<Player>(PlayerColor.Blue);
        private readonly Path path = new Path(new List<Intersection>());

        [TestMethod]
        public void HasRoadInitial()
        {
            Assert.IsFalse(path.HasRoad());
        }

        [TestMethod]
        public void HasRoadAfterBuilding()
        {
            path.SetOwner(playerMock.Object);
            Assert.IsTrue(path.HasRoad());
        }

        [TestMethod]
        public void GetOwner()
        {
            path.SetOwner(playerMock.Object);
            Assert.AreSame(playerMock.Object, path.GetOwner());
        }
    }
}
