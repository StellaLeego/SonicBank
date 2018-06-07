using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Project;
using Open.Domain.Project;

namespace Open.Infra.Project
{
    public class PaymentObjectsRepository : IPaymentObjectsRepository
    {
        private readonly DbSet<PaymentDbRecord> dbSet;
        private readonly DbContext db;

        public PaymentObjectsRepository(SentryDbContext c)
        {
            db = c;
            dbSet = c?.Payments;
        }

        public string SearchString { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public Func<PaymentDbRecord, object> SortFunction { get; set; }

        public async Task<PaginatedList<IPaymentObject>> GetObjectsList()
        {
            var payments = getSorted().Where(s => s.Contains(SearchString)).AsNoTracking();
            var count = await payments.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await payments.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
        protected internal PaginatedList<IPaymentObject> createList(
            List<PaymentDbRecord> l, RepositoryPage p)
        {
            return new PaymentObjectsList(l, p);
        }
        private IQueryable<PaymentDbRecord> getSet()
        {
            return from s in dbSet select s;
        }
        private IQueryable<PaymentDbRecord> getSorted()
        {
            if (SortFunction is null) return getSet();
            return SortOrder == SortOrder.Descending
                ? getSet().OrderByDescending(x => SortFunction(x))
                : getSet().OrderBy(x => SortFunction(x));
        }
        protected internal async Task<PaymentDbRecord> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<IPaymentObject> GetObject(string id)
        {
            var r = await getObject(id);
            return PaymentObjectFactory.Create(r);
        }
        public async Task AddObject(IPaymentObject o)
        {
            if (o is CashObject cash) dbSet.Add(cash.DbRecord);
            if (o is CheckObject check) dbSet.Add(check.DbRecord);
            if (o is DebitCardObject debit) dbSet.Add(debit.DbRecord);
            if (o is CreditCardObject credit) dbSet.Add(credit.DbRecord);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(IPaymentObject o)
        {
            if (o is CashObject cash) dbSet.Update(cash.DbRecord);
            if (o is CheckObject check) dbSet.Update(check.DbRecord);
            if (o is DebitCardObject debit) dbSet.Update(debit.DbRecord);
            if (o is CreditCardObject credit) dbSet.Update(credit.DbRecord);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(IPaymentObject o)
        {
            if (o is CashObject cash) dbSet.Remove(cash.DbRecord);
            if (o is CheckObject check) dbSet.Remove(check.DbRecord);
            if (o is DebitCardObject debit) dbSet.Remove(debit.DbRecord);
            if (o is CreditCardObject credit) dbSet.Remove(credit.DbRecord);
            await db.SaveChangesAsync();
        }
        public bool IsInitialized()
        {
            db.Database.EnsureCreated();
            return dbSet.Any();
        }
    }
}
