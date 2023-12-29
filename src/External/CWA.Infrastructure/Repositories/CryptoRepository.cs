using CWA.Domain.API;
using CWA.Domain.Enteties;
using CWA.Domain.Repositories;
using CWA.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWA.Infrastructure.Repositories
{
    public class CryptoRepository : ICryptoRepository
    {
        private readonly ICryptoAPI _cryptoAPI;
        private readonly JsonMapper _jsonMapper;
        public CryptoRepository(ICryptoAPI cryptoAPI)
        {
            _cryptoAPI = cryptoAPI;
            _jsonMapper = new JsonMapper();
        }
        public async Task<List<string>> GetSupportedCurrenciesAsync()
        {
            var jsonString = await _cryptoAPI.GetSupportedCurrenciesJsonAsync();

            return _jsonMapper.MapJsonSupportedCurrenciesToStringList(jsonString);
        }
        public async Task<List<Ticker>> GetTickersByCurrencyIdAsync(string currencyId)
        {
            var jsonString = await _cryptoAPI.GetTickersJsonByCurrencyIdAsync(currencyId);

            return _jsonMapper.MapJsonTickersToTickerList(jsonString);
        }
        public async Task<List<Currency>> GetTopNCurrenciesAsync(int topN, int pageNum)
        {
            var jsonString = await _cryptoAPI.GetTopNCurrenciesJsonAsync(topN, pageNum);

            return _jsonMapper.MapJsonCurrenciesToCurrencyList(jsonString);
        }
        public async Task<decimal> GetCurrencyPriceByIdAsync(string currencyId, string targetCurrencyId)
        {
            var jsonString = await _cryptoAPI.GetCurrencyPriceJsonByIdAsync(currencyId, targetCurrencyId);

            return _jsonMapper.MapJsonCurrencyPriceToDecimal(jsonString, currencyId, targetCurrencyId);  
        }
        public async Task<CurrencyDetails> GetCurrencyDetailsByIdAsync(string currencyId, string targetCurrencyId)
        {
            var jsonString = await _cryptoAPI.GetCurrencyDetailsJsonByIdAsync(currencyId, targetCurrencyId);

            return _jsonMapper.MapJsonCurrencyDetailsToCurrencyDetails(jsonString, targetCurrencyId);
        }
        public async Task<CurrencyPriceChartData> GetCurrencyHistorycalMarketDataAsync(string currencyId, string days)
        {
            var jsonString = await _cryptoAPI.GetCurrencyHistorycalMarketDataJsonAsync(currencyId, days);

            return _jsonMapper.MapJsonCurrencyHistorycalMarketDataToCurrencyPriceChartData(jsonString);
        }
    }
}
