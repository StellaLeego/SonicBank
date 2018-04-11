using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Money;
using Open.Domain.Money;
using Open.Infra.Money;

namespace Open.Tests.Infra.Money
{
    [TestClass]
    public class CurrencyObjectsRepositoryTests : CurrencyDbTests<CurrencyObjectsRepository>
    {
        private static void validateCurrency(CurrencyDbRecord actual, CurrencyDbRecord expected)
        {
            Assert.AreEqual(actual.ID, expected.ID);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Code, expected.Code);
            Assert.AreEqual(actual.ValidFrom, expected.ValidFrom);
            Assert.AreEqual(actual.ValidTo, expected.ValidTo);
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new CurrencyObjectsRepository(null));
        }

        [TestMethod]
        public async Task GetObjectTest()
        {
            var o = GetRandom.Object<CurrencyObject>();
            var currency = await repository.GetObject(o.DbRecord.ID);
            validateCurrency(currency.DbRecord, new CurrencyDbRecord());
            db.Currencies.Add(o.DbRecord);
            db.SaveChanges();
            currency = await repository.GetObject(o.DbRecord.ID);
            validateCurrency(currency.DbRecord, o.DbRecord);
        }

        [TestMethod]
        public async Task GetObjectsListTest()
        {
            var l = await repository.GetObjectsList();
            Assert.AreEqual(count, l.Count());
        }

        [TestMethod]
        public async Task AddObjectTest()
        {
            var o = GetRandom.Object<CurrencyObject>();
            var currency = db.Currencies.Find(o.DbRecord.ID);
            Assert.IsNull(currency);
            await repository.AddObject(o);
            currency = db.Currencies.Find(o.DbRecord.ID);
            validateCurrency(currency, o.DbRecord);
        }

        [TestMethod]
        public async Task UpdateObjectTest()
        {
            var o = GetRandom.Object<CurrencyObject>();
            await repository.AddObject(o);
            o.DbRecord.Name = GetRandom.String();
            o.DbRecord.Code = GetRandom.String();
            o.DbRecord.ValidFrom = GetRandom.DateTime(null, DateTime.Now.AddYears(-10));
            o.DbRecord.ValidTo = GetRandom.DateTime(DateTime.Now.AddYears(10));
            repository.UpdateObject(o);
            Assert.AreEqual(count + 1, db.Currencies.Count());
            var currency = db.Currencies.Find(o.DbRecord.ID);
            validateCurrency(currency, o.DbRecord);
        }

        [TestMethod]
        public void DeleteObjectTest()
        {
            var c = count;
            Assert.AreEqual(c, db.Currencies.Count());
            foreach (var e in db.Currencies)
            {
                repository.DeleteObject(new CurrencyObject(e));
                Assert.AreEqual(--c, db.Currencies.Count());
            }
        }

        [TestMethod]
        public void IsInitializedTest()
        {
            Assert.IsTrue(repository.IsInitialized());
            TestCleanup();
            Assert.IsFalse(repository.IsInitialized());
        }
    }
}
