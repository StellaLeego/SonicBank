using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Project;
using Open.Domain.Project;

namespace Open.Tests.Domain.Project
{
    [TestClass]
    public class CashObjectTests : DomainObjectsTests<CashObject, CashDbRecord>
    {
        protected override CashObject getRandomTestObject()
        {
            createdWithNullArg = new CashObject(null);
            dbRecordType = typeof(CashDbRecord);
            return GetRandom.Object<CashObject>();
        }
    }
}
