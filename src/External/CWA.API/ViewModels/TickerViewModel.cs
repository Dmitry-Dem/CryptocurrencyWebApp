using CWA.Domain.Enteties;

namespace CWA.API.ViewModels
{
    public class TickerViewModel
    {
        public TickerViewModel(Ticker ticker)
        {
            Base = ticker.Base;
            Target = ticker.Target;
            MarketName = ticker.MarketName;
            TradeUrl = ticker.TradeUrl;
            PriceInUSD = ticker.PriceInUSD.ToString();
        }
        public string Base { get; set; }
        public string Target { get; set; }
        public string MarketName { get; set; }
        public string TradeUrl { get; set; }

        private string _priceInUSD = string.Empty;
        public string PriceInUSD
        {
            get { return GetFormattedPrice(_priceInUSD, '$'); }
            set { _priceInUSD = value; }
        }
        protected string GetFormattedPrice(string price, char priceSymbol)
        {
            Stack<char> formattedPrice = new Stack<char>();

            int dotIndex = price.IndexOf('.');

            int startIndex = price.Length - 1;

            if (dotIndex != -1)
            {
                startIndex = dotIndex - 1;

                for (int i = price.Length - 1; i >= dotIndex; i--)
                    formattedPrice.Push(price[i]);
            }

            int digitCount = 0;

            for (int i = startIndex; i >= 0; i--)
            {
                if (digitCount >= 3)
                {
                    digitCount = 0;
                    formattedPrice.Push(',');
                }

                formattedPrice.Push(price[i]);
                digitCount++;
            }

            formattedPrice.Push(' ');
            formattedPrice.Push(priceSymbol);

            return new string(formattedPrice.ToArray());
        }
        public static List<TickerViewModel> GetTickerViewModelList(List<Ticker> tickers)
        {
            return tickers.Select(item => new TickerViewModel(item)).ToList();
        }
    }
}
