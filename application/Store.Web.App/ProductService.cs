using Store.Web.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Web.App
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        { 
            this.productRepository = productRepository;
        }
        public ProductModel GetById(int id)
        {
            var product = productRepository.GetById(id);

            return Map(product);
        }

        public IReadOnlyCollection<ProductModel> GetAllByQuery(string query)
        {
            var products = Product.IsArticleNumber(query)
                           ? productRepository.GetAllByArticleNumber(query)
                           : productRepository.GetAllByTitleOrBrand(query);

            return products.Select(Map)
                           .ToArray();
        }

        private ProductModel Map(Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                ArticleNumber = product.ArticleNumber,
                Title = product.Title,
                Brand = product.Brand,
                Description = product.Description,
                Price = product.Price,
            };
        }
    }
}
