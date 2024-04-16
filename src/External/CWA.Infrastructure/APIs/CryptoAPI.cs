using CWA.Domain.API;
using CWA.Domain.Enteties;
using Newtonsoft.Json;
namespace CWA.Infrastructure.API
{
    public class CryptoAPI : ICryptoAPI
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public CryptoAPI() => _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

        public async Task<string> GetCurrencyListJsonAsync()
        {
            string url = $"https://api.coingecko.com/api/v3/coins/list";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception("CryptoAPI/GetCurrencyListJsonAsync - IsSuccessStatusCode == false");
        }
        public async Task<string> GetSupportedVSCurrenciesJsonAsync()
        {
            string url = $"https://api.coingecko.com/api/v3/simple/supported_vs_currencies";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception("CryptoAPI/GetSupportedVSCurrenciesJsonAsync - IsSuccessStatusCode == false");
        }
        public async Task<string> GetTickersJsonByCurrencyIdAsync(string currencyId)
        {
            string url = $"https://api.coingecko.com/api/v3/coins/{currencyId}/tickers";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception("CryptoAPI/GetTickersJsonByCurrencyIdAsync - IsSuccessStatusCode == false");
        }
        public async Task<string> GetTopNCurrenciesJsonAsync(int topN, int pageNum)
        {
            string validatedTopN = topN > 250 ? "250" : (topN < 0 ? "1" : topN.ToString());
            string validatedpageNum = pageNum < 0 ? "1" : pageNum.ToString();

            string url = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page={validatedTopN}&page={validatedpageNum}&sparkline=false&locale=en";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception("CryptoAPI/GetTopNCurrenciesJsonAsync - IsSuccessStatusCode == false");
        }
        public async Task<string> GetCurrencyHistorycalMarketDataJsonAsync(string currencyId, string days)
        {
            string url = $"https://api.coingecko.com/api/v3/coins/{currencyId}/market_chart?vs_currency=usd&days={days}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception("CryptoAPI/GetCurrencyHistorycalMarketDataJsonAsync - IsSuccessStatusCode == false");
        }
        public async Task<string> GetCurrencyPriceJsonByIdAsync(string currencyId, string targetCurrencyId)
        {
            string url = $"https://api.coingecko.com/api/v3/simple/price?ids={currencyId}&vs_currencies={targetCurrencyId}&include_market_cap=false&include_24hr_vol=false&include_24hr_change=false&include_last_updated_at=false";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception("CryptoAPI/GetCurrencyPriceJsonByIdAsync - IsSuccessStatusCode == false");
        }
        public async Task<string> GetCurrencyDetailsJsonByIdAsync(string currencyId, string targetCurrencyId)
        {
            string url = $"https://api.coingecko.com/api/v3/coins/{currencyId}?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=false";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception("CryptoAPI/GetCurrencyDetailsJsonByIdAsync - IsSuccessStatusCode == false");
        }
    }
}