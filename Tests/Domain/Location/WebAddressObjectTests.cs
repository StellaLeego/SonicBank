using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;

namespace Open.Tests.Domain.Location
{
    [TestClass]
    public class WebAddressObjectTests : DomainObjectsTests<WebAddressObject, WebAddressDbRecord>
    {
        protected override WebAddressObject getRandomTestObject()
        {
            createdWithNullArg = new WebAddressObject(null);
            dbRecordType = typeof(WebAddressDbRecord);
            return GetRandom.Object<WebAddressObject>();
        }
    }
}
