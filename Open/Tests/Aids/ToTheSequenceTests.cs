using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;

namespace Open.Tests.Aids {
    [TestClass]
    public class ToTheSequenceTests : BaseTests {
        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(ToTheSequence);
        }

        [TestMethod]
        public void OfGrowingTest() {
            doGrowingTest(DateTime.MaxValue, DateTime.MinValue);
            doGrowingTest(double.MaxValue, double.MinValue);
            doGrowingTest(int.MaxValue, int.MinValue);
        }

        private static void doGrowingTest<T>(T maxValue, T minValue) where T : IComparable {
            Assert.IsTrue(maxValue.CompareTo(minValue) >= 0);
            ToTheSequence.OfGrowing(ref maxValue, ref minValue);
            Assert.IsTrue(maxValue.CompareTo(minValue) <= 0);
        }
    }
}