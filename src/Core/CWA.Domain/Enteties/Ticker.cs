namespace CWA.Domain.Enteties
{
    public class Ticker
    {
        public string Base { get; set; }
        public string Target { get; set; }
        public string MarketName { get; set; }
        public string TradeUrl { get; set; }
        public decimal PriceInUSD { get; set; }
    }
}
