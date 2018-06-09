namespace Open.Data.Project {
    public class CreditCardDbRecord : PaymentCardDbRecord {
        private string creditLimit;

        public string CreditLimit {
            get => getString(ref creditLimit);
            set => creditLimit = value;
        }
    }
}