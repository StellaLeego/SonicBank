using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Project;

namespace Open.Tests.Facade.Project
{
    [TestClass]
    public class PaymentViewModelTests : ObjectTests<PaymentViewModel>
    {
        private class testClass : PaymentViewModel { }

        protected override PaymentViewModel getRandomTestObject()
        {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsUniqueEntityViewModelTest()
        {
            Assert.AreEqual(obj.GetType().BaseType.BaseType, typeof(UniqueEntityViewModel));
        }

        [TestMethod]
        public void PaymentTypeTest()
        {
            Assert.AreEqual("testClass", obj.PaymentType);
            Assert.AreEqual("Cash", new CashViewModel().PaymentType);
            Assert.AreEqual("Check", new CheckViewModel().PaymentType);
            Assert.AreEqual("CreditCard", new CreditCardViewModel().PaymentType);
            Assert.AreEqual("DebitCard", new DebitCardViewModel().PaymentType);
        }
        [TestMethod]
        public void PayerTest()
        {
            testReadWriteProperty(() => obj.Payer, x => obj.Payer = x);
        }
        [TestMethod]
        public void PayerAccountNumberTest()
        {
            testReadWriteProperty(() => obj.PayerAccountNumber, x => obj.PayerAccountNumber = x);
        }
        [TestMethod]
        public void PayeeTest()
        {
            testReadWriteProperty(() => obj.Payee, x => obj.Payee = x);
        }
        [TestMethod]
        public void PayeeAccountNumberTest()
        {
            testReadWriteProperty(() => obj.PayeeAccountNumber, x => obj.PayeeAccountNumber = x);
        }
        [TestMethod]
        public void AmountTest()
        {
            testReadWriteProperty(() => obj.Amount, x => obj.Amount = x);
        }
        [TestMethod]
        public void CurrencyTest()
        {
            testReadWriteProperty(() => obj.Currency, x => obj.Currency = x);
        }
        [TestMethod]
        public void MemoTest()
        {
            testReadWriteProperty(() => obj.Memo, x => obj.Memo = x);
        }
    }
}
