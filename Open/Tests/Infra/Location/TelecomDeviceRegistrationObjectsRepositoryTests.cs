using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Location;

namespace Open.Tests.Infra.Location
{
    [TestClass]
    public class TelecomDeviceRegistrationObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(TelecomDeviceRegistrationObjectsRepository);
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new TelecomDeviceRegistrationObjectsRepository(null));
        }

        [TestMethod]
        public void GetObjectTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AddObjectTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void UpdateObjectTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void DeleteObjectTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void LoadAddressesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void LoadDevicesTest()
        {
            Assert.Inconclusive();
        }
    }
}
