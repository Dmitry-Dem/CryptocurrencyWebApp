using CWA.Domain.Enteties;

namespace CWA.API.ViewModels
{
    public class CurrencyViewModel
    {
        public CurrencyViewModel()
        {
            
        }
        public CurrencyViewModel(Currency currency)
        {
            Id = currency.Id;
            Name = currency.Name;
            Rank = currency.Rank;
            Symbol = currency.Symbol;
            ImageUrl = currency.ImageUrl;
            Price = currency.Price.ToString();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }

        private string _price;
        public string Price
        {
            get { return "$" + _price; }
            set { _price = value; }
        }
        public string ImageUrl { get; set; }
        public string Symbol { get; set; }
        public static List<CurrencyViewModel> GetCurrencyViewModelList(List<Currency> currencies)
        {
            return currencies.Select(item => new CurrencyViewModel(item)).ToList();
        }
    }
}
