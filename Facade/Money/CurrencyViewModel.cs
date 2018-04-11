using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Core;
using Open.Facade.Common;

namespace Open.Facade.Money
{
    public class CurrencyViewModel : NamedViewModel
    {
        private string id;
        private string code;

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(RegularExpressionFor.EnglishCapitalsOnly)]
        [DisplayName("ISO Currency Code")]
        public string IsoCurrencySymbol
        {
            get => getValue(ref id, Constants.Unspecified);
            set => id = value;
        }

        [Required]
        [DisplayName("Currency Symbol")]
        public string CurrencySymbol
        {
            get => getValue(ref code, Constants.Unspecified);
            set => code = value;
        }
    }
}
