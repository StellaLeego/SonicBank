using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Location;
using Open.Facade.Location;

namespace Open.Tests.Facade.Location
{
    [TestClass]
    public class CountryViewModelsListTests : ObjectTests<CountryViewModelsList>
    {
        protected override CountryViewModelsList getRandomTestObject()
        {
            var l = new PaginatedList<CountryObject>();
            SetRandom.Values(l);
            return new CountryViewModelsList(l);
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new CountryViewModelsList(null));
        }
    }
}
