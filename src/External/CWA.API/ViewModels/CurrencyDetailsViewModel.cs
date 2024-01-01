using CWA.Domain.Enteties;

namespace CWA.API.ViewModels
{
    public class CurrencyDetailsViewModel : CurrencyViewModel
    {
        public CurrencyDetailsViewModel(CurrencyDetails currencyDetails, Currency currency)
        {
            Id = currencyDetails.Id;
            Name = currencyDetails.Name;
            Rank = currencyDetails.Rank;
            Symbol = currencyDetails.Symbol;
            ImageUrl = currencyDetails.ImageUrl;
            Price = currencyDetails.Price;

            FullyDilutedValuation = currencyDetails.FullyDilutedValuation;
            CirculatingSupply = currencyDetails.CirculatingSupply;
            MarketCap = currencyDetails.MarketCap;
            TotalSupply = currencyDetails.TotalSupply;
            TotalVolume = currencyDetails.TotalVolume;
        }
        public decimal FullyDilutedValuation { get; set; }
        public decimal CirculatingSupply { get; set; }
        public decimal MarketCap { get; set; }
        public decimal TotalVolume { get; set; }
        public decimal TotalSupply { get; set; }
    }
}
