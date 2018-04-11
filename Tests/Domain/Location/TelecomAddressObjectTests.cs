using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;

namespace Open.Tests.Domain.Location
{
    [TestClass]
    public class TelecomAddressObjectTests : DomainObjectsTests<TelecomAddressObject, TelecomAddressDbRecord>
    {
        protected override TelecomAddressObject getRandomTestObject()
        {
            createdWithNullArg = new TelecomAddressObject(null);
            dbRecordType = typeof(TelecomAddressDbRecord);
            return GetRandom.Object<TelecomAddressObject>();
        }
    }
}
