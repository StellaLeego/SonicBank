using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            type = typeof(MoneyDbContext);
        }

        public void CurrenciesTest()
        {
            Assert.IsNotNull(db.Currencies);
        }
    }
}
