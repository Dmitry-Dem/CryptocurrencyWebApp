using CWA.API.Managers;
using CWA.API.ViewModels;
using CWA.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CWA.API.Controllers
{
    public class HomeController : Controller
    {
        private int currencyCountPerPage = 50;

        private readonly ICryptoService _cryptoService;
        private readonly CurrencyPaginationManager _currencyPagination;
        private static List<CurrencyViewModel> Currencies { get; set; } = new();
        public HomeController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
            _currencyPagination = new CurrencyPaginationManager(currencyCountPerPage, currentPage: 1);
        }
        public async Task<IActionResult> Index()
        {
            await LoadAvailableCurrencies();

            if (Currencies.Count == 0)
            {
                var currencies = await _cryptoService.GetTopNCurrenciesAsync(topN: 250, pageNum: 1);

                Currencies = CurrencyViewModel.GetCurrencyViewModelList(currencies);
            }

            var result = _currencyPagination.GetCurrenciesByPageNum(currencies: Currencies, pageNum: 1);

            return View(result);
        }
        private async Task<List<CurrencyBaseViewModel>> LoadAvailableCurrencies()
        {
            var currencies = await _cryptoService.GetCurrencyListAsync();

            var currenciesVM = CurrencyBaseViewModel.GetCurrencyBaseViewModelList(currencies);

            TempData["AvailableCurrencies"] = currenciesVM;

            return currenciesVM;
        }

        [Route("Home/CurrencyDetails/{currencyId}")]
        public async Task<IActionResult> CurrencyDetails(string currencyId)
        {
            await LoadAvailableCurrencies();

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
                SourceCurrencies = await LoadAvailableCurrencies(),
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

        [HttpGet]
        public async Task<IActionResult> GetCurrenciesByPageNum(int pageNum)
        {
            if (pageNum <= 0)
                return BadRequest();

            if (Currencies.Count < (_currencyPagination.CurrencyCountPerPage * pageNum))
            {
                var newCurrencies = await _cryptoService.GetTopNCurrenciesAsync(250, pageNum: ++_currencyPagination.CurrentPage);

                Currencies.AddRange(CurrencyViewModel.GetCurrencyViewModelList(newCurrencies));
            }

            var result = _currencyPagination.GetCurrenciesByPageNum(Currencies, pageNum);

            return Json( result );
        }
    }
}
