using Open.Data.Project;

namespace Open.Domain.Project {
    public sealed class DebitCardObject : PaymentCardObject<DebitCardDbRecord> {
        public DebitCardObject(DebitCardDbRecord db) : base(db ?? new DebitCardDbRecord()) { }
    }
}