using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Money;
using Open.Sentry.Controllers;

namespace Open.Tests.Sentry.Controllers
{
    [TestClass]
    public class CurrenciesControllerTests : AcceptanceTests
    {
        [TestMethod]
        public async Task IndexTestWhenLoggedOut()
        {
            var response = await client.GetAsync("/currencies");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public async Task IndexWhenLoggedIn()
        {
            TestAuthenticationHandler.IsLoggedIn = true;
            var response = await client.GetAsync("/currencies");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(stringResponse.Contains("Currencies"));
        }

        [TestMethod]
        public void RepositoryTest()
        {
            const string c = ", ";
            var b = new StringBuilder();
            b.Append(GetMember.Name<CurrencyViewModel>(m => m.IsoCurrencySymbol));
            b.Append(c);
            b.Append(GetMember.Name<CurrencyViewModel>(m => m.CurrencySymbol));
            b.Append(c);
            b.Append(GetMember.Name<CurrencyViewModel>(m => m.Name));
            b.Append(c);
            b.Append(GetMember.Name<CurrencyViewModel>(m => m.ValidFrom));
            b.Append(c);
            b.Append(GetMember.Name<CurrencyViewModel>(m => m.ValidTo));
            Assert.AreEqual(b.ToString(), CurrenciesController.properties);
        }
    }
}
