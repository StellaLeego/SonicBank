using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Open.Domain.Location;
using Open.Domain.Money;
using Open.Infra;
using Open.Infra.Location;
using Open.Infra.Money;
using Open.Sentry.Data;

namespace Open.Sentry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var countriesContext = services.GetRequiredService<ICountryObjectsRepository>();
                    CountriesDbTableInitializer.Initialize(countriesContext);

                    var currenciesContext = services.GetRequiredService<ICurrencyObjectsRepository>();
                    CurrenciesDbTableInitializer.Initialize(currenciesContext);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured while seeding the database");
                }
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
