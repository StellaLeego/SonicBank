using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Project;
using Open.Domain.Project;
using Open.Facade.Project;

namespace Sentry.Controllers {
    public class PaymentsController : Controller {
        internal const string cashProperties = "ID, Payer, Payee, Amount, Currency, Memo, ValidFrom, ValidTo";

        internal const string checkProperties =
            "ID, Payer, Payee, Amount, Currency, Memo, PayerAccountNumber, PayeeAccountNumber, CheckNumber, ValidFrom, ValidTo";

        internal const string debitProperties =
            "ID, Payer, Payee, Amount, Currency, Memo, PayerAccountNumber, PayeeAccountNumber, DailyWithDrawalLimit, CardNumber, CardAssociationName, ValidFrom, ValidTo";

        internal const string creditProperties =
            "ID, Payer, Payee, Amount, Currency, Memo, PayerAccountNumber, PayeeAccountNumber, DailyWithDrawalLimit, CardNumber, CardAssociationName, CreditLimit, ValidFrom, ValidTo";

        private readonly IPaymentObjectsRepository payments;

        public PaymentsController(IPaymentObjectsRepository r) {
            payments = r;
        }

        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortPaymentsType"] = string.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewData["SortToString"] = sortOrder == "string" ? "string_desc" : "string";
            ViewData["SortValidFrom"] = sortOrder == "validFrom" ? "validFrom_desc" : "validFrom";
            ViewData["SortValidTo"] = sortOrder == "validTo" ? "validTo_desc" : "validTo";
            ViewData["SortPayer"] = sortOrder == "payer" ? "payer_desc" : "payer";
            ViewData["SortAmount"] = sortOrder == "amount" ? "amount_desc" : "amount";
            ViewData["SortCurrency"] = sortOrder == "currency" ? "currency_desc" : "currency";
            ViewData["SortPayee"] = sortOrder == "payee" ? "payee_desc" : "payee";
            ViewData["SortMemo"] = sortOrder == "memo" ? "memo_desc" : "memo";
            payments.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            payments.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            payments.SearchString = searchString;
            payments.PageIndex = page ?? 1;
            var l = await payments.GetObjectsList();
            return View(new PaymentViewModelsList(l));
        }

        private Func<PaymentDbRecord, object> getSortFunction(string sortOrder) {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.GetType().Name;
            if (sortOrder.StartsWith("type")) return x => x.GetType().Name;
            if (sortOrder.StartsWith("payer")) return x => x.Payer;
            if (sortOrder.StartsWith("amount")) return x => x.Amount;
            if (sortOrder.StartsWith("currency")) return x => x.Currency;
            if (sortOrder.StartsWith("memo")) return x => x.Memo;
            if (sortOrder.StartsWith("payee")) return x => x.Payee;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            return x => x.ValidFrom;
        }

        public async Task<IActionResult> Delete(string id) {
            var c = await payments.GetObject(id);
            switch (c) {
                case CashObject cash:
                    return View("DeleteCash",
                        PaymentViewModelFactory.Create(cash) as CashViewModel);
                case CheckObject check:
                    return View("DeleteCheck",
                        PaymentViewModelFactory.Create(check) as CheckViewModel);
                case DebitCardObject debit:
                    return View("DeleteDebitCard",
                        PaymentViewModelFactory.Create(debit) as DebitCardViewModel);
                case CreditCardObject credit:
                    return View("DeleteCreditCard",
                        PaymentViewModelFactory.Create(credit) as CreditCardViewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            var c = await payments.GetObject(id);
            await payments.DeleteObject(c);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id) {
            var payment = await payments.GetObject(id);
            switch (payment) {
                case CashObject _: return RedirectToAction("EditCash", new {id});
                case CheckObject _: return RedirectToAction("EditCheck", new {id});
                case CreditCardObject _: return RedirectToAction("EditCreditCard", new {id});
                default: return RedirectToAction("EditDebitCard", new {id});
            }
        }

        public async Task<IActionResult> EditCash(string id) {
            var payment = await payments.GetObject(id);
            return View(PaymentViewModelFactory.Create(payment) as CashViewModel);
        }

        public async Task<IActionResult> EditCheck(string id) {
            var payment = await payments.GetObject(id);
            return View(PaymentViewModelFactory.Create(payment) as CheckViewModel);
        }

        public async Task<IActionResult> EditCreditCard(string id) {
            var payment = await payments.GetObject(id);
            return View(PaymentViewModelFactory.Create(payment) as CreditCardViewModel);
        }

        public async Task<IActionResult> EditDebitCard(string id) {
            var payment = await payments.GetObject(id);
            return View(PaymentViewModelFactory.Create(payment) as DebitCardViewModel);
        }

        public async Task<IActionResult> Details(string id) {
            var c = await payments.GetObject(id);

            switch (c) {
                case CashObject cash:
                    return View("DetailsCash",
                        PaymentViewModelFactory.Create(cash) as CashViewModel);
                case CheckObject check:
                    return View("DetailsCheck",
                        PaymentViewModelFactory.Create(check) as CheckViewModel);
                case DebitCardObject debit:
                    return View("DetailsDebitCard",
                        PaymentViewModelFactory.Create(debit) as DebitCardViewModel);
                case CreditCardObject credit:
                    return View("DetailsCreditCard",
                        PaymentViewModelFactory.Create(credit) as CreditCardViewModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult CreateCash() {
            return View("CreateCash", new CashViewModel());
        }

        public IActionResult CreateCheck() {
            return View("CreateCheck", new CheckViewModel());
        }

        public IActionResult CreateCreditCard() {
            return View("CreateCreditCard", new CreditCardViewModel());
        }

        public IActionResult CreateDebitCard() {
            return View("CreateDebitCard", new DebitCardViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
            CreateCash([Bind(cashProperties)] CashViewModel c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = PaymentObjectFactory.CreateCash(c.ID, c.Amount, c.Currency, c.Memo, c.Payer,
                c.Payee, c.ValidFrom, c.ValidTo);
            await payments.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCash([Bind(cashProperties)] CashViewModel c) {
            if (!ModelState.IsValid) return View("EditCash", c);
            var o = await payments.GetObject(c.ID) as CashObject;
            o.DbRecord.Payer = c.Payer;
            o.DbRecord.Payee = c.Payee;
            o.DbRecord.Amount = c.Amount;
            o.DbRecord.Currency = c.Currency;
            o.DbRecord.Memo = c.Memo;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await payments.UpdateObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
            CreateCheck([Bind(checkProperties)] CheckViewModel c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = PaymentObjectFactory.CreateCheck(c.ID, c.Amount, c.Currency, c.Memo, c.Payer, c.PayerAccountNumber,
                c.Payee, c.PayeeAccountNumber, c.CheckNumber, c.ValidFrom, c.ValidTo);
            await payments.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCheck([Bind(checkProperties)] CheckViewModel c) {
            if (!ModelState.IsValid) return View("EditCheck", c);
            var o = await payments.GetObject(c.ID) as CheckObject;
            o.DbRecord.Payer = c.Payer;
            o.DbRecord.PayerAccountNumber = c.PayerAccountNumber;
            o.DbRecord.Payee = c.Payee;
            o.DbRecord.PayeeAccountNumber = c.PayeeAccountNumber;
            o.DbRecord.Amount = c.Amount;
            o.DbRecord.Currency = c.Currency;
            o.DbRecord.CheckNumber = c.CheckNumber;
            o.DbRecord.Memo = c.Memo;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await payments.UpdateObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
            CreateDebitCard([Bind(debitProperties)] DebitCardViewModel c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = PaymentObjectFactory.CreateDebit(c.ID, c.Amount, c.Currency, c.Memo, c.Payer, c.PayerAccountNumber,
                c.CardAssociationName, c.CardNumber, c.DailyWithdrawalLimit, c.Payee, c.PayeeAccountNumber, c.ValidFrom,
                c.ValidTo);
            await payments.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDebitCard([Bind(debitProperties)] DebitCardViewModel c) {
            if (!ModelState.IsValid) return View("EditDebitCard", c);
            var o = await payments.GetObject(c.ID) as DebitCardObject;
            o.DbRecord.Payer = c.Payer;
            o.DbRecord.PayerAccountNumber = c.PayerAccountNumber;
            o.DbRecord.Payee = c.Payee;
            o.DbRecord.PayeeAccountNumber = c.PayeeAccountNumber;
            o.DbRecord.Amount = c.Amount;
            o.DbRecord.Currency = c.Currency;
            o.DbRecord.CardAssociationName = c.CardAssociationName;
            o.DbRecord.CardNumber = c.CardNumber;
            o.DbRecord.DailyWithDrawalLimit = c.DailyWithdrawalLimit;
            o.DbRecord.Memo = c.Memo;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await payments.UpdateObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
            CreateCreditCard([Bind(creditProperties)] CreditCardViewModel c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = PaymentObjectFactory.CreateCredit(c.ID, c.Amount, c.Currency, c.Memo, c.Payer, c.PayerAccountNumber,
                c.CardAssociationName, c.CardNumber, c.DailyWithdrawalLimit, c.Payee, c.PayeeAccountNumber,
                c.CreditLimit, c.ValidFrom, c.ValidTo);
            await payments.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCreditCard([Bind(creditProperties)] CreditCardViewModel c) {
            if (!ModelState.IsValid) return View("EditCreditCard", c);
            var o = await payments.GetObject(c.ID) as CreditCardObject;
            o.DbRecord.Payer = c.Payer;
            o.DbRecord.PayerAccountNumber = c.PayerAccountNumber;
            o.DbRecord.Payee = c.Payee;
            o.DbRecord.PayeeAccountNumber = c.PayeeAccountNumber;
            o.DbRecord.Amount = c.Amount;
            o.DbRecord.Currency = c.Currency;
            o.DbRecord.CardAssociationName = c.CardAssociationName;
            o.DbRecord.CardNumber = c.CardNumber;
            o.DbRecord.DailyWithDrawalLimit = c.DailyWithdrawalLimit;
            o.DbRecord.Memo = c.Memo;
            o.DbRecord.CreditLimit = c.CreditLimit;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await payments.UpdateObject(o);
            return RedirectToAction("Index");
        }
    }
}