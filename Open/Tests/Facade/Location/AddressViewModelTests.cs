using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Location;

namespace Open.Tests.Facade.Location {
    [TestClass]
    public class AddressViewModelTests : ObjectTests<AddressViewModel> {
        protected override AddressViewModel getRandomTestObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsUniqueEntityViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType.BaseType, typeof(UniqueEntityViewModel));
        }

        [TestMethod]
        public void AddressTypeTest() {
            Assert.AreEqual("testClass", obj.AddressType);
            Assert.AreEqual("WebPage", new WebPageAddressViewModel().AddressType);
            Assert.AreEqual("Email", new EmailAddressViewModel().AddressType);
            Assert.AreEqual("Geographic", new GeographicAddressViewModel().AddressType);
            Assert.AreEqual("Telecom", new TelecomAddressViewModel().AddressType);
        }

        [TestMethod]
        public void ContactTest() {
            Assert.AreEqual(obj.Contact, obj.ToString());
        }

        private class testClass : AddressViewModel { }
    }
}