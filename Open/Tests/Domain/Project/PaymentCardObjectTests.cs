using System;
using System.Collections.Generic;
using System.Text;
using Open.Aids;
using Open.Data.Project;
using Open.Domain.Project;

namespace Open.Tests.Domain.Project
{
    class PaymentCardObjectTests : DomainObjectsTests<PaymentCardObject, PaymentCardDbRecord>
    {
        protected override PaymentCardObject getRandomTestObject()
        {
            createdWithNullArg = new DebitCardObject(null);
            dbRecordType = typeof(DebitCardDbRecord);
            return GetRandom.Object<DebitCardObject>();
        }
    }
}
