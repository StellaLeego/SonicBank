﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Open.Aids;
using Open.Core;
using Open.Data.Money;
using Open.Domain.Money;
using Open.Facade.Money;

namespace Open.Sentry.Controllers
{ 
    [Authorize]
    public class CurrenciesController : Controller
    {
        private readonly ICurrencyObjectsRepository repository;
        private readonly ICountryCurrencyObjectsRepository countries;
        internal const string properties = "IsoCurrencySymbol, CurrencySymbol, Name, ValidFrom, ValidTo";

        public CurrenciesController(ICurrencyObjectsRepository r, ICountryCurrencyObjectsRepository c)
        {
            repository = r;
            countries = c;
        }
        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortName"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SortAlpha3"] = sortOrder == "alpha3" ? "alpha3_desc" : "alpha3";
            ViewData["SortAlpha2"] = sortOrder == "alpha2" ? "alpha2_desc" : "alpha2";
            ViewData["SortValidFrom"] = sortOrder == "validFrom" ? "validFrom_desc" : "validFrom";
            ViewData["SortValidTo"] = sortOrder == "validTo" ? "validTo_desc" : "validTo";
            repository.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            repository.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            repository.SearchString = searchString;
            repository.PageIndex = page ?? 1;
            var l = await repository.GetObjectsList();
            return View(new CurrencyViewModelsList(l));
        }

        private Func<CurrencyDbRecord, object> getSortFunction(string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.Name;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            if (sortOrder.StartsWith("alpha3")) return x => x.ID;
            if (sortOrder.StartsWith("aplha2")) return x => x.Code;
            return x => x.Name;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(properties)] CurrencyViewModel c)
        {
            await validateId(c.IsoCurrencySymbol, ModelState);
            if (!ModelState.IsValid) return View(c);
            var o = CurrencyObjectFactory.Create(c.IsoCurrencySymbol, c.Name, c.CurrencySymbol, c.ValidFrom, c.ValidTo);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var c = await repository.GetObject(id);
            return View(CurrencyViewModelFactory.Create(c));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(properties)] CurrencyViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            var o = await repository.GetObject(c.IsoCurrencySymbol);
            o.DbRecord.Name = c.Name;
            o.DbRecord.Code = c.CurrencySymbol;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            repository.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var c = await repository.GetObject(id);
            await countries.LoadCountries(c);
            return View(CurrencyViewModelFactory.Create(c));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var c = await repository.GetObject(id);
            return View(CurrencyViewModelFactory.Create(c));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var c = await repository.GetObject(id);
            repository.DeleteObject(c);
            return RedirectToAction("Index");
        }

        private async Task validateId(string id, ModelStateDictionary d)
        {
            if (await isIdInUse(id))
                d.AddModelError(string.Empty, idIsInUseMessage(id));
        }

        private async Task<bool> isIdInUse(string id)
        {
            return (await repository.GetObject(id))?.DbRecord?.ID == id;
        }

        private static string idIsInUseMessage(string id)
        {
            var name = GetMember.DisplayName<CurrencyViewModel>(c => c.IsoCurrencySymbol);
            return string.Format(Messages.ValueIsAlreadyInUse, id, name);
        }
    }
}