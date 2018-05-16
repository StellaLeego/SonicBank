using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Location;

namespace Open.Tests.Infra.Location
{
    [TestClass]
    public class AddressDbTableInitializerTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(AddressDbTableInitializer);
        }

        [TestMethod]
        public void CantInitializeTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void InitializeTest()
        {
            Assert.Inconclusive();
        }
    }
}
