using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Project;

namespace Open.Tests.Data.Project {
    [TestClass]
    public class CashDbRecordTests : ObjectTests<CashDbRecord> {
        protected override CashDbRecord getRandomTestObject() {
            return GetRandom.Object<CashDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfPaymentDbRecord() {
            Assert.AreEqual(typeof(PaymentDbRecord), obj.GetType().BaseType);
        }
    }
}