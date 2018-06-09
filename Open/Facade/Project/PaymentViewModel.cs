using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Aids;
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

        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Name cant be less than 4 characters and longer than 30 characters")]
        [DisplayName("Payer")]
        public string Payer
        {
            get => getString(ref payer);
            set => payer = value;
        }

        [Required]
        [DisplayName("Payers account number")]
        public string PayerAccountNumber
        {
            get => getString(ref payerAccountNumber);
            set => payerAccountNumber = value;
        }
        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Name cant be less than 4 characters and longer than 30 characters")]
        [DisplayName("Payee")]
        public string Payee
        {
            get => getString(ref payee);
            set => payee = value;
        }

        [Required]
        [DisplayName("Payees account number")]
        public string PayeeAccountNumber
        {
            get => getString(ref payeeAccountNumber);
            set => payeeAccountNumber = value;
        }
        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Invalid Target Price, Maximum Two Decimal Points")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Target Price, Max 18 digits")]
        [DisplayName("Amount")]
        public string Amount
        {
            get => getString(ref amount);
            set => amount = value;
        }
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(RegularExpressionFor.EnglishCapitalsOnly)]
        [DisplayName("Currency")]
        public string Currency
        {
            get => getString(ref currency);
            set => currency = value;
        }
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Memo cant be less than 1 characters and longer than 30 characters")]
        [DisplayName("Memo")]
        public string Memo
        {
            get => getString(ref memo);
            set => memo = value;
        }

    }
}
