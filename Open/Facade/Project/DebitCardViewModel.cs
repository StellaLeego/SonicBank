using System.ComponentModel;

namespace Open.Facade.Project
{
    public class DebitCardViewModel : PaymentViewModel
    {
        private string dailyWithdrawalLimit;
        private string cardNumber;
        private string cardAssociationName;

        [DisplayName("Card number")]
        public string CardNumber
        {
            get => getString(ref cardNumber);
            set => cardNumber = value;
        }
        [DisplayName("Card association name")]
        public string CardAssociationName
        {
            get => getString(ref cardAssociationName);
            set => cardAssociationName = value;
        }

        [DisplayName("Daily withdrawal limit")]
        public string DailyWithdrawalLimit
        {
            get => getString(ref dailyWithdrawalLimit);
            set => dailyWithdrawalLimit = value;
        }
    }
}
