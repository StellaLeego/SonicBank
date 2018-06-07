using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Project;
using Open.Domain.Project;

namespace Open.Tests.Domain.Project
{
    [TestClass]
    public class PaymentObjectsListTests : DomainObjectsListTests<PaymentObjectsList, IPaymentObject>
    {
        protected override PaymentObjectsList getRandomTestObject(){
            createWithNullArgs = new PaymentObjectsList(null, null);
            var l = getAddressDbRecordsList();
            return new PaymentObjectsList(l, GetRandom.Object<RepositoryPage>());
        }

        private IEnumerable<PaymentDbRecord> getAddressDbRecordsList()
        {
            var l = new List<PaymentDbRecord>();
            for (var i = 0; i < GetRandom.UInt8(5, 10); i++)
            {
                var x = i % 4;
                if (x == 0) l.Add(GetRandom.Object<DebitCardDbRecord>());
                if (x == 1) l.Add(GetRandom.Object<CreditCardDbRecord>());
                if (x == 2) l.Add(GetRandom.Object<CheckDbRecord>());
                if (x == 3) l.Add(GetRandom.Object<CashDbRecord>());
            }

            return l;
        }
    }
}
