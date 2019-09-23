using System.Globalization;
using Catan.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.LearningTests
{
    [TestClass]
    public class LocalizationLearningTest
    {
        [TestMethod]
        public void TestChangingLocale()
        {
            var invariantCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentCulture = invariantCulture;
            CultureInfo.CurrentUICulture = invariantCulture;
            Assert.AreEqual("Brick", Resources.Item_Brick);

            var frenchCulture = new CultureInfo("fr-CA");
            CultureInfo.CurrentCulture = frenchCulture;
            CultureInfo.CurrentUICulture = frenchCulture;
            Assert.AreEqual("Brique", Resources.Item_Brick);

            CultureInfo.CurrentCulture = invariantCulture;
            CultureInfo.CurrentUICulture = invariantCulture;
        }
    }
}