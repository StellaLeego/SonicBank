using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Open.Facade.Project
{
    class CashViewModel : PaymentViewModel
    {
        private string number;
        [Required]
        [RegularExpression(@"^\d+$")]
        public string Amount
        {
            get => getString(ref number);
            set => number = value;
        }
        public override string ToString() { return Amount;}
    }
}
