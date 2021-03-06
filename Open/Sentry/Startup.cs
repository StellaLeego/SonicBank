﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Open.Domain.Location;
using Open.Domain.Money;
using Open.Domain.Project;
using Open.Infra;
using Open.Infra.Location;
using Open.Infra.Money;
using Open.Infra.Project;
using Open.Sentry.Data;
using Open.Sentry.Models;
using Open.Sentry.Services;

namespace Open.Sentry {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            setDatabase(services);
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            setAuthentication(services);
            services.AddTransient<IEmailSender, EmailSender>();
            setMvcWithAntiForgeryToken(services);
            services.AddScoped<ICountryObjectsRepository, CountryObjectsRepository>();
            services.AddScoped<ICurrencyObjectsRepository, CurrencyObjectsRepository>();
            services.AddScoped<ICountryCurrencyObjectsRepository, CountryCurrencyObjectsRepository>();
            services.AddScoped<IAddressObjectsRepository, AddressObjectsRepository>();
            services
                .AddScoped<ITelecomDeviceRegistrationObjectsRepository, TelecomDeviceRegistrationObjectsRepository>();
            services.AddScoped<IPaymentObjectsRepository, PaymentObjectsRepository>();
        }

        protected virtual void setMvcWithAntiForgeryToken(IServiceCollection services) {
            services.AddMvc();
        }

        protected virtual void setAuthentication(IServiceCollection services) { }

        protected virtual void setDatabase(IServiceCollection services) {
            var s = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(s));
            services.AddDbContext<SentryDbContext>(
                options => options.UseSqlServer(s));
            services.AddDbContext<SentryDbContext>(
                options => options.UseSqlServer(s));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            setErrorPage(app, env);
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }

        protected virtual void setErrorPage(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
            }
        }
    }
}