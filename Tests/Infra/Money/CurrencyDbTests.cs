using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Money;
using Open.Infra.Money;

namespace Open.Tests.Infra.Money
{
    [TestClass]
    public class CurrencyDbTests<T> : ClassTests<T>
    {
        protected readonly MoneyDbContext db;
        protected readonly CurrencyObjectsRepository repository;
        protected const int count = 10;

        public CurrencyDbTests()
        {
            var options = new DbContextOptionsBuilder<MoneyDbContext>().UseInMemoryDatabase("TestDb").Options;
            db = new MoneyDbContext(options);
            repository = new CurrencyObjectsRepository(db);
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Assert.AreEqual(0, db.Currencies.Count());
            for (var i = 0; i < count; i++)
            {
                db.Currencies.Add(GetRandom.Object<CurrencyDbRecord>());
                db.SaveChanges();
            }
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
            foreach (var c in db.Currencies)
            {
                db.Remove(c);
                db.SaveChanges();
            }
            Assert.AreEqual(0, db.Currencies.Count());
        }
    }
}
