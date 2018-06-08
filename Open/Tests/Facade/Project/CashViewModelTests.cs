using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Project;

namespace Open.Tests.Facade.Project
{
    [TestClass]
    public class CashViewModelTests : ObjectTests<CashViewModel>
    {
        protected override CashViewModel getRandomTestObject()
        {
            return GetRandom.Object<CashViewModel>();
        }

        [TestMethod]
        public void IsPaymentViewModelTest()
        {
            Assert.AreEqual(obj.GetType().BaseType, typeof(PaymentViewModel));
        }

        [TestMethod]
        public void AmountTest()
        {
            testReadWriteProperty(() => obj.Amount, x=> obj.Amount = x);
        }
    }
}
