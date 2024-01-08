namespace Store.Memory
{
    public class ItemRepository : IItemRepository
    {
        private readonly Item[] items = new[]
        {
            new Item(1, "Shirt", "Puma" , 1500, "8887771"),
            new Item(2, "Sneakers", "Nike", 4500, "5458872"),
            new Item(3, "Socks", "Nike", 900, "1124783"),
            new Item(4, "Jacket", "Stone Island", 8000, "3001774"),
            new Item(5, "Socks", "Puma", 700, "2121775"),
            new Item(6, "Shirt", "Nike", 1700, "7777776"),
            new Item(7, "Sneakers", "Adidas", 7800, "9998727"),
            new Item(8, "Socks", "Adidas", 1000, "3301148"),
            new Item(9, "Sneakers", "New Balance", 4500, "8661579"),
            new Item(10, "Down jacket", "The North Face", 17500, "2200220"),
        };

        public Item[] GetAllByTitle(string itemTitle) // принимает название или часть  названия товара
        {
            return items.Where(item => item.Title.Contains(itemTitle))
                        .ToArray();
        }

        public Item[] GetAllByArticleNumber(string articleNumber)
        {
            throw new NotImplementedException();
        }

        public Item[] GetAllByTitleOrBrand(string titleOrBrand)
        {
            throw new NotImplementedException();
        }
    }
}
