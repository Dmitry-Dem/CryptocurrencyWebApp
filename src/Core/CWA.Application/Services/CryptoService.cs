using CWA.Domain.Enteties;
using CWA.Domain.Repositories;
using CWA.Domain.Services;

namespace CWA.Application.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly ICryptoRepository _cryptoRepository;
        public CryptoService(ICryptoRepository cryptoRepository)
        {
            _cryptoRepository = cryptoRepository;
        }
        public async Task<List<CurrencyBase>> GetCurrencyListAsync()
        {
            return await _cryptoRepository.GetCurrencyListAsync();
        }
        public async Task<List<string>> GetSupportedVSCurrenciesAsync()
        {
            return await _cryptoRepository.GetSupportedVSCurrenciesAsync();
        }
        public async Task<List<Ticker>> GetTickersByCurrencyIdAsync(string currencyId)
        {
            return await _cryptoRepository.GetTickersByCurrencyIdAsync(currencyId);
        }
        public async Task<List<Currency>> GetTopNCurrenciesAsync(int topN, int pageNum)
        {
            return await _cryptoRepository.GetTopNCurrenciesAsync(topN, pageNum);
        }
        public async Task<decimal> GetCurrencyPriceByIdAsync(string currencyId, string targetCurrencyId)
        {
            return await _cryptoRepository.GetCurrencyPriceByIdAsync(currencyId, targetCurrencyId);
        }
        public async Task<CurrencyDetails> GetCurrencyDetailsByIdAsync(string currencyId, string targetCurrencyId)
        {
            return await _cryptoRepository.GetCurrencyDetailsByIdAsync(currencyId, targetCurrencyId);
        }
        public async Task<CurrencyPriceChartData> GetCurrencyHistorycalMarketDataAsync(string currencyId, string days)
        {
            return await _cryptoRepository.GetCurrencyHistorycalMarketDataAsync(currencyId, days);
        }
    }
}
