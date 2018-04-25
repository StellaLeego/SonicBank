using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Core;
using Open.Facade.Common;
using Open.Facade.Location;

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
            get => getString(ref id, Constants.Unspecified);
            set => id = value;
        }

        [Required]
        [DisplayName("Currency Symbol")]
        public string CurrencySymbol
        {
            get => getString(ref code, Constants.Unspecified);
            set => code = value;
        }

        [DisplayName("Used in countries")]
        public List<CountryViewModel> UsedInCountries { get; } = new List<CountryViewModel>();
    }
}
