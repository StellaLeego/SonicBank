using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Location;
using Open.Facade.Money;

namespace Open.Tests.Facade.Money {
    [TestClass]
    public class CurrencyViewModelTests : ViewModelTests<CurrencyViewModel, NamedViewModel> {
        protected override CurrencyViewModel getRandomTestObject() {
            return GetRandom.Object<CurrencyViewModel>();
        }

        [TestMethod]
        public void IsoCurrencySymbolTest() {
            testReadWriteProperty(() => obj.IsoCurrencySymbol, x => obj.IsoCurrencySymbol = x);
        }

        [TestMethod]
        public void CurrencySymbolTest() {
            testReadWriteProperty(() => obj.CurrencySymbol, x => obj.CurrencySymbol = x);
        }

        [TestMethod]
        public void UsedInCountriesTest() {
            Assert.IsInstanceOfType(obj.UsedInCountries, typeof(List<CountryViewModel>));
            var name = GetMember.Name<CurrencyViewModel>(x => x.UsedInCountries);
            Assert.IsTrue(IsReadOnly.Property<CurrencyViewModel>(name));
        }
    }
}