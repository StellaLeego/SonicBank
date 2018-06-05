using Open.Data.Project;

namespace Open.Domain.Project
{
    public sealed class CheckObject : PaymentObject<CheckDbRecord>
    {
        public CheckObject(CheckDbRecord db) : base(db ?? new CheckDbRecord()) { }
    }
}
