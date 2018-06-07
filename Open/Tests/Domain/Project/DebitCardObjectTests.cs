using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Project;
using Open.Domain.Project;

namespace Open.Tests.Domain.Project
{
    [TestClass]
    public class DebitCardObjectTests : DomainObjectsTests<DebitCardObject, DebitCardDbRecord>
    {
        protected override DebitCardObject getRandomTestObject()
        {
            createdWithNullArg = new DebitCardObject(null);
            dbRecordType = typeof(DebitCardDbRecord);
            return GetRandom.Object<DebitCardObject>();
        }
    }
}
