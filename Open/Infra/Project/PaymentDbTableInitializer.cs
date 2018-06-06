using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Open.Data.Project;

namespace Open.Infra.Project
{
    public static class PaymentDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Payments.Any()) return;
            initCashPayments(c);
            initCheckPayments(c);
            initCreditPayments(c);
            initDebitPayments(c);
            c.SaveChanges();
        }


        private static void initCashPayments(SentryDbContext c)
        {
            add(c,
                new CashDbRecord
                {
                    Amount = "50",
                    Currency = "EUR",
                    Memo = "Eilse eest",
                    Payer = "Mina",
                    PayerAccountNumber = "420",
                    Payee = "Sina",
                    PayeeAccountNumber = "1234"
                });
        }

        private static void initCheckPayments(SentryDbContext c)
        {
            add(c,
                new CheckDbRecord
                {
                    Amount = "10",
                    Currency = "USD",
                    Memo = "Toit",
                    Payer = "Peeter",
                    PayerAccountNumber = "987654321",
                    Payee = "TTÜ raamatukogu",
                    PayeeAccountNumber = "123456789"
                });
        }

        private static void initCreditPayments(SentryDbContext c)
        {
            add(c,
                new CreditCardDbRecord()
                {
                    Amount = "100000000",
                    Currency = "USD",
                    Memo = "Narkootikumid",
                    Payer = "Pablo",
                    PayerAccountNumber = "321321313",
                    Payee = "Escobar",
                    PayeeAccountNumber = "53452342",
                    CardAssociationName = "MasterCard",
                    CardNumber = "123434534",
                    CreditLimit = "9999999999999"
                });
        }
        private static void initDebitPayments(SentryDbContext c)
        {
            add(c,
                new DebitCardDbRecord()
                {
                    Amount = "100",
                    Currency = "EUR",
                    Memo = "memo",
                    Payer = "payer",
                    PayerAccountNumber = "654645",
                    Payee = "payee",
                    PayeeAccountNumber = "88383",
                    CardAssociationName = "MasterCard",
                    CardNumber = "282382fff"
                });
        }

        private static string add(SentryDbContext c, PaymentDbRecord payment)
        {
            payment.ID = Guid.NewGuid().ToString();
            c.Payments.Add(payment);
            return payment.ID;
        }
    }
}
