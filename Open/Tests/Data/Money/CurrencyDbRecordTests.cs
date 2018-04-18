using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Money;
using Open.Data.Common;

namespace Open.Tests.Data.Money
{
    [TestClass]
    public class CurrencyDbRecordTests : ObjectTests<CurrencyDbRecord>
    {
        protected override CurrencyDbRecord getRandomTestObject()
        {
            return GetRandom.Object<CurrencyDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfMetric()
        {
            Assert.AreEqual(typeof(MetricDbRecord), obj.GetType().BaseType);
        }
    }
}
