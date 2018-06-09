namespace Open.Data.Project {
    public class PaymentCardDbRecord : PaymentDbRecord {
        private string cardAssociationName;
        private string cardNumber;
        private string dailyWithDrawalLimit;

        public string DailyWithDrawalLimit {
            get => getString(ref dailyWithDrawalLimit);
            set => dailyWithDrawalLimit = value;
        }

        public string CardNumber {
            get => getString(ref cardNumber);
            set => cardNumber = value;
        }

        public string CardAssociationName {
            get => getString(ref cardAssociationName);
            set => cardAssociationName = value;
        }
    }
}