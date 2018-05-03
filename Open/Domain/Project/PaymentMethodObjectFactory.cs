using System;
using Open.Data.Project;

namespace Open.Domain.Project
{
    public static class PaymentMethodObjectFactory
    {
        public static IPaymentMethodObject Create(PaymentMethodDbRecord dbRecord)
        {
            switch (dbRecord)
            {
                case DebitCardDbRecord debitCard:
                    return create(debitCard);
                case CreditCardDbRecord creditCard:
                    return create(creditCard);
                case CheckDbRecord check:
                    return create(check);
            }

            return create(dbRecord as PaymentMethodDbRecord);
        }

        private static DebitCardObject create(DebitCardDbRecord dbRecord)
        {
            return new DebitCardObject(dbRecord);
        }

        private static CreditCardObject create(CreditCardDbRecord dbRecord)
        {
            return new CreditCardObject(dbRecord);
        }

        private static CheckObject create(CheckDbRecord dbRecord)
        {
            return new CheckObject(dbRecord);
        }

        public static DebitCardObject CreateDebit(string id, string accountName,
            string accountNumber, string bankAddress, string bankName, 
            string cardVerificationCode, decimal dailyWithDrawalLimit,
            string paymentTypeNumber, DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new DebitCardDbRecord
            {
                ID = id,
                AccountName = accountName,
                AccountNumber = accountNumber,
                BankAddress = bankAddress,
                BankName = bankName,
                CardVerificationCode = cardVerificationCode,
                DailyWithDrawalLimit = dailyWithDrawalLimit,
                PaymentTypeNumber = paymentTypeNumber,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new DebitCardObject(r);
        }

        public static CreditCardObject CreateCredit(string id, string accountName,
            string accountNumber, string bankAddress, string bankName,
            string cardVerificationCode, decimal creditLimit, decimal dailyWithDrawalLimit,
            string paymentTypeNumber, DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new CreditCardDbRecord
            {
                ID = id,
                AccountName = accountName,
                AccountNumber = accountNumber,
                BankAddress = bankAddress,
                BankName = bankName,
                CardVerificationCode = cardVerificationCode,
                CreditLimit = creditLimit,
                DailyWithDrawalLimit = dailyWithDrawalLimit,
                PaymentTypeNumber = paymentTypeNumber,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new CreditCardObject(r);
        }

        public static CheckObject CreateCheck(string id, string accountName,
            string accountNumber, string bankAddress, string bankIdentificationNumber,
            string bankName, string cardVerificationCode, decimal dailyWithDrawalLimit,
            string paymentTypeNumber, DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new CheckDbRecord
            {
                ID = id,
                AccountName = accountName,
                AccountNumber = accountNumber,
                BankAddress = bankAddress,
                BankIdentificationNumber = bankIdentificationNumber,
                BankName = bankName,
                CardVerificationCode = cardVerificationCode,
                DailyWithDrawalLimit = dailyWithDrawalLimit,
                PaymentTypeNumber = paymentTypeNumber,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new CheckObject(r);
        }
    }
}
