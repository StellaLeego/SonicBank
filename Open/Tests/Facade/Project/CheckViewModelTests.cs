using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Project;

namespace Open.Tests.Facade.Project {
    [TestClass]
    public class CheckViewModelTests : ObjectTests<CheckViewModel> {
        protected override CheckViewModel getRandomTestObject() {
            return GetRandom.Object<CheckViewModel>();
        }

        [TestMethod]
        public void IsPaymentViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(PaymentViewModel));
        }

        [TestMethod]
        public void CheckNumberTest() {
            testReadWriteProperty(() => obj.CheckNumber, x => obj.CheckNumber = x);
        }
    }
}