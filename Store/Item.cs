using System.Diagnostics;

namespace Store
{
    public class Item
    {
        public int Id { get; }

        public string Title { get; }

        public string? Brand { get; }
        public int Price { get; }

        public Item(int id, string title, string? brand, int price)
        {
            Id = id;
            Title = title;
            Brand = brand;
            Price = price;
        }
    }
}
