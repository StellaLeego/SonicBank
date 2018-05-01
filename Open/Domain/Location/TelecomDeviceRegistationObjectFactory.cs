﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Location;

namespace Open.Domain.Location
{
    public static class TelecomDeviceRegistationObjectFactory
    {
        public static TelecomDeviceRegistrationObject Create(GeographicAddressObject address,
            TelecomAddressObject device, DateTime? validFrom = null, DateTime? validTo = null) {
            var o = new TelecomDeviceRegistrationDbRecord {
                Address = address?.DbRecord,
                Device = device?.DbRecord,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            o.AddressID = o.Address.ID;
            o.DeviceID = o.Device.ID;
            return  new TelecomDeviceRegistrationObject(o);
        }
    }
}
