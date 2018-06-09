using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Project;

namespace Open.Tests.Data.Project {
    [TestClass]
    public class CheckDbRecordTests : ObjectTests<CheckDbRecord> {
        protected override CheckDbRecord getRandomTestObject() {
            return GetRandom.Object<CheckDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfAPaymentDbRecord() {
            Assert.AreEqual(typeof(PaymentDbRecord), obj.GetType().BaseType);
        }

        [TestMethod]
        public void CheckNumberTest() {
            testReadWriteProperty(() => obj.CheckNumber, x => obj.CheckNumber = x);
        }
    }
}