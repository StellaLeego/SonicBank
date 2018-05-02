using System.ComponentModel;
using Open.Core;

namespace Open.Facade.Location
{
    public class EmailAddressViewModel : AddressViewModel
    {
        private string emailAddress;

        [DisplayName("Email")]
        public string EmailAddress
        {
            get => getString(ref emailAddress);
            set => emailAddress = value;
        }

        public override string ToString() {
            return EmailAddress;
        }
    }
}
