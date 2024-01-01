using CWA.Domain.Enteties;

namespace CWA.API.ViewModels
{
    public class CurrencyPriceChartDataViewModel
    {
        public CurrencyPriceChartDataViewModel(CurrencyPriceChartData chartData)
        {
            Prices = chartData.Prices;
        }
        public List<List<decimal>> Prices { get; set; }
    }
}
