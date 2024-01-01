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
            Price = currency.Price;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public string Symbol { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
