﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Infra.Money;

namespace Open.Tests.Infra.Money {
    [TestClass]
    public class CurrenciesDbTableInitializerTests : CurrencyDbTests {
        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CurrenciesDbTableInitializer);
        }

        [TestMethod]
        public void CantInitializeTest() {
            Assert.AreEqual(count, db.Currencies.Count());
            CurrenciesDbTableInitializer.Initialize(db);
            Assert.AreEqual(count, db.Currencies.Count());
        }

        [TestMethod]
        public void InitializeTest() {
            TestCleanup();
            CurrenciesDbTableInitializer.Initialize(db);
            var l = SystemRegionInfo.GetRegionsList();
            var a = new List<string>();
            for (var i = l.Count; i > 0; i--) {
                var c = l[i - 1];
                if (!SystemRegionInfo.IsCountry(c)) continue;
                if (a.Contains(c.ISOCurrencySymbol)) continue;
                a.Add(c.ISOCurrencySymbol);
            }

            Assert.AreEqual(a.Count, db.Currencies.Count());
        }
    }
}