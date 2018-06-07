using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Project;
using Open.Domain.Project;

namespace Open.Tests.Domain.Project
{
    [TestClass]
    public class PaymentCardObjectTests : DomainObjectsTests<PaymentCardObject<DebitCardDbRecord>, DebitCardDbRecord>
    {
        class testClass : PaymentCardObject<DebitCardDbRecord>
        {
            public testClass(DebitCardDbRecord r) : base(r) { }
        }


        protected override PaymentCardObject<DebitCardDbRecord> getRandomTestObject()
        {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(PaymentCardDbRecord);
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsPaymentCardObjectTest()
        {
            Assert.IsInstanceOfType(obj, typeof(IPaymentCardObject));
        }
    }
}
