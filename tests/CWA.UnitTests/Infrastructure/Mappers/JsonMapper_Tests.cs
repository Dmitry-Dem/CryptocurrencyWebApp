using CWA.Domain.Enteties;
using CWA.Infrastructure.API;
using CWA.Infrastructure.Mappers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CWA.UnitTests.Infrastructure.Mappers
{
    public class JsonMapper_Tests
    {
        [Fact]
        public async void JsonMapper_MapJsonCurrenciesToCurrencyList_ReturnsCurrencyList()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            JsonMapper jsonMapper = new JsonMapper();
            int topN = 250;
            int pageNum = 1;

            // Act
            var jsonString = await cryptoAPI.GetTopNCurrenciesJsonAsync(topN, pageNum);

            var result = jsonMapper.MapJsonCurrenciesToCurrencyList(jsonString);

            // Assert
            jsonString.Should().NotBeNullOrEmpty();

            result.Should().NotBeNull();
            result.Should().HaveCountGreaterThan(0);
            result.Should().HaveCount(topN);

            var currency = result?.FirstOrDefault();

            currency.Should().NotBeNull();

            currency.Rank.Should().BeGreaterThanOrEqualTo(0);
            currency.Price.Should().BeGreaterThanOrEqualTo(0);

            currency.Name.Should().NotBeNullOrEmpty();
            currency.Id.Should().NotBeNullOrEmpty();
        }
        
        [Fact]
        public async void JsonMapper_MapJsonCurrencyListToCurrencyBaseList_ReturnsCurrencyBaseList()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            JsonMapper jsonMapper = new JsonMapper();

            // Act
            var jsonString = await cryptoAPI.GetCurrencyListJsonAsync();

            var result = jsonMapper.MapJsonCurrencyListToCurrencyBaseList(jsonString);

            // Assert
            jsonString.Should().NotBeNullOrEmpty();

            result.Should().NotBeNull();
            result.Should().HaveCountGreaterThan(0);

            var currency = result?.FirstOrDefault();

            currency.Should().NotBeNull();

            currency.Name.Should().NotBeNullOrEmpty();
            currency.Id.Should().NotBeNullOrEmpty();
            currency.Symbol.Should().NotBeNullOrEmpty();
        }
        [Fact]
        public async void JsonMapper_GetCurrencyPriceJsonByIdAsync_ReturnsCurrencyPrice()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            JsonMapper jsonMapper = new JsonMapper();
            string currencyId = "bitcoin";
            string targetCurrencyId = "usd";

            // Act
            var jsonString = await cryptoAPI.GetCurrencyPriceJsonByIdAsync(currencyId, targetCurrencyId);
            var result = jsonMapper.MapJsonCurrencyPriceToDecimal(jsonString, currencyId, targetCurrencyId);

            // Assert
            jsonString.Should().NotBeNullOrEmpty();

            result.Should().BeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public async void JsonMapper_MapJsonTickersToTickerList_ReturnsTickerList()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            JsonMapper jsonMapper = new JsonMapper();
            string currencyId = "bitcoin";

            // Act
            var jsonString = await cryptoAPI.GetTickersJsonByCurrencyIdAsync(currencyId);
            var result = jsonMapper.MapJsonTickersToTickerList(jsonString);

            // Assert
            jsonString.Should().NotBeNullOrEmpty();

            result.Should().HaveCountGreaterThan(0);

            var ticker = result[0];

            ticker.Should().NotBeNull();
            ticker.PriceInUSD.Should().BeGreaterThanOrEqualTo(0);
            ticker.Target.Should().NotBeNullOrEmpty();
            ticker.Base.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async void JsonMapper_MapJsonSupportedVSCurrenciesToStringList_ReturnsStringList()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            JsonMapper jsonMapper = new JsonMapper();

            // Act
            var jsonString = await cryptoAPI.GetSupportedVSCurrenciesJsonAsync();
            var result = jsonMapper.MapJsonSupportedCurrenciesToStringList(jsonString);

            // Assert
            jsonString.Should().NotBeNullOrEmpty();

            result.Should().HaveCountGreaterThan(0);

            var ticker = result[0];

            ticker.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async void JsonMapper_MapJsonCurrencyDetailsToCurrencyDetails_ReturnsCurrencyDetails()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            JsonMapper jsonMapper = new JsonMapper();
            string currencyId = "bitcoin";
            string targetCurrencyId = "usd";


            // Act
            var jsonString = await cryptoAPI.GetCurrencyDetailsJsonByIdAsync(currencyId, targetCurrencyId);
            var result = jsonMapper.MapJsonCurrencyDetailsToCurrencyDetails(jsonString, targetCurrencyId);


            // Assert
            jsonString.Should().NotBeNullOrEmpty();

            result.Id.Should().NotBeNullOrEmpty();
            result.Name.Should().NotBeNullOrEmpty();
            result.Symbol.Should().NotBeNullOrEmpty();

            result.Rank.Should().BeGreaterThanOrEqualTo(0);
            result.Price.Should().BeGreaterThanOrEqualTo(0);
            result.MarketCap.Should().BeGreaterThanOrEqualTo(0);
            result.TotalVolume.Should().BeGreaterThanOrEqualTo(0);
            result.TotalSupply.Should().BeGreaterThanOrEqualTo(0);
            result.CirculatingSupply.Should().BeGreaterThanOrEqualTo(0);
            result.FullyDilutedValuation.Should().BeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public async void JsonMapper_MapJsonCurrencyHistorycalMarketDataToCurrencyPriceChartData_ReturnsCurrencyPriceChartData()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            JsonMapper jsonMapper = new JsonMapper();
            string currencyId = "bitcoin";
            string days = "5";

            // Act
            var jsonString = await cryptoAPI.GetCurrencyHistorycalMarketDataJsonAsync(currencyId, days);
            var result = jsonMapper.MapJsonCurrencyHistorycalMarketDataToCurrencyPriceChartData(jsonString);


            // Assert
            jsonString.Should().NotBeNullOrEmpty();

            result.Should().NotBeNull();

            result.Prices.Should().HaveCountGreaterThan(0);
            result.Prices[0].Should().HaveCountGreaterThan(0); // result.Prices[0] == { 0.0 , 0.0,...n }
            result.Prices[0][0].Should().BeGreaterThanOrEqualTo(0); // result.Prices[0][0] == some decimal price
        }
    }
}
