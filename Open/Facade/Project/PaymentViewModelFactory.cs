using Open.Domain.Project;

namespace Open.Facade.Project
{
    public static class PaymentViewModelFactory
    {
        public static PaymentViewModel Create(IPaymentObject o)
        {
            switch (o)
            {
                case CheckObject check:
                    return create(check);
                case CreditCardObject credit:
                    return create(credit);
                case DebitCardObject debit:
                    return create(debit);
            }

            return create(o as CashObject);
        }

        private static CheckViewModel create(CheckObject o)
        {
            var v = new CheckViewModel
            {
                
            }
        }
    }
}
