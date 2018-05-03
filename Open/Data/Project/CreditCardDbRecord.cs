using System;

namespace Open.Data.Project
{
    public class CreditCardDbRecord : PaymentMethodDbRecord
    {
        private decimal creditLimit;

        public decimal CreditLimit
        {
            get => getDecimal(ref creditLimit);
            set => creditLimit = value;
        }
    }
}
