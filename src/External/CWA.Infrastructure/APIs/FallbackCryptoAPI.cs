using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CWA.Infrastructure.API
{
    public class FallbackCryptoAPI
    {
        string _basePath = string.Empty;
        public FallbackCryptoAPI()
        {
            Assembly assembly = typeof(FallbackCryptoAPI).Assembly;

            _basePath = Path.Combine(Path.GetDirectoryName(assembly.Location), "Data\\");
        }
        private async Task<string> ReadFileAsync(string filePath)
        {
            var stringBuilder = new StringBuilder();

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            using (var streamReader = new StreamReader(fileStream))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = await streamReader.ReadLineAsync();
                    stringBuilder.AppendLine(line);
                }
            }

            return stringBuilder.ToString();
        }
        public async Task<string> GetSupportedCurrenciesJsonAsync()
        {
            string fileName = "supported_currencies_responce.json";

            return await ReadFileAsync(Path.Combine(_basePath, fileName));
        }
        public async Task<string> GetTickersJsonByCurrencyIdAsync(string currencyId)
        {
            string fileName = "currency-bitcoin_tickers_responce.json";

            return await ReadFileAsync(Path.Combine(_basePath, fileName));
        }
        public async Task<string> GetTopNCurrenciesJsonAsync(int topN, int pageNum)
        {
            string fileName = "top-250-currencies_page-1_responce.json";

            return await ReadFileAsync(Path.Combine(_basePath, fileName));
        }
        public async Task<string> GetCurrencyHistorycalMarketDataJsonAsync(string currencyId, string days)
        {
            string fileName = "get_currency_prices_by_id-bitcoin_target-usd_days-5_responce.json";

            return await ReadFileAsync(Path.Combine(_basePath, fileName));
        }
        public async Task<string> GetCurrencyPriceJsonByIdAsync(string currencyId, string targetCurrencyId)
        {
            string fileName = "bitcoin_to_usd_price_responce.json";

            return await ReadFileAsync(Path.Combine(_basePath, fileName));
        }
        public async Task<string> GetCurrencyDetailsJsonByIdAsync(string currencyId, string targetCurrencyId)
        {
            string fileName = "get_currency_by_id-bitcoin_responce.json";

            return await ReadFileAsync(Path.Combine(_basePath, fileName));
        }
    }
}
