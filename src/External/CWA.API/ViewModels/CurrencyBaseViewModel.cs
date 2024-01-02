using CWA.Domain.Enteties;

namespace CWA.API.ViewModels
{
    public class CurrencyBaseViewModel
    {
        public CurrencyBaseViewModel(CurrencyBase currency)
        {
            Id = currency.Id;
            Name = currency.Name;
            Symbol = currency.Symbol;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public static List<CurrencyBaseViewModel> GetCurrencyBaseViewModelList(List<CurrencyBase> currencies)
        {
            return currencies.Select(item => new CurrencyBaseViewModel(item)).ToList();
        }
    }
}
