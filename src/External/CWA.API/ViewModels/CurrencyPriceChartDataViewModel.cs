using CWA.Domain.Enteties;

namespace CWA.API.ViewModels
{
    public class CurrencyPriceChartDataViewModel
    {
        public CurrencyPriceChartDataViewModel(CurrencyPriceChartData chartData)
        {
            foreach (var dataPoint in chartData.Prices)
            {
                Prices.Add(new ChartViewModel()
                {
                   Date = DateTimeOffset.FromUnixTimeMilliseconds(dataPoint[0]).DateTime,
                   Price = dataPoint[1]
                });
            }
        }
        public List<ChartViewModel> Prices { get; set; } = new();
    }
}
