﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Money;
using Open.Domain.Location;

namespace Open.Domain.Money
{
    public static class CountryCurrencyObjectFactory
    {
        public static CountryCurrencyObject Create(CountryObject country, CurrencyObject currency,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var o = new CountryCurrencyDbRecord {
                Country = country?.DbRecord,
                Currency = currency?.DbRecord,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            o.CountryID = o.Country.ID;
            o.CurrencyID = o.Currency.ID;
            return new CountryCurrencyObject(o);
        }
    }
}
