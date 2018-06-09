using Open.Data.Project;

namespace Open.Domain.Project {
    public sealed class CreditCardObject : PaymentCardObject<CreditCardDbRecord> {
        public CreditCardObject(CreditCardDbRecord db) : base(db ?? new CreditCardDbRecord()) { }
    }
}