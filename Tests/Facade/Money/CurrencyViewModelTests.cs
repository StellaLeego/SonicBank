using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Money;

namespace Open.Tests.Facade.Money
{
    [TestClass]
    public class CurrencyViewModelTests : ViewModelTests<CurrencyViewModel, NamedViewModel>
    {
        protected override CurrencyViewModel getRandomTestObject()
        {
            return GetRandom.Object<CurrencyViewModel>();
        }

        [TestMethod]
        public void IsoCodeTest()
        {
            testReadWriteProperty(() => obj.IsoCurrencySymbol, x => obj.IsoCurrencySymbol = x);
        }

        [TestMethod]
        public void SymbolTest()
        {
            testReadWriteProperty(() => obj.CurrencySymbol, x => obj.CurrencySymbol = x);
        }
    }
}
