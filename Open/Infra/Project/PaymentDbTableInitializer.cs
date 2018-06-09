using System;
using System.Linq;
using Open.Data.Project;

namespace Open.Infra.Project {
    public static class PaymentDbTableInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Payments.Any()) return;
            initCashPayments(c);
            initCheckPayments(c);
            initCreditPayments(c);
            initDebitPayments(c);
            c.SaveChanges();
        }


        private static void initCashPayments(SentryDbContext c) {
            add(c,
                new CashDbRecord {
                    Amount = "50",
                    Currency = "EUR",
                    Memo = "Eilse eest",
                    Payer = "Mina",
                    PayerAccountNumber = "EE8023749234973254",
                    Payee = "Sina",
                    PayeeAccountNumber = "EE8023745423954328"
                });
        }

        private static void initCheckPayments(SentryDbContext c) {
            add(c,
                new CheckDbRecord {
                    Amount = "10",
                    Currency = "USD",
                    Memo = "Toit",
                    Payer = "Peeter",
                    PayerAccountNumber = "EE8023749234973254",
                    Payee = "TTÜ raamatukogu",
                    PayeeAccountNumber = "EE0409238075209842"
                });
        }

        private static void initCreditPayments(SentryDbContext c) {
            add(c,
                new CreditCardDbRecord {
                    Amount = "10",
                    Currency = "USD",
                    Memo = "Lilled Liisule",
                    Payer = "Juku",
                    PayerAccountNumber = "EE0409238075209842",
                    Payee = "Mari Lilled OÜ",
                    PayeeAccountNumber = "EE3840238402750273",
                    CardAssociationName = "MasterCard",
                    CardNumber = "5341963232324091",
                    DailyWithDrawalLimit = "500",
                    CreditLimit = "534196"
                });
        }

        private static void initDebitPayments(SentryDbContext c) {
            add(c,
                new DebitCardDbRecord {
                    Amount = "3.70",
                    Currency = "EUR",
                    Memo = "Smuuti Blendrerist",
                    Payer = "Pets",
                    PayerAccountNumber = "EE3840238402750273",
                    Payee = "Blender OÜ",
                    PayeeAccountNumber = "EE3840223422750273",
                    CardAssociationName = "MasterCard",
                    DailyWithDrawalLimit = "500",
                    CardNumber = "5341963232324091"
                });
        }

        private static string add(SentryDbContext c, PaymentDbRecord payment) {
            payment.ID = Guid.NewGuid().ToString();
            c.Payments.Add(payment);
            return payment.ID;
        }
    }
}