using System;
using System.Collections.Generic;
using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.UnitTests.Model
{
    [TestClass]
    public class ItemContainerUnitTest
    {

        private static ItemContainer SetupContainer(Item item, int count)
        {
            return new ItemContainer(new Dictionary<Item, int> {{item, count}});
        }

        private static Mock<ItemContainer> SetupDestMock(bool returnVal)
        {
            var mock = new Mock<ItemContainer>(null, null);
            mock.Setup(i => i.CanReceive(It.IsAny<ItemContainer>())).Returns(returnVal);
            return mock;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Conservation of mass (or game objects) should not be violated here")]
        public void ThrowsOnInvalidTransferOfOneResource()
        {
            var src = SetupContainer(Item.Ore, 0);
            var dest = SetupDestMock(true);
            src.Transfer(Item.Brick.Count(), dest.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Conservation of mass (or game objects) should not be violated here")]
        public void CannotTransferMoreThanItHas()
        {
            var src = SetupContainer(Item.Ore, 20);
            var amt = SetupContainer(Item.Ore, 21);
            var dest = SetupDestMock(false);
            src.Transfer(amt, dest.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Conservation of mass (or game objects) should not be violated here")]
        public void CannotTransferMoreThanCanBeReceived()
        {
            var src = SetupContainer(Item.Ore, 20);
            var amt = SetupContainer(Item.Ore, 20);
            var dest = SetupDestMock(false);
            src.Transfer(amt, dest.Object);
        }

        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Conservation of mass (or game objects) should not be violated here")]
        public void CannotTransferMoreThanCanBeReceivedSingleItem()
        {
            var src = SetupContainer(Item.Ore, 20);
            var dest = SetupDestMock(false);
            src.Transfer(Item.Ore.Count(5), dest.Object);
        }        

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Mutation should not be allowed")]
        public void ImmutableByTransfer()
        {
            var container = new ItemContainer.ImmutableItemContainer(new Dictionary<Item, int>());
            var amt = Item.Desert.Count();
            var dest = new ItemContainer();
            container.Transfer(amt, dest);
        }

        [TestMethod]
        public void ImmutableCanReceive()
        {
            var container = new ItemContainer.ImmutableItemContainer(new Dictionary<Item, int>());
            var amt = Item.Desert.Count();
            Assert.IsFalse(container.CanReceive(amt));
        }

        [TestMethod]
        public void ImmutableCanTransfer()
        {
            var container = new ItemContainer.ImmutableItemContainer(new Dictionary<Item, int>());
            var amt = Item.Desert.Count(-1);
            Assert.IsFalse(container.CanTransfer(amt));
        }
    }
}
