namespace Store.Web.Models
{
    public class Cart
    {
        public IDictionary<int, int> Items { get; set; } = new Dictionary<int, int>(); // int1 - id товара, int2 - кол-во товаров в корзине

        public decimal Amount { get; set; }
    }
}
