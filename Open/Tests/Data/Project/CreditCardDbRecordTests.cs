using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Project;

namespace Open.Tests.Data.Project
{
    [TestClass]
    public class CreditCardDbRecordTests : ObjectTests<CreditCardDbRecord>
    {
        protected override CreditCardDbRecord getRandomTestObject()
        {
            return GetRandom.Object<CreditCardDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfPaymentCardDbRecord()
        {
            Assert.AreEqual(typeof(PaymentCardDbRecord), obj.GetType().BaseType);
        }

        [TestMethod]
        public void CreditLimitTest()
        {
            testReadWriteProperty(() => obj.CreditLimit, x => obj.CreditLimit = x);
        }
    }
}
