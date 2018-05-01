using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;

namespace Open.Tests.Domain.Location
{
    [TestClass] public class TelecomDeviceRegistrationObjectsListTests : DomainObjectsListTests<TelecomDeviceRegistationObjectsList, TelecomDeviceRegistrationObject>
    {
        protected override TelecomDeviceRegistationObjectsList getRandomTestObject() {
            createWithNullArgs = new TelecomDeviceRegistationObjectsList(null, null);
            var l = GetRandom.Object<List<TelecomDeviceRegistrationDbRecord>>();
            return new TelecomDeviceRegistationObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}
