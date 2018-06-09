using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Location;
using Open.Domain.Common;

namespace Open.Tests.Domain.Common {
    [TestClass]
    public class UniqueObjectTests : DomainObjectsTests<UniqueObject<CountryDbRecord>, CountryDbRecord> {
        protected override UniqueObject<CountryDbRecord> getRandomTestObject() {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(UniqueDbRecord);
            return GetRandom.Object<testClass>();
        }

        private class testClass : UniqueObject<CountryDbRecord> {
            public testClass(CountryDbRecord dbRecord) : base(dbRecord) { }
        }
    }
}