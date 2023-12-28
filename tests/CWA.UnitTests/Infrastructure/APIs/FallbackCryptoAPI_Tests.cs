using CWA.Infrastructure.API;
using FluentAssertions;
using Xunit;

namespace CWA.UnitTests.Infrastructure.APIs
{
    public class FallbackCryptoAPI_Tests
    {
        //Naming Convention - ClassName_MethodName_ExpectedResult

        [Fact]
        public async void FallbackCryptoAPI_GetTopNCurrenciesJsonAsync_ReturnsTopNCurrenciesJsonString()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            int topN = 250;
            int pageNum = 1;

            // Act
            var result = await cryptoAPI.GetTopNCurrenciesJsonAsync(topN, pageNum);

            // Assert
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async void FallbackCryptoAPI_GetCurrencyPriceJsonByIdAsync_ReturnsCurrencyPriceStringJsonById()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            string currencyId = "bitcoin";
            string targetCurrencyId = "usd";

            // Act
            var result = await cryptoAPI.GetCurrencyPriceJsonByIdAsync(currencyId, targetCurrencyId);

            // Assert
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async void FallbackCryptoAPI_GetTickersJsonByCurrencyIdAsync_ReturnsTickersStringJsonByCurrencyId()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            string currencyId = "bitcoin";

            // Act
            var result = await cryptoAPI.GetTickersJsonByCurrencyIdAsync(currencyId);

            // Assert
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async void FallbackCryptoAPI_GetSupportedCurrenciesJsonAsync_ReturnsSupportedCurrenciesJsonString()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();

            // Act
            var result = await cryptoAPI.GetSupportedCurrenciesJsonAsync();

            // Assert
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async void FallbackCryptoAPI_GetCurrencyDetailsJsonByIdAsync_ReturnsCurrencyDetailsJsonStringById()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            string currencyId = "bitcoin";
            string targetCurrencyId = "usd";

            // Act
            var result = await cryptoAPI.GetCurrencyDetailsJsonByIdAsync(currencyId, targetCurrencyId);

            // Assert
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async void FallbackCryptoAPI_GetCurrencyHistorycalMarketDataJsonAsync_ReturnsCurrencyHistorycalMarketDataJsonString()
        {
            // Arrange
            FallbackCryptoAPI cryptoAPI = new FallbackCryptoAPI();
            string currencyId = "bitcoin";
            string days = "5";

            // Act
            var result = await cryptoAPI.GetCurrencyHistorycalMarketDataJsonAsync(currencyId, days);

            // Assert
            result.Should().NotBeNullOrEmpty();
        }
    }
}