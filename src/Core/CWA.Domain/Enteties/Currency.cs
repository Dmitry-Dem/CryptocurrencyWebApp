namespace CWA.Domain.Enteties
{
    public class Currency : CurrencyBase
    {
        public int Rank { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
