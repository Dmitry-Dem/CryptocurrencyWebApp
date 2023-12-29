using CWA.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CWA.Infrastructure.Mappers
{
    public class JsonMapper
    {
        public List<Ticker> MapJsonTickersToTickerList(string jsonString)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonString);

                var jsonArray = (JArray)jsonObject["tickers"];

                var tickers = new List<Ticker>();

                foreach (var jsonObj in jsonArray)
                {
                    tickers.Add(new Ticker()
                    {
                        Base = (string)jsonObj["base"],
                        Target = (string)jsonObj["target"],
                        MarketName = (string)jsonObj["market"]["name"],
                        TradeUrl = (string)jsonObj["trade_url"],
                        PriceInUSD = (decimal)jsonObj["converted_last"]["usd"]
                    });
                }

                return tickers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mapping JsonTickers to List<Ticker>: {ex.Message}");
                return null;
            }
        }
        public List<Currency> MapJsonCurrenciesToCurrencyList(string jsonString)
        {
            try
            {
                JArray jsonArray = JArray.Parse(jsonString);

                var currencies = new List<Currency>();

                foreach (var jsonObj in jsonArray)
                {
                    currencies.Add(new Currency()
                    {
                        Id = (string)jsonObj["id"],
                        Name = (string)jsonObj["name"],
                        Symbol = (string)jsonObj["symbol"],
                        ImageUrl = (string)jsonObj["image"],
                        Price = (decimal)jsonObj["current_price"],
                        Rank = (int)jsonObj["market_cap_rank"]
                    });
                }

                return currencies;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mapping JsonCurrencies to List<Currency>: {ex.Message}");
                return null;
            }
        }
        public List<string> MapJsonSupportedCurrenciesToStringList(string jsonString)
        {
            try
            {
                var supportedCurrencies = JsonConvert.DeserializeObject<List<string>>(jsonString);

                return supportedCurrencies;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mapping JsonSupportedCurrencies to List<string>: {ex.Message}");

                return null;
            }
        }
        public CurrencyDetails MapJsonCurrencyDetailsToCurrencyDetails(string jsonString, string targetCurrencyId)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonString);

                CurrencyDetails currency = new CurrencyDetails();
                currency.Id = (string)jsonObject["id"];
                currency.Symbol = (string)jsonObject["symbol"];
                currency.Name = (string)jsonObject["name"];
                currency.ImageUrl = (string)jsonObject["image"]["large"];
                currency.MarketCap = (decimal)jsonObject["market_data"]["market_cap"][targetCurrencyId];
                currency.Rank = (int)jsonObject["market_data"]["market_cap_rank"];
                currency.Price = (decimal)jsonObject["market_data"]["current_price"][targetCurrencyId];
                currency.FullyDilutedValuation = (decimal)jsonObject["market_data"]["fully_diluted_valuation"][targetCurrencyId];
                currency.TotalVolume = (decimal)jsonObject["market_data"]["total_volume"][targetCurrencyId];
                currency.TotalSupply = (decimal)jsonObject["market_data"]["total_supply"];
                currency.CirculatingSupply = (decimal)jsonObject["market_data"]["circulating_supply"];

                return currency;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mapping JsonCurrencyDetails to CurrencyDetails: {ex.Message}");

                return null;
            }
        }
        public decimal MapJsonCurrencyPriceToDecimal(string jsonString, string currencyId, string targetCurrencyId)
        { 
            try
            {
                JObject jsonObject = JObject.Parse(jsonString);

                decimal price = (decimal)jsonObject[currencyId][targetCurrencyId];

                return price;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mapping JsonCurrencyPrice to decimal: {ex.Message}");

                return -1;
            }
        }
        public CurrencyPriceChartData MapJsonCurrencyHistorycalMarketDataToCurrencyPriceChartData(string jsonString)
        {
            try
            {
                CurrencyPriceChartData chartData = JsonConvert.DeserializeObject<CurrencyPriceChartData>(jsonString);

                return chartData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mapping JsonCurrencyHistorycalMarketData to CurrencyPriceChartData: {ex.Message}");

                return null;
            }
        }
    }
}
