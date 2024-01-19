using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Store
{
    public class Product
    {
        public int Id { get; }

        public string Title { get; }

        public decimal Price { get; }

        public string? Brand { get; }

        //public string Size { get; }

        public string ArticleNumber {  get; }

        public string Description { get; }

        public Product(int id, string title, string? brand, decimal price, string articleNumber, string description)
        {
            Id = id;
            Title = title;
            Brand = brand;
            Price = price;
            ArticleNumber = articleNumber;
            Description = description;
        }

        internal static bool IsArticleNumber(string str)     //метод, определяющий является ли введенная строка артикулом
        {
            if (str == null)
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(str, "\\d{7}");     //шаблон, с которым сранивается введенный артикул (7-значное число)
            }
        }
    }
}
