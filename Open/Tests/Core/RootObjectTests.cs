﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;

namespace Open.Tests.Core {
    [TestClass]
    public class RootObjectTests : ClassTests<RootObject> {
        private testClass obj;
        private string x;
        private string y;

        [TestMethod]
        public void getDecimalTest() {
            obj.D = decimal.Zero;
            var expected = obj.getDecimal(ref obj.D);
            Assert.AreEqual(obj.D, expected);
        }

        private void testGetValue(string field, string value, string expected) {
            obj.S = field;
            obj.getString(ref obj.S, value);
            Assert.AreEqual(expected, obj.S);
        }

        private void testMinMax(Action method) {
            method();
            Assert.AreEqual(DateTime.MinValue, obj.F);
            Assert.AreEqual(DateTime.MaxValue, obj.T);
        }

        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass {F = DateTime.MaxValue, T = DateTime.MinValue};
            x = GetRandom.String();
            y = GetRandom.String();
        }

        [TestMethod]
        public void GetValueTest() {
            testGetValue(null, y, y);
            testGetValue("", y, y);
            testGetValue("   ", y, y);
            testGetValue(x, y, x);
        }

        [TestMethod]
        public void GetMinValueTest() {
            testMinMax(() => obj.getMinValue(ref obj.F, ref obj.T));
        }

        [TestMethod]
        public void GetMaxValueTest() {
            testMinMax(() => obj.getMaxValue(ref obj.T, ref obj.F));
        }

        [TestMethod]
        public void ContainsTest() {
            obj = GetRandom.Object<testClass>();
            Assert.IsFalse(obj.Contains(GetRandom.String()));
            Assert.IsTrue(obj.Contains(string.Empty));
            Assert.IsTrue(obj.Contains(null));
            Assert.IsTrue(obj.Contains(obj.Name));
            obj.Name = null;
            Assert.IsTrue(obj.Contains(obj.Date.Year.ToString()));
            Assert.IsTrue(obj.Contains(obj.Date.Day.ToString()));
            Assert.IsTrue(obj.Contains(obj.Date.Month.ToString()));
        }

        private class testClass : RootObject {
            public decimal D;
            public DateTime F;
            public string S;
            public DateTime T;
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }
    }
}