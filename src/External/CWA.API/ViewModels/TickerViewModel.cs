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
            PriceInUSD = ticker.PriceInUSD;
        }
        public string Base { get; set; }
        public string Target { get; set; }
        public string MarketName { get; set; }
        public string TradeUrl { get; set; }
        public decimal PriceInUSD { get; set; }
    }
}
