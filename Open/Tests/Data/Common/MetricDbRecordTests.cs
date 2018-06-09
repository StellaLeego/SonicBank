using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;

namespace Open.Tests.Data.Common {
    [TestClass]
    public class MetricDbRecordTests : ObjectTests<MetricDbRecord> {
        protected override MetricDbRecord getRandomTestObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsAbstract() {
            Assert.IsTrue(typeof(MetricDbRecord).IsAbstract);
        }

        [TestMethod]
        public void BaseTypeIsRootObjectDbRecord() {
            Assert.AreEqual(typeof(IdentifiedDbRecord), typeof(MetricDbRecord).BaseType);
        }

        private class testClass : MetricDbRecord { }
    }
}