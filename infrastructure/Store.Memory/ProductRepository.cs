namespace Store.Memory
{
    public class ProductRepository : IProductRepository
    {
        private readonly Product[] items = new[]
        {
            new Product(1, "Shirt", "Puma", 3200.00m, "8887771", "Decription 1"),
            new Product(2, "Sneakers", "Nike", 7500.00m, "5458872", "Decription 2"),
            new Product(3, "Socks", "Nike", 990.00m, "1124783", "Decription 3"),
            new Product(4, "Jacket", "Stone Island", 11000.00m, "3001774", "Decription 4"),
            new Product(5, "Socks", "Puma", 890.00m, "2121775", "Decription 5"),
            new Product(6, "Shirt", "Nike", 3300.00m, "7777776", "Decription 6"),
            new Product(7, "Sneakers", "Adidas", 8700.00m, "9998727", "Decription 7"),
            new Product(8, "Socks", "Adidas", 990.00m, "3301148", "Decription 8"),
            new Product(9, "Sneakers", "New Balance", 6800.00m, "8661579", "Decription 9"),
            new Product(10, "Down jacket", "The North Face", 15000.00m, "2200220","Decription 10"),
        };

        //public Item[] GetAllByTitle(string itemTitleOrBrand) // принимает название или часть  названия товара
        //{
        //    return items.Where(item => item.Title.Contains(itemTitle))
        //                .ToArray();
        //}

        public Product[] GetAllByArticleNumber(string articleNumber)
        {
            return items.Where(item => item.ArticleNumber == articleNumber)
                        .ToArray();
        }

        public Product[] GetAllByTitleOrBrand(string query)
        {
            return items.Where(item => item.Title.Contains(query) 
                                    || item.Brand.Contains(query))
                        .ToArray();
        }

        public Product GetById(int id)
        {
            return items.Single(item => item.Id == id);
        }
    }
}
