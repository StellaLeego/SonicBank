using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Money;

namespace Open.Tests.Infra.Money
{
    [TestClass]
    public class CurrencyDbContextTests : CurrencyDbTests<MoneyDbContext>
    {
        public void CurrenciesTest()
        {
            Assert.IsNotNull(db.Currencies);
        }
    }
}
