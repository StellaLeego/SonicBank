using System;
using Open.Data.Project;

namespace Open.Domain.Project
{
    public static class PaymentObjectFactory
    {
        public static IPaymentObject Create(PaymentDbRecord dbRecord)
        {
            switch (dbRecord)
            {
                case DebitCardDbRecord debit:
                    return create(debit);
                case CreditCardDbRecord credit:
                    return create(credit);
                case CheckDbRecord check:
                    return create(check);
            }

            return create(dbRecord as CashDbRecord);
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

        private static CashObject create(CashDbRecord dbRecord)
        {
            return new CashObject(dbRecord);
        }

        public static DebitCardObject CreateDebit(
            string id, string amount, string currency, string memo,
            string payer, string payerAccountNumber,
            string cardAssociationName, string cardNumber,
            string dailyWithDrawalLimit, string payee, string payeeAccountNumber,
            DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new DebitCardDbRecord
            {
                ID = id,
                Amount = amount,
                Currency = currency,
                Memo = memo,
                Payee = payee,
                PayeeAccountNumber = payeeAccountNumber,
                Payer = payer,
                PayerAccountNumber = payerAccountNumber,
                CardAssociationName = cardAssociationName,
                CardNumber = cardNumber,
                DailyWithDrawalLimit = dailyWithDrawalLimit,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new DebitCardObject(r);
        }

        public static CreditCardObject CreateCredit(
            string id, string amount, string currency, string memo,
            string payer, string payerAccountNumber,
            string cardAssociationName, string cardNumber, 
            string dailyWithDrawalLimit, string payee, string payeeAccountNumber,
            string creditLimit, DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new CreditCardDbRecord
            {
                ID = id,
                Amount = amount,
                Currency = currency,
                Memo = memo,
                Payee = payee,
                PayeeAccountNumber = payeeAccountNumber,
                Payer = payer,
                PayerAccountNumber = payerAccountNumber,
                CardAssociationName = cardAssociationName,
                CardNumber = cardNumber,
                DailyWithDrawalLimit = dailyWithDrawalLimit,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue,
                CreditLimit = creditLimit
            };
            return new CreditCardObject(r);
        }

        public static CheckObject CreateCheck(
            string id, string amount, string currency, string memo, string payer,
            string payerAccountNumber, string payee, string payeeAccountNumber,
            string checkNumber, DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new CheckDbRecord
            {
                ID = id,
                Amount = amount,
                CheckNumber = checkNumber,
                Currency = currency,
                Memo = memo,
                Payer = payer,
                Payee = payee,
                PayerAccountNumber = payerAccountNumber,
                PayeeAccountNumber = payeeAccountNumber,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new CheckObject(r);
        }

        public static CashObject CreateCash(string id, string amount, 
            string currency, string memo, string payer, string payee,
            DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new CashDbRecord
            {
                ID = id,
                Amount = amount,
                Currency = currency,
                Memo = memo,
                Payer = payer,
                Payee = payee,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new CashObject(r);
        }
    }
}
