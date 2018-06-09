using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Project;
using Open.Domain.Project;

namespace Open.Tests.Domain.Project
{
    [TestClass]
    public class PaymentObjectFactoryTests : BaseTests
    {
        private const string u = Constants.Unspecified;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PaymentObjectFactory);
        }

        [TestMethod]
        public void CreateDebitTest()
        {
            var r = GetRandom.Object<DebitCardDbRecord>();
            var o = PaymentObjectFactory.CreateDebit(r.ID, r.Amount, r.Currency, r.Memo, r.Payer,
                r.PayerAccountNumber, r.CardAssociationName, r.CardNumber, r.DailyWithDrawalLimit, r.Payee,
                r.PayeeAccountNumber, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(DebitCardObject));
            testVariables(o.DbRecord, r.ID, r.Amount, r.Currency, r.Memo, r.Payer, r.Payee, r.ValidFrom,
                r.ValidTo, r.PayeeAccountNumber, r.PayerAccountNumber);
            testCardVariables(o.DbRecord, r.CardAssociationName, r.CardNumber, r.DailyWithDrawalLimit);
        }
        [TestMethod]
        public void CreateCreditTest()
        {
            var r = GetRandom.Object<CreditCardDbRecord>();
            var o = PaymentObjectFactory.CreateCredit(r.ID, r.Amount, r.Currency, r.Memo, r.Payer,
                r.PayerAccountNumber, r.CardAssociationName, r.CardNumber, r.DailyWithDrawalLimit, r.Payee,
                r.PayeeAccountNumber, r.CreditLimit, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(CreditCardObject));
            testVariables(o.DbRecord, r.ID, r.Amount, r.Currency, r.Memo, r.Payer, r.Payee, r.ValidFrom = DateTime.MinValue, r.ValidTo = DateTime.MaxValue, r.PayeeAccountNumber, r.PayerAccountNumber);
            testCardVariables(o.DbRecord, r.CardAssociationName, r.CardNumber, r.DailyWithDrawalLimit);
            Assert.AreEqual(r.CreditLimit, o.DbRecord.CreditLimit);
        }
        [TestMethod]
        public void CreateCheckTest()
        {
            var r = GetRandom.Object<CheckDbRecord>();
            var o = PaymentObjectFactory.CreateCheck(r.ID, r.Amount, r.Currency, r.Memo, r.Payer,
                r.PayerAccountNumber, r.Payee, r.PayeeAccountNumber, r.CheckNumber, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(CheckObject));
            testVariables(o.DbRecord, r.ID, r.Amount, r.Currency, r.Memo, r.Payer, r.Payee, r.ValidFrom,
                r.ValidTo, r.PayeeAccountNumber, r.PayerAccountNumber);
        }
        [TestMethod]
        public void CreateCashTest()
        {
            var r = GetRandom.Object<CashDbRecord>();
            var o = PaymentObjectFactory.CreateCash(r.ID, r.Amount, r.Currency, r.Memo, r.Payer, r.Payee,
                r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(CashObject));
            testVariables(o.DbRecord, r.ID, r.Amount, r.Currency, r.Memo, r.Payer, r.Payee, r.ValidFrom,
                r.ValidTo);
        }

        [TestMethod]
        public void CreateTest()
        {
            void test<T>(PaymentDbRecord r)
            {
                var o = PaymentObjectFactory.Create(r);
                Assert.IsInstanceOfType(o, typeof(T));
            }
            test<DebitCardObject>(GetRandom.Object<DebitCardDbRecord>());
            test<CreditCardObject>(GetRandom.Object<CreditCardDbRecord>());
            test<CheckObject>(GetRandom.Object<CheckDbRecord>());
            test<CashObject>(GetRandom.Object<CashDbRecord>());
            test<CashObject>(GetRandom.Object<PaymentDbRecord>());
            test<CashObject>(null);
        }
        private void testVariables(PaymentDbRecord o, string id, string amo, string cur, 
            string memo, string payer, string payee, DateTime vFrom,
            DateTime vTo, string payeeAccountNumber = u, string payerAccountNumber = u)
        {
            Assert.AreEqual(id, o.ID);
            Assert.AreEqual(amo, o.Amount);
            Assert.AreEqual(cur, o.Currency);
            Assert.AreEqual(memo, o.Memo);
            Assert.AreEqual(payer, o.Payer);
            Assert.AreEqual(payee, o.Payee);
            Assert.AreEqual(vFrom, o.ValidFrom);
            Assert.AreEqual(vTo, o.ValidTo);
            Assert.AreEqual(payeeAccountNumber, o.PayeeAccountNumber);
            Assert.AreEqual(payerAccountNumber, o.PayerAccountNumber);
        }

        private void testCardVariables(PaymentCardDbRecord o, string cardAssociationName = u,
            string cardNumber = u, string dailyWithDrawalLimit = u) {
            Assert.AreEqual(cardAssociationName, o.CardAssociationName);
            Assert.AreEqual(cardNumber, o.CardNumber);
            Assert.AreEqual(dailyWithDrawalLimit, o.DailyWithDrawalLimit);
        }
    }
}
