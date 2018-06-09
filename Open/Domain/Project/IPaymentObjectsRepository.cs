using System.Threading.Tasks;
using Open.Core;
using Open.Data.Project;

namespace Open.Domain.Project {
    public interface IPaymentObjectsRepository : IObjectsRepository<IPaymentObject, PaymentDbRecord> {
        Task<PaginatedList<IPaymentObject>> GetObjectsList();
    }
}