using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWA.Domain.API
{
    public interface ICryptoAPI
    {
        Task<string> GetSupportedVSCurrenciesJsonAsync();
        Task<string> GetCurrencyListJsonAsync();
        Task<string> GetTickersJsonByCurrencyIdAsync(string currencyId);
        Task<string> GetTopNCurrenciesJsonAsync(int topN, int pageNum);
        Task<string> GetCurrencyHistorycalMarketDataJsonAsync(string currencyId, string days);
        Task<string> GetCurrencyPriceJsonByIdAsync(string currencyId, string targetCurrencyId);
        Task<string> GetCurrencyDetailsJsonByIdAsync(string currencyId, string targetCurrencyId);
    }
}
