using Microsoft.AspNetCore.Mvc;

namespace Sentry.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}