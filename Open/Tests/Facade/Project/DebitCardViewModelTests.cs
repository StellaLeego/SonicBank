using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Project;

namespace Open.Tests.Facade.Project
{
    [TestClass]
    public class DebitCardViewModelTests : ObjectTests<DebitCardViewModel>
    {
        protected override DebitCardViewModel getRandomTestObject()
        {
            return GetRandom.Object<DebitCardViewModel>();
        }

        [TestMethod]
        public void IsPaymentViewModelTest()
        {
            Assert.AreEqual(obj.GetType().BaseType, typeof(PaymentViewModel));
        }

        [TestMethod]
        public void CardNumberTest()
        {
            testReadWriteProperty(() => obj.CardNumber, x => obj.CardNumber = x);
        }

        [TestMethod]
        public void CardAssociationNameTest()
        {
            testReadWriteProperty(() => obj.CardAssociationName, x => obj.CardAssociationName = x);
        }

        [TestMethod]
        public void DailyWithdrawalLimitTest()
        {
            testReadWriteProperty(() => obj.DailyWithdrawalLimit, x => obj.DailyWithdrawalLimit = x);
        }
    }
}
