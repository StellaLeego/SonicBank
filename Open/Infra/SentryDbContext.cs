﻿using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Open.Data.Location;
using Open.Data.Money;
using Open.Data.Project;

namespace Open.Infra {
    public class SentryDbContext : DbContext {
        public SentryDbContext(DbContextOptions<SentryDbContext> o) : base(o) { }
        public DbSet<CountryDbRecord> Countries { get; set; }
        public DbSet<CurrencyDbRecord> Currencies { get; set; }
        public DbSet<CountryCurrencyDbRecord> CountryCurrencies { get; set; }
        public DbSet<AddressDbRecord> Addresses { get; set; }
        public DbSet<TelecomDeviceRegistrationDbRecord> TelecomDeviceRegistrations { get; set; }
        public DbSet<PaymentDbRecord> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            b.Entity<CurrencyDbRecord>().ToTable("Currency");
            b.Entity<CountryDbRecord>().ToTable("Country");
            createAddressTable(b);
            createTelecomAddressRegistrationTable(b);
            createCountryCurrencyTable(b);
            createPaymentsTable(b);
        }

        internal static void createCountryCurrencyTable(ModelBuilder b) {
            const string table = "CountryCurrency";
            createPrimaryKey<CountryCurrencyDbRecord>(b, table, a => new {a.CountryID, a.CurrencyID});
            createForeignKey<CountryCurrencyDbRecord, CountryDbRecord>(b, table, x => x.CountryID, x => x.Country);
            createForeignKey<CountryCurrencyDbRecord, CurrencyDbRecord>(b, table, x => x.CurrencyID, x => x.Currency);
        }

        internal static void createTelecomAddressRegistrationTable(ModelBuilder b) {
            const string table = "TelecomDeviceRegistration";
            createPrimaryKey<TelecomDeviceRegistrationDbRecord>(b, table, a => new {a.AddressID, a.DeviceID});
            createForeignKey<TelecomDeviceRegistrationDbRecord, GeographicAddressDbRecord>(b, table, x => x.AddressID,
                x => x.Address);
            createForeignKey<TelecomDeviceRegistrationDbRecord, TelecomAddressDbRecord>(b, table, x => x.DeviceID,
                x => x.Device);
        }

        internal static void createAddressTable(ModelBuilder b) {
            const string table = "Address";
            b.Entity<AddressDbRecord>().ToTable(table);
            b.Entity<WebPageAddressDbRecord>().ToTable(table);
            b.Entity<EmailAddressDbRecord>().ToTable(table);
            b.Entity<TelecomAddressDbRecord>().ToTable(table);
            createForeignKey<GeographicAddressDbRecord, CountryDbRecord>(b, table, x => x.CountryID, x => x.Country);
        }

        internal static void createPaymentsTable(ModelBuilder b) {
            const string table = "Payments";
            b.Entity<PaymentDbRecord>().ToTable(table);
            b.Entity<PaymentCardDbRecord>().ToTable(table);
            b.Entity<CheckDbRecord>().ToTable(table);
            b.Entity<CashDbRecord>().ToTable(table);
            b.Entity<DebitCardDbRecord>().ToTable(table);
            b.Entity<CreditCardDbRecord>().ToTable(table);
        }

        internal static void createPrimaryKey<TEntity>(ModelBuilder b,
            string tableName, Expression<Func<TEntity, object>> primaryKey)
            where TEntity : class {
            b.Entity<TEntity>().ToTable(tableName).HasKey(primaryKey);
        }

        internal static void createForeignKey<TEntity, TRelatedEntity>(ModelBuilder b,
            string tableName, Expression<Func<TEntity, object>> foreignKey,
            Expression<Func<TEntity, TRelatedEntity>> getRelatedEntity)
            where TEntity : class where TRelatedEntity : class {
            b.Entity<TEntity>().ToTable(tableName).HasOne(getRelatedEntity)
                .WithMany().HasForeignKey(foreignKey).OnDelete(DeleteBehavior.Restrict);
        }
    }
}