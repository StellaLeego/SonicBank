﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Money;

namespace Open.Tests.Data.Money
{
    [TestClass]
    public class CountryCurrencyDbRecordTests : ObjectTests<CountryCurrencyDbRecord>
    {
        protected override CountryCurrencyDbRecord getRandomTestObject() {
            return GetRandom.Object<CountryCurrencyDbRecord>();
        }

        [TestMethod]
        public void CountryIDTest() {
            testReadWriteProperty(() => obj.CountryID, x => obj.CountryID = x);
            testNullEmptyAndWhitespacesCases(() => obj.CountryID, x => obj.CountryID = x, () => Constants.Unspecified);
        }
        [TestMethod]
        public void CurrencyIDTest() {
            testReadWriteProperty(() => obj.CurrencyID, x => obj.CurrencyID = x);
            testNullEmptyAndWhitespacesCases(() => obj.CurrencyID, x => obj.CurrencyID = x, () => Constants.Unspecified);
        }
        [TestMethod]
        public void CountryTest() {
            testReadWriteProperty(() => obj.Country, x => obj.Country = x);
        }
        [TestMethod]
        public void CurrencyTest() {
            testReadWriteProperty(() => obj.Currency, x => obj.Currency = x);
        }
    }
}
