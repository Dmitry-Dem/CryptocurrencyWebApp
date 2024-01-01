using Microsoft.AspNetCore.Mvc;

namespace CWA.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TopCurrencies()
        {
            return View();
        }
        public IActionResult Converter()
        {
            return View();
        }
    }
}
