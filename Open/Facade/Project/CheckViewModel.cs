using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Open.Facade.Project {
    public class CheckViewModel : PaymentViewModel {
        private string checkNumber;

        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter Number")]
        [DisplayName("Check number")]
        public string CheckNumber {
            get => getString(ref checkNumber);
            set => checkNumber = value;
        }
    }
}