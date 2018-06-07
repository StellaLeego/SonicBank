using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Project;
using Open.Domain.Project;

namespace Open.Tests.Domain.Project
{
    [TestClass]
    public class CheckObjectTests : DomainObjectsTests<CheckObject, CheckDbRecord>
    {
        protected override CheckObject getRandomTestObject()
        {
            createdWithNullArg = new CheckObject(null);
            dbRecordType = typeof(CheckDbRecord);
            return GetRandom.Object<CheckObject>();
        }
    }
}
