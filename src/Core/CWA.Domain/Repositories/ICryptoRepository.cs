using CWA.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWA.Domain.Repositories
{
    public interface ICryptoRepository
    {
        Task<List<CurrencyBase>> GetCurrencyListAsync();
        Task<List<string>> GetSupportedVSCurrenciesAsync();
        Task<List<Ticker>> GetTickersByCurrencyIdAsync(string currencyId);
        Task<List<Currency>> GetTopNCurrenciesAsync(int topN, int pageNum);
        Task<CurrencyPriceChartData> GetCurrencyHistorycalMarketDataAsync(string currencyId, string days);
        Task<decimal> GetCurrencyPriceByIdAsync(string currencyId, string targetCurrencyId);
        Task<CurrencyDetails> GetCurrencyDetailsByIdAsync(string currencyId, string targetCurrencyId);
    }
}
