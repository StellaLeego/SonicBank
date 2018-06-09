using Open.Core;
using Open.Domain.Project;

namespace Open.Facade.Project {
    public class PaymentViewModelsList : PaginatedList<PaymentViewModel> {
        public PaymentViewModelsList(IPaginatedList<IPaymentObject> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) Add(PaymentViewModelFactory.Create(e));
        }
    }
}