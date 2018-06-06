using System.ComponentModel;

namespace Open.Facade.Project
{
    public class CheckViewModel : PaymentViewModel
    {
        private string checkNumber;

        [DisplayName("Check number")]
        public string CheckNumber
        {
            get => getString(ref checkNumber);
            set => checkNumber = value;
        }
    }
}
