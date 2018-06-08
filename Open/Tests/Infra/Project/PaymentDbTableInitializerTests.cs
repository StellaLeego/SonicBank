
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Project;

namespace Open.Tests.Infra.Project
{
    class PaymentDbTableInitializerTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PaymentDbTableInitializer);
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
