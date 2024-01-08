using CWA.Domain.Enteties;

namespace CWA.API.ViewModels
{
    public class CurrencyDetailsViewModel : CurrencyViewModel
    {
        public CurrencyDetailsViewModel(CurrencyDetails currencyDetails)
        {
            Id = currencyDetails.Id;
            Name = currencyDetails.Name;
            Rank = currencyDetails.Rank;
            Symbol = currencyDetails.Symbol;
            ImageUrl = currencyDetails.ImageUrl;
            Price = currencyDetails.Price.ToString();

            FullyDilutedValuation = currencyDetails.FullyDilutedValuation.ToString();
            CirculatingSupply = currencyDetails.CirculatingSupply.ToString();
            MarketCap = currencyDetails.MarketCap.ToString();
            TotalSupply = currencyDetails.TotalSupply.ToString();
            TotalVolume = currencyDetails.TotalVolume.ToString();
        }

        private string _fullyDilutedValuation;
        public string FullyDilutedValuation
        {
            get { return GetFormattedPrice(_fullyDilutedValuation, BasePriceChar); }
            set { _fullyDilutedValuation = value; }
        }

        private string _circulatingSupply;
        public string CirculatingSupply
        {
            get { return GetFormattedPrice(_circulatingSupply, BasePriceChar); ; }
            set { _circulatingSupply = value; }
        }

        private string _marketCap;
        public string MarketCap
        {
            get { return GetFormattedPrice(_marketCap, BasePriceChar); ; }
            set { _marketCap = value; }
        }

        private string _totalVolume;
        public string TotalVolume
        {
            get { return GetFormattedPrice(_totalVolume, BasePriceChar); ; }
            set { _totalVolume = value; }
        }

        private string _totalSupply;
        public string TotalSupply
        {
            get { return GetFormattedPrice(_totalSupply, BasePriceChar); ; }
            set { _totalSupply = value; }
        }
    }
}
