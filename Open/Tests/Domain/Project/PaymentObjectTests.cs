using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Project;
using Open.Domain.Project;

namespace Open.Tests.Domain.Project
{
    [TestClass]
    public class PaymentObjectTests : DomainObjectsTests<PaymentObject<CashDbRecord>, CashDbRecord>
    {
        class testClass : PaymentObject<CashDbRecord>
        {
            public testClass(CashDbRecord r) : base(r) { }
        }

        protected override PaymentObject<CashDbRecord> getRandomTestObject()
        {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(PaymentDbRecord);
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsPaymentCardObjectTest()
        {
            Assert.IsInstanceOfType(obj, typeof(IPaymentObject));
        }
    }
}
