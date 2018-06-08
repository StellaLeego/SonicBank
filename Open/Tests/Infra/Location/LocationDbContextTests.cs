using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra;

namespace Open.Tests.Infra.Location
{
    [TestClass]
    public class LocationDbContextTests : CountryDbTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(SentryDbContext);
        }
        [TestMethod]
        public void CountriesTest()
        {
            Assert.IsNotNull(db.Countries);
        }
    }
}
