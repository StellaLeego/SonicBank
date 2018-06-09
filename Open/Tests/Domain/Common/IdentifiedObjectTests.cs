using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Location;
using Open.Domain.Common;

namespace Open.Tests.Domain.Common {
    [TestClass]
    public class IdentifiedObjectTests : DomainObjectsTests<IdentifiedObject<CountryDbRecord>, CountryDbRecord> {
        protected override IdentifiedObject<CountryDbRecord> getRandomTestObject() {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(IdentifiedDbRecord);
            return GetRandom.Object<testClass>();
        }

        private class testClass : IdentifiedObject<CountryDbRecord> {
            public testClass(CountryDbRecord dbRecord) : base(dbRecord) { }
        }
    }
}