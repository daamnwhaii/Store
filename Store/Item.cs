using System.Diagnostics;

namespace Store
{
    public class Item
    {
        public int Id { get; }

        public string Title { get; }

        public Item(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
