using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithArticleNumber_CallsGetAllByArticleNumber()
        {
            var productRepositoryStub = new Mock<IProductRepository>();
            productRepositoryStub.Setup(x => x.GetAllByArticleNumber(It.IsAny<string>()))
                              .Returns(new[] { new Product(1, "", "", 0m, "", "") });

            productRepositoryStub.Setup(x => x.GetAllByTitleOrBrand(It.IsAny<string>()))
                              .Returns(new[] { new Product(2, "", "", 0m, "", "") });

            var productService = new ProductService(productRepositoryStub.Object);
            var validArticleNumber = "5547218";

            var actual = productService.GetAllByQuery(validArticleNumber);

            Assert.Collection(actual, product => Assert.Equal(1, product.Id));
        }

        [Fact]
        public void GetAllByQuery_WithBrand_CallsGetAllByTitleOrBrand()
        {
            var productRepositoryStub = new Mock<IProductRepository>();
            productRepositoryStub.Setup(x => x.GetAllByArticleNumber(It.IsAny<string>()))
                              .Returns(new[] { new Product(1, "", "", 0m, "", "") });

            productRepositoryStub.Setup(x => x.GetAllByTitleOrBrand(It.IsAny<string>()))
                              .Returns(new[] { new Product(2, "", "", 0m, "", "") });

            var productService = new ProductService(productRepositoryStub.Object);
            var invalidArticleNumber = "55";

            var actual = productService.GetAllByQuery(invalidArticleNumber);

            Assert.Collection(actual, product => Assert.Equal(2, product.Id));
        }
    }
}
