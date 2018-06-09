using Open.Data.Project;

namespace Open.Domain.Project {
    public sealed class CashObject : PaymentObject<CashDbRecord> {
        public CashObject(CashDbRecord db) : base(db ?? new CashDbRecord()) { }
    }
}