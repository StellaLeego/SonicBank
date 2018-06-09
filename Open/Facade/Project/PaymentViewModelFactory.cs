using System;
using Open.Domain.Project;

namespace Open.Facade.Project {
    public static class PaymentViewModelFactory {
        public static PaymentViewModel Create(IPaymentObject o) {
            switch (o) {
                case CheckObject check:
                    return create(check);
                case CreditCardObject credit:
                    return create(credit);
                case DebitCardObject debit:
                    return create(debit);
            }

            return create(o as CashObject);
        }

        private static CashViewModel create(CashObject o) {
            var v = new CashViewModel {
                Amount = o?.DbRecord?.Amount,
                Currency = o?.DbRecord?.Currency,
                Memo = o?.DbRecord?.Memo,
                Payee = o?.DbRecord?.Payee,
                PayeeAccountNumber = o?.DbRecord?.PayeeAccountNumber,
                Payer = o?.DbRecord?.Payer,
                PayerAccountNumber = o?.DbRecord?.PayerAccountNumber
            };
            setCommonValues(v, o?.DbRecord.ID, o?.DbRecord?.ValidFrom, o?.DbRecord?.ValidTo);
            return v;
        }

        private static CheckViewModel create(CheckObject o) {
            var v = new CheckViewModel {
                Amount = o?.DbRecord?.Amount,
                Currency = o?.DbRecord?.Currency,
                Memo = o?.DbRecord?.Memo,
                Payee = o?.DbRecord?.Payee,
                PayeeAccountNumber = o?.DbRecord?.PayeeAccountNumber,
                Payer = o?.DbRecord?.Payer,
                PayerAccountNumber = o?.DbRecord?.PayerAccountNumber,
                CheckNumber = o?.DbRecord?.CheckNumber
            };
            setCommonValues(v, o?.DbRecord.ID, o?.DbRecord?.ValidFrom, o?.DbRecord?.ValidTo);
            return v;
        }

        private static DebitCardViewModel create(DebitCardObject o) {
            var v = new DebitCardViewModel {
                Amount = o?.DbRecord?.Amount,
                Currency = o?.DbRecord?.Currency,
                Memo = o?.DbRecord?.Memo,
                Payee = o?.DbRecord?.Payee,
                PayeeAccountNumber = o?.DbRecord?.PayeeAccountNumber,
                Payer = o?.DbRecord?.Payer,
                PayerAccountNumber = o?.DbRecord?.PayerAccountNumber,
                CardAssociationName = o?.DbRecord?.CardAssociationName,
                CardNumber = o?.DbRecord?.CardNumber,
                DailyWithdrawalLimit = o?.DbRecord?.DailyWithDrawalLimit
            };
            setCommonValues(v, o?.DbRecord.ID, o?.DbRecord?.ValidFrom, o?.DbRecord?.ValidTo);
            return v;
        }

        private static CreditCardViewModel create(CreditCardObject o) {
            var v = new CreditCardViewModel {
                Amount = o?.DbRecord?.Amount,
                Currency = o?.DbRecord?.Currency,
                Memo = o?.DbRecord?.Memo,
                Payee = o?.DbRecord?.Payee,
                PayeeAccountNumber = o?.DbRecord?.PayeeAccountNumber,
                Payer = o?.DbRecord?.Payer,
                PayerAccountNumber = o?.DbRecord?.PayerAccountNumber,
                CardAssociationName = o?.DbRecord?.CardAssociationName,
                CardNumber = o?.DbRecord?.CardNumber,
                DailyWithdrawalLimit = o?.DbRecord?.DailyWithDrawalLimit,
                CreditLimit = o?.DbRecord?.CreditLimit
            };
            setCommonValues(v, o?.DbRecord.ID, o?.DbRecord?.ValidFrom, o?.DbRecord?.ValidTo);
            return v;
        }

        private static void setCommonValues(PaymentViewModel model, string id, DateTime? validFrom,
            DateTime? validTo) {
            model.ID = id;
            model.ValidFrom = setNullIfExtremum(validFrom ?? DateTime.MinValue);
            model.ValidTo = setNullIfExtremum(validTo ?? DateTime.MaxValue);
        }

        private static DateTime? setNullIfExtremum(DateTime d) {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
    }
}