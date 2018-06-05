using System.Collections.Generic;
using Open.Core;
using Open.Data.Project;

namespace Open.Domain.Project
{
    public class PaymentObjectsList : PaginatedList<IPaymentObject>
    {
        public PaymentObjectsList(IEnumerable<PaymentDbRecord> items,
            RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(PaymentObjectFactory.Create(dbRecord));
            }
        }
    }
}
