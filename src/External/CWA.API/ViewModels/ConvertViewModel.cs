using CWA.Domain.Enteties;

namespace CWA.API.ViewModels
{
    public class ConvertViewModel
    {
        public List<CurrencyBaseViewModel> SourceCurrencies { get; set; }
        public List<string> TargetCurrencies { get; set; }
    }
}
