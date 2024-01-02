using CWA.Domain.Enteties;

namespace CWA.API.ViewModels
{
    public class ConvertViewModel
    {
        public List<CurrencyBase> SourceCurrencies { get; set; }
        public List<string> TargetCurrencies { get; set; }
    }
}
