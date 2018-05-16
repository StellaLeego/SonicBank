using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Money;

namespace Open.Tests.Infra.Money
{
    [TestClass]
    public class CurrencyObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CurrencyObjectsRepository);
        }

        [TestMethod]
        public void CanCreateTest()
        {
            Assert.IsNotNull(new CurrencyObjectsRepository(null));
        }

        [TestMethod]
        public void GetObjectsListTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IsInitializedTest()
        {
            Assert.Inconclusive();
        }
    }
}
