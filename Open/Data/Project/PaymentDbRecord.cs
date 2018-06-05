using Open.Data.Common;

namespace Open.Data.Project
{
    public class PaymentDbRecord : UniqueDbRecord
    {
        private string payer;
        private string payee;
        private string amount;
        private string currency;
        private string payerAccountNumber;
        private string payeeAccountNumber;
        private string memo;

        public string Payer
        {
            get => getString(ref payer);
            set => payer = value;
        }
        public string Payee
        {
            get => getString(ref payee);
            set => payee = value;
        }
        public string Amount
        {
            get => getString(ref amount);
            set => amount = value;
        }

        public string Currency
        {
            get => getString(ref currency);
            set => currency = value;
        }
        public string PayerAccountNumber
        {
            get => getString(ref payerAccountNumber);
            set => payerAccountNumber = value;
        }
        public string PayeeAccountNumber
        {
            get => getString(ref payeeAccountNumber);
            set => payeeAccountNumber = value;
        }
        public string Memo
        {
            get => getString(ref memo);
            set => memo = value;
        }
    }
}
