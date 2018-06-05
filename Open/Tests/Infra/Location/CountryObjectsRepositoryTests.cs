using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Location;

namespace Open.Tests.Infra.Location
{
    [TestClass]
    public class CountryObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CountryObjectsRepository);
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new CountryObjectsRepository(null));
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
