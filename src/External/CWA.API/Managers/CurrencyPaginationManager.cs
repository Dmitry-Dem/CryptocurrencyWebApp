using CWA.API.ViewModels;

namespace CWA.API.Managers
{
    public class CurrencyPaginationManager
    {
        private int _currencyCountPerPage;
        public int CurrencyCountPerPage
        {
            get { return _currencyCountPerPage; }
            init {
                if (value <= 0)
                    throw new ArgumentException("CurrencyCountPerPage can't be <= 0");

                _currencyCountPerPage = value; 
            }
        }

        private int _currentPage;
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("CurrentPage can't be <= 0");

                _currentPage = value;
            }
        }
        public CurrencyPaginationManager(int currencyCountPerPage = 50, int currentPage = 1)
        {
            CurrencyCountPerPage = currencyCountPerPage;
            CurrentPage = currentPage;
        }
        public List<CurrencyViewModel> GetCurrenciesByPageNum(List<CurrencyViewModel> currencies, int pageNum)
        {
            if (pageNum <= 0)
                throw new ArgumentException("pageNum can't be <= 0");

            int currencyCount = (pageNum * _currencyCountPerPage);

            int startIndex = currencyCount - _currencyCountPerPage;

            var newCurrencies = new List<CurrencyViewModel>(_currencyCountPerPage);


            if (currencies.Count < currencyCount)
                return new List<CurrencyViewModel>();


            for (int i = startIndex; i < currencyCount; i++)
                newCurrencies.Add(currencies[i]);

            return newCurrencies;
        }
    }
}
