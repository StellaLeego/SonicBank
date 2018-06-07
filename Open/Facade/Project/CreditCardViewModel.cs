using System.ComponentModel;

namespace Open.Facade.Project
{
    public class CreditCardViewModel : DebitCardViewModel
    {
        private string creditLimit;
        [DisplayName("Credit limit")]
        public string CreditLimit
        {
            get => getString(ref creditLimit);
            set => creditLimit = value;
        }
    }
}
