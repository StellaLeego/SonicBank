﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Common;

namespace Open.Tests.Data.Common {
    [TestClass]
    public class IdentifiedDbRecordTests : ObjectTests<IdentifiedDbRecord> {
        protected override IdentifiedDbRecord getRandomTestObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsAbstract() {
            Assert.IsTrue(typeof(IdentifiedDbRecord).IsAbstract);
        }

        [TestMethod]
        public void BaseTypeIsUniqueDbRecord() {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(IdentifiedDbRecord).BaseType);
        }

        [TestMethod]
        public void IDTest() {
            testReadWriteProperty(() => obj.ID, x => obj.ID = x);
            testNullEmptyAndWhitespacesCases(() => obj.ID, x => obj.ID = x, () => obj.Name);
        }

        [TestMethod]
        public void NameTest() {
            testReadWriteProperty(() => obj.Name, x => obj.Name = x, () => obj.Code);
        }

        [TestMethod]
        public void CodeTest() {
            testReadWriteProperty(() => obj.Code, x => obj.Code = x);
            testNullEmptyAndWhitespacesCases(() => obj.Code, x => obj.Code = x, () => Constants.Unspecified);
        }

        private class testClass : IdentifiedDbRecord { }
    }
}