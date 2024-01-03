namespace CWA.API.ViewModels
{
    public class CurrencyDetailsPageViewModel
    {
        public CurrencyDetailsViewModel CurrencyDetails { get; set; }
        public List<TickerViewModel> Markets { get; set; }
        public CurrencyPriceChartDataViewModel CurrencyPrices { get; set; }
    }
}
