﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Core;

namespace Open.Facade.Location
{
    public class EmailAddressViewModel : AddressViewModel
    {
        private string emailAddress;

        [Required]
        [DisplayName("Email")]
        [RegularExpression(@"(?!.*\.\.)(^[^\.][^@\s]+@[^@\s]+\.[^@\s\.]+$)")]
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
