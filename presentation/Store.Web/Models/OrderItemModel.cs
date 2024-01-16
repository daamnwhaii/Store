namespace Store.Web.Models
{
    public class OrderItemModel
    {
        public int ItemId { get; set; }

        public string Title { get; set; }

        public string Brand { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }
    }
}
