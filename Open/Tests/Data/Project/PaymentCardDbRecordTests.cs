using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Project;

namespace Open.Tests.Data.Project
{
    [TestClass]
    public class PaymentCardDbRecordTests : ObjectTests<PaymentCardDbRecord>
    {
        protected override PaymentCardDbRecord getRandomTestObject()
        {
            return GetRandom.Object<PaymentCardDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfPaymentDbRecord()
        {
            Assert.AreEqual(typeof(PaymentDbRecord), obj.GetType().BaseType);
        }

        [TestMethod]
        public void DailyWithDrawalLimitTest()
        {
            testReadWriteProperty(() => obj.DailyWithDrawalLimit, x => obj.DailyWithDrawalLimit = x);
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
    }
}
