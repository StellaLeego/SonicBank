using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Open.Facade.Project
{
    public class CreditCardViewModel : DebitCardViewModel
    {
        private string creditLimit;

        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter Number")]
        [DisplayName("Credit limit")]
        public string CreditLimit
        {
            get => getString(ref creditLimit);
            set => creditLimit = value;
        }
    }
}
