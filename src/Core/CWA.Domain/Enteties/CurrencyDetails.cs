namespace CWA.Domain.Enteties
{
    public class CurrencyDetails : Currency
    {
        public decimal FullyDilutedValuation { get; set; }
        public decimal CirculatingSupply { get; set; }
        public decimal MarketCap { get; set; }
        public decimal TotalVolume { get; set; }
        public decimal TotalSupply { get; set; }
    }
}
