using Open.Core;
using Open.Data.Location;
using System.Collections.Generic;

namespace Open.Domain.Location
{
    public class CountryObjectsList : PaginatedList<CountryObject>
    {
        public CountryObjectsList(IEnumerable<CountryDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new CountryObject(dbRecord));
            }
        }
    }
}
