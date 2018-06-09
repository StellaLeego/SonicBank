using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Project;

namespace Open.Tests.Facade.Project {
    [TestClass]
    public class CreditCardViewModelTests : ObjectTests<CreditCardViewModel> {
        protected override CreditCardViewModel getRandomTestObject() {
            return GetRandom.Object<CreditCardViewModel>();
        }

        [TestMethod]
        public void IsPaymentViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(DebitCardViewModel));
        }

        [TestMethod]
        public void CreditLimitTest() {
            testReadWriteProperty(() => obj.CreditLimit, x => obj.CreditLimit = x);
        }
    }
}