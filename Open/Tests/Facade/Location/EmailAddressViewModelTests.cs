using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Location;

namespace Open.Tests.Facade.Location {
    [TestClass]
    public class EmailAddressViewModelTests : ObjectTests<EmailAddressViewModel> {
        protected override EmailAddressViewModel getRandomTestObject() {
            return GetRandom.Object<EmailAddressViewModel>();
        }

        [TestMethod]
        public void IsAddressViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(AddressViewModel));
        }

        [TestMethod]
        public void EmailAddressTest() {
            testReadWriteProperty(() => obj.EmailAddress, x => obj.EmailAddress = x);
        }

        [TestMethod]
        public void ToStringTest() {
            Assert.AreEqual(obj.EmailAddress, obj.ToString());
        }
    }
}