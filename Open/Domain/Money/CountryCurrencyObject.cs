using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Money;
using Open.Domain.Common;
using Open.Domain.Location;

namespace Open.Domain.Money
{
    public class CountryCurrencyObject : TemporalObject<CountryCurrencyDbRecord>
    {
        public readonly CountryObject Country;
        public readonly CurrencyObject Currency;

        public CountryCurrencyObject(CountryCurrencyDbRecord dbRecord) : base(dbRecord) {
            Country = new CountryObject(DbRecord.Country);
            Currency = new CurrencyObject(DbRecord.Currency);
        }
    }
}
