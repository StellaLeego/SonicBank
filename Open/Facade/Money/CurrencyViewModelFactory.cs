﻿using System;
using Open.Domain.Money;

namespace Open.Facade.Money
{
    public static class CurrencyViewModelFactory
    {
        public static CurrencyViewModel Create(CurrencyObject o)
        {
            var v = new CurrencyViewModel
            {
                Name = o?.DbRecord.Name,
                IsoCurrencySymbol = o?.DbRecord.ID,
                CurrencySymbol = o?.DbRecord.Code
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.DbRecord.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.DbRecord.ValidTo);
            return v;
        }

        private static DateTime? setNullIfExtremum(DateTime d)
        {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
    }
}
