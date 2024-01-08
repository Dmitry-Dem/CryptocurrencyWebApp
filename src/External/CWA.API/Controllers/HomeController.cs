using CWA.API.Managers;
using CWA.API.ViewModels;
using CWA.Domain.Enteties;
using CWA.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;

namespace CWA.API.Controllers
{
    public class HomeController : Controller
    {
        private int _currencyCountPerPage = 50;
        private string _cacheCurenciesKey = "Curencies";
        private string _cacheAvailableCurrenciesKey = "AvailableCurrencies";

        private readonly IMemoryCache _memoryCache;
        private readonly ICryptoService _cryptoService;
        private readonly CurrencyPaginationManager _currencyPagination;
        private static List<CurrencyViewModel> Currencies { get; set; } = new();
        public HomeController(IMemoryCache memoryCache, ICryptoService cryptoService)
        {
            _memoryCache = memoryCache;
            _cryptoService = cryptoService;

            _currencyPagination = new CurrencyPaginationManager(_currencyCountPerPage, currentPage: 1);
        }
        public async Task<IActionResult> Index()
        {
            await LoadAvailableCurrencies();

            if (!_memoryCache.TryGetValue(_cacheCurenciesKey, out List<CurrencyViewModel> currenciesVM))
            {
                var currencies = await _cryptoService.GetTopNCurrenciesAsync(topN: 250, pageNum: 1);

                currenciesVM = CurrencyViewModel.GetCurrencyViewModelList(currencies);

                _memoryCache.Set(_cacheCurenciesKey, currenciesVM, TimeSpan.FromMinutes(20));
            }

            var result = _currencyPagination.GetCurrenciesByPageNum(currencies: currenciesVM, pageNum: 1);

            return View(result);
        }
        private async Task<List<CurrencyBaseViewModel>> LoadAvailableCurrencies()
        {
            if (!_memoryCache.TryGetValue(_cacheAvailableCurrenciesKey, out List<CurrencyBaseViewModel> currenciesBaseVM))
            {
                var currencies = await _cryptoService.GetCurrencyListAsync();

                currenciesBaseVM = CurrencyBaseViewModel.GetCurrencyBaseViewModelList(currencies);

                _memoryCache.Set(_cacheAvailableCurrenciesKey, currenciesBaseVM, TimeSpan.FromMinutes(20));
            }

            TempData["AvailableCurrencies"] = currenciesBaseVM;

            return currenciesBaseVM;
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
