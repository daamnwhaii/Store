using System.Diagnostics;

namespace Store
{
    public class Item
    {
        public int Id { get; }

        public string Title { get; }

        public int Price { get; }

        public string? Brand { get; }
 
        public string ArticleNumber {  get; }

        public Item(int id, string title, string? brand, int price, string articleNumber)
        {
            Id = id;
            Title = title;
            Brand = brand;
            Price = price;
            ArticleNumber = articleNumber;
        }
    }
}
