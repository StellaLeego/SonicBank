using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Project;
using Open.Facade.Project;

namespace Open.Tests.Facade.Project {
    [TestClass]
    public class PaymentViewModelFactoryTests : BaseTests {
        private const string u = Constants.Unspecified;

        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(PaymentViewModelFactory);
        }

        [TestMethod]
        public void CreateTest() {
            var v = PaymentViewModelFactory.Create(null) as CashViewModel;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, u);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
            Assert.AreEqual(v.Amount, u);
            Assert.AreEqual(v.Currency, u);
            Assert.AreEqual(v.Memo, u);
            Assert.AreEqual(v.Payee, u);
            Assert.AreEqual(v.PayeeAccountNumber, u);
            Assert.AreEqual(v.Payer, u);
            Assert.AreEqual(v.PayerAccountNumber, u);
        }

        [TestMethod]
        public void CreateCashTest() {
            var o = GetRandom.Object<CashObject>();
            var v = PaymentViewModelFactory.Create(o) as CashViewModel;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
            Assert.AreEqual(v.Amount, o.DbRecord.Amount);
            Assert.AreEqual(v.Currency, o.DbRecord.Currency);
            Assert.AreEqual(v.Memo, o.DbRecord.Memo);
            Assert.AreEqual(v.Payee, o.DbRecord.Payee);
            Assert.AreEqual(v.PayeeAccountNumber, o.DbRecord.PayeeAccountNumber);
            Assert.AreEqual(v.Payer, o.DbRecord.Payer);
            Assert.AreEqual(v.PayerAccountNumber, o.DbRecord.PayerAccountNumber);
        }

        [TestMethod]
        public void CreateCheckTest() {
            var o = GetRandom.Object<CheckObject>();
            var v = PaymentViewModelFactory.Create(o) as CheckViewModel;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
            Assert.AreEqual(v.Amount, o.DbRecord.Amount);
            Assert.AreEqual(v.Currency, o.DbRecord.Currency);
            Assert.AreEqual(v.Memo, o.DbRecord.Memo);
            Assert.AreEqual(v.Payee, o.DbRecord.Payee);
            Assert.AreEqual(v.PayeeAccountNumber, o.DbRecord.PayeeAccountNumber);
            Assert.AreEqual(v.Payer, o.DbRecord.Payer);
            Assert.AreEqual(v.PayerAccountNumber, o.DbRecord.PayerAccountNumber);
            Assert.AreEqual(v.CheckNumber, o.DbRecord.CheckNumber);
        }

        [TestMethod]
        public void CreateDebitCardTest() {
            var o = GetRandom.Object<DebitCardObject>();
            var v = PaymentViewModelFactory.Create(o) as DebitCardViewModel;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
            Assert.AreEqual(v.Amount, o.DbRecord.Amount);
            Assert.AreEqual(v.Currency, o.DbRecord.Currency);
            Assert.AreEqual(v.Memo, o.DbRecord.Memo);
            Assert.AreEqual(v.Payee, o.DbRecord.Payee);
            Assert.AreEqual(v.PayeeAccountNumber, o.DbRecord.PayeeAccountNumber);
            Assert.AreEqual(v.Payer, o.DbRecord.Payer);
            Assert.AreEqual(v.PayerAccountNumber, o.DbRecord.PayerAccountNumber);
            Assert.AreEqual(v.CardAssociationName, o.DbRecord.CardAssociationName);
            Assert.AreEqual(v.CardNumber, o.DbRecord.CardNumber);
            Assert.AreEqual(v.DailyWithdrawalLimit, o.DbRecord.DailyWithDrawalLimit);
        }

        [TestMethod]
        public void CreateCreditCardTest() {
            var o = GetRandom.Object<CreditCardObject>();
            var v = PaymentViewModelFactory.Create(o) as CreditCardViewModel;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
            Assert.AreEqual(v.Amount, o.DbRecord.Amount);
            Assert.AreEqual(v.Currency, o.DbRecord.Currency);
            Assert.AreEqual(v.Memo, o.DbRecord.Memo);
            Assert.AreEqual(v.Payee, o.DbRecord.Payee);
            Assert.AreEqual(v.PayeeAccountNumber, o.DbRecord.PayeeAccountNumber);
            Assert.AreEqual(v.Payer, o.DbRecord.Payer);
            Assert.AreEqual(v.PayerAccountNumber, o.DbRecord.PayerAccountNumber);
            Assert.AreEqual(v.CardAssociationName, o.DbRecord.CardAssociationName);
            Assert.AreEqual(v.CardNumber, o.DbRecord.CardNumber);
            Assert.AreEqual(v.DailyWithdrawalLimit, o.DbRecord.DailyWithDrawalLimit);
            Assert.AreEqual(v.CreditLimit, o.DbRecord.CreditLimit);
        }

        [TestMethod]
        public void CreateWithExtremumDatesTest() {
            var o = GetRandom.Object<CashObject>();
            o.DbRecord.ValidFrom = DateTime.MinValue;
            o.DbRecord.ValidTo = DateTime.MaxValue;
            var v = PaymentViewModelFactory.Create(o);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }
    }
}