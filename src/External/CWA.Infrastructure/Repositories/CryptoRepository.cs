using CWA.Domain.API;
using CWA.Domain.Enteties;
using CWA.Domain.Repositories;
using CWA.Infrastructure.API;
using CWA.Infrastructure.Mappers;
using Microsoft.Extensions.Logging;
namespace CWA.Infrastructure.Repositories
{
    public class CryptoRepository : ICryptoRepository
    {
        private readonly ICryptoAPI _cryptoAPI;
        private readonly FallbackCryptoAPI _fallbackCryptoAPI;

        private readonly JsonMapper _jsonMapper;

        private readonly ILogger _logger;

        public CryptoRepository(ICryptoAPI cryptoAPI, FallbackCryptoAPI fallbackCryptoAPI, ILogger<CryptoRepository> logger)
        {
            _cryptoAPI = cryptoAPI;
            _fallbackCryptoAPI = fallbackCryptoAPI;

            _jsonMapper = new JsonMapper();
            _logger = logger;
        }
        public async Task<List<CurrencyBase>> GetCurrencyListAsync()
        {
            string jsonString;

            try
            {
                _logger.LogInformation("_cryptoAPI.GetCurrencyListJsonAsync");
                jsonString = await _cryptoAPI.GetCurrencyListJsonAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(0, e, "");
                jsonString = await _fallbackCryptoAPI.GetCurrencyListJsonAsync();
            }

            return _jsonMapper.MapJsonCurrencyListToCurrencyBaseList(jsonString);
        }
        public async Task<List<string>> GetSupportedVSCurrenciesAsync()
        {
            string jsonString;

            try
            {
                _logger.LogInformation("_cryptoAPI.GetSupportedVSCurrenciesJsonAsync");
                jsonString = await _cryptoAPI.GetSupportedVSCurrenciesJsonAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(0, e, "");
                jsonString = await _fallbackCryptoAPI.GetSupportedVSCurrenciesJsonAsync();
            }

            return _jsonMapper.MapJsonSupportedCurrenciesToStringList(jsonString);
        }
        public async Task<List<Ticker>> GetTickersByCurrencyIdAsync(string currencyId)
        {
            string jsonString;

            try
            {
                _logger.LogInformation("_cryptoAPI.GetTickersJsonByCurrencyIdAsync");
                jsonString = await _cryptoAPI.GetTickersJsonByCurrencyIdAsync(currencyId);
            }
            catch (Exception e)
            {
                _logger.LogError(0, e, "");
                jsonString = await _fallbackCryptoAPI.GetTickersJsonByCurrencyIdAsync(currencyId);
            }

            return _jsonMapper.MapJsonTickersToTickerList(jsonString);
        }
        public async Task<List<Currency>> GetTopNCurrenciesAsync(int topN, int pageNum)
        {
            string jsonString;

            try
            {
                _logger.LogInformation("_cryptoAPI.GetTopNCurrenciesJsonAsync");
                jsonString = await _cryptoAPI.GetTopNCurrenciesJsonAsync(topN, pageNum);
            }
            catch (Exception e)
            {
                _logger.LogError(0, e, "");
                jsonString = await _fallbackCryptoAPI.GetTopNCurrenciesJsonAsync(topN, pageNum);
            }

            return _jsonMapper.MapJsonCurrenciesToCurrencyList(jsonString);
        }
        public async Task<decimal> GetCurrencyPriceByIdAsync(string currencyId, string targetCurrencyId)
        {
            string jsonString;

            try
            {
                _logger.LogInformation("_cryptoAPI.GetCurrencyPriceJsonByIdAsync");
                jsonString = await _cryptoAPI.GetCurrencyPriceJsonByIdAsync(currencyId, targetCurrencyId);
            }
            catch (Exception e)
            {
                _logger.LogError(0, e, "");
                jsonString = await _fallbackCryptoAPI.GetCurrencyPriceJsonByIdAsync(currencyId, targetCurrencyId);
            }

            return _jsonMapper.MapJsonCurrencyPriceToDecimal(jsonString, currencyId, targetCurrencyId);  
        }
        public async Task<CurrencyDetails> GetCurrencyDetailsByIdAsync(string currencyId, string targetCurrencyId)
        {
            string jsonString;

            try
            {
                _logger.LogInformation("_cryptoAPI.GetCurrencyDetailsJsonByIdAsync");
                jsonString = await _cryptoAPI.GetCurrencyDetailsJsonByIdAsync(currencyId, targetCurrencyId);
            }
            catch (Exception e)
            {
                _logger.LogError(0, e, "");
                jsonString = await _fallbackCryptoAPI.GetCurrencyDetailsJsonByIdAsync(currencyId, targetCurrencyId);
            }

            return _jsonMapper.MapJsonCurrencyDetailsToCurrencyDetails(jsonString, targetCurrencyId);
        }
        public async Task<CurrencyPriceChartData> GetCurrencyHistorycalMarketDataAsync(string currencyId, string days)
        {
            string jsonString;

            try
            {
                _logger.LogInformation("_cryptoAPI.GetCurrencyHistorycalMarketDataJsonAsync");
                jsonString = await _cryptoAPI.GetCurrencyHistorycalMarketDataJsonAsync(currencyId, days);
            }
            catch (Exception e)
            {
                _logger.LogError(0, e, "");
                jsonString = await _fallbackCryptoAPI.GetCurrencyHistorycalMarketDataJsonAsync(currencyId, days);
            }

            return _jsonMapper.MapJsonCurrencyHistorycalMarketDataToCurrencyPriceChartData(jsonString);
        }
    }
}
