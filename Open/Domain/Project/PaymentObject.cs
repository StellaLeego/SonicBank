using Open.Data.Project;
using Open.Domain.Common;

namespace Open.Domain.Project
{
    public abstract class PaymentObject<T> : UniqueObject<T>, IPaymentObject where T : PaymentDbRecord, new()
    {
        protected PaymentObject(T r) : base(r) { }
    }
}
