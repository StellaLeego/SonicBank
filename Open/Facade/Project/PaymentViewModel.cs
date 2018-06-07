using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Facade.Common;

namespace Open.Facade.Project
{
    public abstract class PaymentViewModel : UniqueEntityViewModel
    {
        private string payer;
        private string payerAccountNumber;
        private string payee;
        private string payeeAccountNumber;
        private string amount;
        private string currency;
        private string memo;

        [DisplayName("Payment type")]
        public string PaymentType
        {
            get
            {
                var name = GetType().Name;
                var suffix = "ViewModel";
                var idx = name.IndexOf(suffix, StringComparison.Ordinal);
                if (idx >= 0) name = name.Substring(0, idx);
                return name;
            }
        }

        [DisplayName("Payer")]
        public string Payer
        {
            get => getString(ref payer);
            set => payer = value;
        }

        [DisplayName("Payers account number")]
        public string PayerAccountNumber
        {
            get => getString(ref payerAccountNumber);
            set => payerAccountNumber = value;
        }

        [DisplayName("Payee")]
        public string Payee
        {
            get => getString(ref payee);
            set => payee = value;
        }

        [DisplayName("Payees account number")]
        public string PayeeAccountNumber
        {
            get => getString(ref payeeAccountNumber);
            set => payeeAccountNumber = value;
        }

        [DisplayName("Amount")]
        public string Amount
        {
            get => getString(ref amount);
            set => amount = value;
        }

        [DisplayName("Currency")]
        public string Currency
        {
            get => getString(ref currency);
            set => currency = value;
        }

        [DisplayName("Memo")]
        public string Memo
        {
            get => getString(ref memo);
            set => memo = value;
        }

    }
}
