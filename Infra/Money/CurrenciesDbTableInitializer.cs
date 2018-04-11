using System.Collections.Generic;
using Open.Aids;
using Open.Domain.Money;

namespace Open.Infra.Money
{
    public static class CurrenciesDbTableInitializer
    {
        public static void Initialize(ICurrencyObjectsRepository c)
        {
            if (c.IsInitialized()) return;

            var regions = SystemRegionInfo.GetRegionsList();
            var l = new List<string>();
            foreach (var r in regions)
            {
                if (!SystemRegionInfo.IsCurrency(r)) continue;
                var e = CurrencyObjectFactory.Create(r);
                if (l.Contains(e.DbRecord.ID)) continue;
                c.AddObject(e);
                l.Add(e.DbRecord.ID);
            }
        }
    }
}
