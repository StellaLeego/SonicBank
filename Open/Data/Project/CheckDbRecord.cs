using System;

namespace Open.Data.Project
{
    public class CheckDbRecord : PaymentDbRecord
    {
        private string checkNumber;

        public string CheckNumber
        {
            get => getString(ref checkNumber);
            set => checkNumber = value;
        }
    }
}
