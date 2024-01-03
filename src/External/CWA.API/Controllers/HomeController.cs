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
        public async Task<IActionResult> CurrencyDetails(string currencyId)
        {
            var result = new CurrencyDetailsPageViewModel()
            {
                CurrencyDetails = new(await _cryptoService.GetCurrencyDetailsByIdAsync(currencyId, "usd")),
                CurrencyPrices = new(await _cryptoService.GetCurrencyHistorycalMarketDataAsync(currencyId, "7")),
                Markets = TickerViewModel.GetTickerViewModelList(await _cryptoService.GetTickersByCurrencyIdAsync(currencyId))
            };

            return View(model: result);
        }
        public async Task<IActionResult> Converter()
        {
            ConvertViewModel convertViewModel = new ConvertViewModel()
            {
                SourceCurrencies = await _cryptoService.GetCurrencyListAsync(),
                TargetCurrencies = await _cryptoService.GetSupportedVSCurrenciesAsync()
            };

            return View(model: convertViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ConvertCurrency(string currencyId, string targetCurrencyId, decimal amount)
        {
            var price = await _cryptoService.GetCurrencyPriceByIdAsync(currencyId, targetCurrencyId);

            string result = $"{amount} ({currencyId})  =  {amount * price}  ({targetCurrencyId})";

            return Json(new { result } );
        }
    }
}
