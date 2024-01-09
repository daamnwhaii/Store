using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Store
{
    public class Item
    {
        public int Id { get; }

        public string Title { get; }

        //public int Price { get; }

        public string? Brand { get; }
 
        public string ArticleNumber {  get; }

        public Item(int id, string title, string? brand, string articleNumber)
        {
            Id = id;
            Title = title;
            Brand = brand;
            //Price = price;
            ArticleNumber = articleNumber;
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
