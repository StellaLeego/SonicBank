

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Project;
using Open.Domain.Project;

namespace Open.Tests.Domain.Project
{
    [TestClass]
    public class CreditCardObjectTests : DomainObjectsTests<CreditCardObject, CreditCardDbRecord>
    {
        protected override CreditCardObject getRandomTestObject()
        {
            createdWithNullArg = new CreditCardObject(null);
            dbRecordType = typeof(CreditCardDbRecord);
            return GetRandom.Object<CreditCardObject>();
        }
    }
}
