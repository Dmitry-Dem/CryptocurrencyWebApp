using CWA.Domain.Enteties;

namespace CWA.API.ViewModels
{
    public class CurrencyViewModel : CurrencyBaseViewModel
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
        public int Rank { get; set; }

        private string _price = string.Empty;
        public string Price
        {
            get { return GetFormattedPrice(_price, BasePriceChar); }
            set { _price = value; }
        }
        public string ImageUrl { get; set; } = string.Empty;
        protected string GetFormattedPrice(string price, char priceSymbol)
        {
            Stack<char> formattedPrice = new Stack<char>();

            int dotOrCommaIndex = price.IndexOf('.') == -1 ? price.IndexOf(",") : price.IndexOf(".");

            int startIndex = price.Length - 1;

            if (dotOrCommaIndex != -1)
            {
                startIndex = dotOrCommaIndex - 1;

                for (int i = price.Length - 1; i >= dotOrCommaIndex; i--)
                    formattedPrice.Push(price[i]);
            }

            int digitCount = 0;

            for (int i = startIndex; i >= 0; i--)
            {
                if (digitCount >= 3)
                {
                    digitCount = 0;
                    formattedPrice.Push(',');
                }

                formattedPrice.Push(price[i]);
                digitCount++;
            }

            formattedPrice.Push(' ');
            formattedPrice.Push(priceSymbol);

            return new string(formattedPrice.ToArray());
        }
        public static List<CurrencyViewModel> GetCurrencyViewModelList(List<Currency> currencies)
        {
            return currencies.Select(item => new CurrencyViewModel(item)).ToList();
        }
    }
}
