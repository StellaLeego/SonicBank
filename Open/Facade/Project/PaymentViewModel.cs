using System;
using System.ComponentModel;
using Open.Facade.Common;

namespace Open.Facade.Project
{
    public abstract class PaymentViewModel : UniqueEntityViewModel
    {
        [DisplayName("Payment type")]
        public string PaymentType
        {
            get
            {
                var name = GetType().Name;
                var suffix = typeof(PaymentViewModel).Name;
                var idx = name.IndexOf(suffix, StringComparison.Ordinal);
                if (idx >= 0) name = name.Substring(0, idx);
                return name;
            }
        }
    }
}
