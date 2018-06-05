using Open.Data.Project;

namespace Open.Domain.Project
{
    public abstract class PaymentCardObject<T> : PaymentObject<T>, IPaymentCardObject where T : PaymentCardDbRecord, new()
    {
        protected PaymentCardObject(T r) : base(r) { }
    }
}
