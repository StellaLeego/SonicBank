using System;
using Open.Data.Common;

namespace Open.Data.Project
{
    public class PaymentMethodDbRecord : UniqueDbRecord
    {
        private decimal dailyWithDrawalLimit;
        private string paymentTypeNumber;
        private string bankName;
        private string accountName;
        private string bankAddress;
        private string accountNumber;
        private string cardVerificationCode;

        public decimal DailyWithDrawalLimit
        {
            get => getDecimal(ref dailyWithDrawalLimit);
            set => dailyWithDrawalLimit = value;
        }

        public string PaymentTypeNumber
        {
            get => getString(ref paymentTypeNumber);
            set => paymentTypeNumber = value;
        }

        public string BankName
        {
            get => getString(ref bankName);
            set => bankName = value;
        }

        public string AccountName
        {
            get => getString(ref accountName);
            set => accountName = value;
        }

        public string BankAddress
        {
            get => getString(ref bankAddress);
            set => bankAddress = value;
        }

        public string AccountNumber
        {
            get => getString(ref accountNumber);
            set => accountNumber = value;
        }

        public string CardVerificationCode
        {
            get => getString(ref cardVerificationCode);
            set => cardVerificationCode = value;
        }
    }
}
