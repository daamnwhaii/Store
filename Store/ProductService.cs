using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        { 
            this.productRepository = productRepository;
        }
        public Product[] GetAllByQuery(string query)
        {
            if (Product.IsArticleNumber(query))
            {
                return productRepository.GetAllByArticleNumber(query);
            }
            else 
            {
                return productRepository.GetAllByTitleOrBrand(query);
            }
        }
    }
}
