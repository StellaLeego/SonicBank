using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra;
using Open.Infra.Money;

namespace Open.Tests.Infra.Money
{
    [TestClass]
    public class MoneyDbContextTests : CurrencyDbTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(SentryDbContext);
        }

        public void CurrenciesTest()
        {
            Assert.IsNotNull(db.Currencies);
        }
    }
}
