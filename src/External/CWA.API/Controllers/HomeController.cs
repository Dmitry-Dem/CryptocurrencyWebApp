using CWA.API.ViewModels;
using CWA.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CWA.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICryptoService _cryptoService;
        public HomeController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }
        public async Task<IActionResult> Index()
        {
            var currencies = await _cryptoService.GetTopNCurrenciesAsync(100, 1);

            return View(CurrencyViewModel.GetCurrencyViewModelList(currencies));
        }
        [Route("Home/CurrencyDetails/{currencyId}")]
        public IActionResult CurrencyDetails(string currencyId)
        {
            return View("CurrencyDetails", currencyId);
        } 
        public IActionResult Converter()
        {
            return View();
        }
    }
}
