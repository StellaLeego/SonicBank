using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;

namespace Open.Tests.Domain.Location
{
    [TestClass]
    public class GeographicAddressObjectTests : DomainObjectsTests<GeographicAddressObject, GeographicAddressDbRecord>
    {
        protected override GeographicAddressObject getRandomTestObject()
        {
            createdWithNullArg = new GeographicAddressObject(null);
            dbRecordType = typeof(GeographicAddressDbRecord);
            return GetRandom.Object<GeographicAddressObject>();
        }
    }
}
