using Catan.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.UnitTests.Model
{
    [TestClass]
    public class PlayerActionTest
    {
        [TestMethod]
        public void ActionTypeExtensionMethod()
        {
            Assert.AreEqual("Build",ActionType.Build.LocalizedString());
        }
    }
}