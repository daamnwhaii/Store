namespace Store.Web.App
{
    public class OrderItemModel
    {
        public int ProductId { get; set; }

        public string Title { get; set; }

        public string Brand { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }
    }
}
