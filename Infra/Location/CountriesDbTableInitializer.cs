﻿using Open.Aids;
using Open.Domain.Location;

namespace Open.Infra.Location
{
    public static class CountriesDbTableInitializer
    {
        public static void Initialize(ICountryObjectsRepository c)
        {
            if (c.IsInitialized()) return;

            var regions = SystemRegionInfo.GetRegionsList();

            foreach (var r in regions)
            {
                if (!SystemRegionInfo.IsCountry(r)) continue;
                var e = CountryObjectFactory.Create(r);
                c.AddObject(e);
            }

        }
    }
}
