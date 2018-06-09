using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Money;
using Open.Domain.Common;

namespace Open.Tests.Domain.Common {
    [TestClass]
    public class MetricObjectTests : DomainObjectsTests<MetricObject<CurrencyDbRecord>, CurrencyDbRecord> {
        protected override MetricObject<CurrencyDbRecord> getRandomTestObject() {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(MetricDbRecord);
            return GetRandom.Object<testClass>();
        }

        private class testClass : MetricObject<CurrencyDbRecord> {
            public testClass(CurrencyDbRecord dbRecord) : base(dbRecord) { }
        }
    }
}