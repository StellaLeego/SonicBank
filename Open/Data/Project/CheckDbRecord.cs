namespace Open.Data.Project
{
    public class CheckDbRecord : PaymentMethodDbRecord
    {
        private string bankIdentificationNumber;

        public string BankIdentificationNumber
        {
            get => getString(ref bankIdentificationNumber);
            set => bankIdentificationNumber = value;
        }
    }
}
