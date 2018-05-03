using Open.Data.Project;
using Open.Domain.Common;

namespace Open.Domain.Project
{
    public abstract class PaymentMethodObject<T> : UniqueObject<T>, IPaymentMethodObject where T : PaymentMethodDbRecord, new()
    {
        protected PaymentMethodObject(T r) : base(r) { }
    }
}
