namespace Store.Memory
{
    public class ItemRepository : IItemRepository
    {
        private readonly Item[] items = new[]
        {
            new Item(1, "Shirt", "Puma", "8887771"),
            new Item(2, "Sneakers", "Nike", "5458872"),
            new Item(3, "Socks", "Nike", "1124783"),
            new Item(4, "Jacket", "Stone Island", "3001774"),
            new Item(5, "Socks", "Puma", "2121775"),
            new Item(6, "Shirt", "Nike", "7777776"),
            new Item(7, "Sneakers", "Adidas", "9998727"),
            new Item(8, "Socks", "Adidas", "3301148"),
            new Item(9, "Sneakers", "New Balance", "8661579"),
            new Item(10, "Down jacket", "The North Face", "2200220"),
        };

        //public Item[] GetAllByTitle(string itemTitleOrBrand) // принимает название или часть  названия товара
        //{
        //    return items.Where(item => item.Title.Contains(itemTitle))
        //                .ToArray();
        //}

        public Item[] GetAllByArticleNumber(string articleNumber)
        {
            return items.Where(item => item.ArticleNumber == articleNumber)
                        .ToArray();
        }

        public Item[] GetAllByTitleOrBrand(string query)
        {
            return items.Where(item => item.Title.Contains(query) 
                                    || item.Brand.Contains(query))
                        .ToArray();
        }
    }
}
