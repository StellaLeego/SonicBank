using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Open.Facade.Project
{
    public class DebitCardViewModel : PaymentViewModel
    {
        private string dailyWithdrawalLimit;
        private string cardNumber;
        private string cardAssociationName;

        [Required, CreditCard]
        [DisplayName("Card number")]
        public string CardNumber
        {
            get => getString(ref cardNumber);
            set => cardNumber = value;
        }
        [Required]
        [DisplayName("Card association name")]
        public string CardAssociationName
        {
            get => getString(ref cardAssociationName);
            set => cardAssociationName = value;
        }
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter Number")]
        [DisplayName("Daily withdrawal limit")]
        public string DailyWithdrawalLimit
        {
            get => getString(ref dailyWithdrawalLimit);
            set => dailyWithdrawalLimit = value;
        }
    }
}
