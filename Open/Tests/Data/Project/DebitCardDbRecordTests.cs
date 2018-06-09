using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Project;

namespace Open.Tests.Data.Project {
    [TestClass]
    public class DebitCardDbRecordTests : ObjectTests<DebitCardDbRecord> {
        protected override DebitCardDbRecord getRandomTestObject() {
            return GetRandom.Object<DebitCardDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfPaymentCardDbRecord() {
            Assert.AreEqual(typeof(PaymentCardDbRecord), obj.GetType().BaseType);
        }
    }
}