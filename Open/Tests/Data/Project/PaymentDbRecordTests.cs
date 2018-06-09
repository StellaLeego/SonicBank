using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Project;

namespace Open.Tests.Data.Project {
    [TestClass]
    public class PaymentDbRecordTests : ObjectTests<PaymentDbRecord> {
        protected override PaymentDbRecord getRandomTestObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsInstanceOfUniqueDbRecord() {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(PaymentDbRecord).BaseType);
        }

        [TestMethod]
        public void PayerTest() {
            testReadWriteProperty(() => obj.Payer, x => obj.Payer = x);
        }

        [TestMethod]
        public void PayeeTest() {
            testReadWriteProperty(() => obj.Payee, x => obj.Payee = x);
        }

        [TestMethod]
        public void AmountTest() {
            testReadWriteProperty(() => obj.Amount, x => obj.Amount = x);
        }

        [TestMethod]
        public void CurrencyTest() {
            testReadWriteProperty(() => obj.Currency, x => obj.Currency = x);
        }

        [TestMethod]
        public void PayerAccountNumberTest() {
            testReadWriteProperty(() => obj.PayerAccountNumber, x => obj.PayerAccountNumber = x);
        }

        [TestMethod]
        public void PayeeAccountNumberTest() {
            testReadWriteProperty(() => obj.PayeeAccountNumber, x => obj.PayeeAccountNumber = x);
        }

        [TestMethod]
        public void MemoTest() {
            testReadWriteProperty(() => obj.Memo, x => obj.Memo = x);
        }

        private class testClass : PaymentDbRecord { }
    }
}