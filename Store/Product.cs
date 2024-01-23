using Store.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Store
{
    public class Product
    {
        private readonly ProductDto dto;

        public int Id => dto.Id;

        public string ArticleNumber
        {
            get => dto.ArticleNumber;
            set => dto.ArticleNumber = value;
        }

        public string Title
        {
            get => dto.Title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Title));

                dto.Title = value.Trim();
            }
        }

        public decimal Price
        {
            get => dto.Price;
            set => dto.Price = value;
        }

        public string Brand
        {
            get => dto.Brand;
            set => dto.Brand = value?.Trim();
        }
        public string Description
        {
            get => dto.Description;
            set => dto.Description = value;
        }
        //public string Size { get; }


        //конструктор с dto
        internal Product(ProductDto dto)
        { 
            this.dto = dto;
        }

        public static bool TryFormatArticleNumber(string articleNumber, out string formattedArticleNumber)
        {
            if (articleNumber == null)
            {
                formattedArticleNumber = null;
                return false;
            }

            formattedArticleNumber = articleNumber.Replace("-", "")
                                .Replace(" ", "")
                                .ToUpper();

            return Regex.IsMatch(formattedArticleNumber, "\\d{7}");  //шаблон, с которым сранивается введенный артикул (7-значное число)
        }

        public static bool IsArticleNumber(string articleNumber)
            => TryFormatArticleNumber(articleNumber, out _);


        public static class DtoFactory
        {
            public static ProductDto Create(string articleNumber,
                                         string title,
                                         string brand,
                                         decimal price,
                                         string description
                                         )
            {
                if (TryFormatArticleNumber(articleNumber, out string formattedIsbn))
                    articleNumber = formattedIsbn;
                else
                    throw new ArgumentException(nameof(articleNumber));

                if (string.IsNullOrWhiteSpace(title))
                    throw new ArgumentException(nameof(title));

                return new ProductDto
                {
                    ArticleNumber = articleNumber,
                    Title = title.Trim(),
                    Brand = brand?.Trim(),
                    Price = price,
                    Description = description?.Trim()
                };
            }
        }

        public static class Mapper
        {
            public static Product Map(ProductDto dto) => new Product(dto);

            public static ProductDto Map(Product domain) => domain.dto;
        }
    }
}
