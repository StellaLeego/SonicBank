using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
