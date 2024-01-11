using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class ItemServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithArticleNumber_CallsGetAllByArticleNumber()
        {
            var itemRepositoryStub = new Mock<IItemRepository>();
            itemRepositoryStub.Setup(x => x.GetAllByArticleNumber(It.IsAny<string>()))
                              .Returns(new[] { new Item(1, "", "", 0m, "", "") });

            itemRepositoryStub.Setup(x => x.GetAllByTitleOrBrand(It.IsAny<string>()))
                              .Returns(new[] { new Item(2, "", "", 0m, "", "") });

            var itemService = new ItemService(itemRepositoryStub.Object);
            var validArticleNumber = "5547218";

            var actual = itemService.GetAllByQuery(validArticleNumber);

            Assert.Collection(actual, item => Assert.Equal(1, item.Id));
        }

        [Fact]
        public void GetAllByQuery_WithBrand_CallsGetAllByTitleOrBrand()
        {
            var itemRepositoryStub = new Mock<IItemRepository>();
            itemRepositoryStub.Setup(x => x.GetAllByArticleNumber(It.IsAny<string>()))
                              .Returns(new[] { new Item(1, "", "", 0m, "", "") });

            itemRepositoryStub.Setup(x => x.GetAllByTitleOrBrand(It.IsAny<string>()))
                              .Returns(new[] { new Item(2, "", "", 0m, "", "") });

            var itemService = new ItemService(itemRepositoryStub.Object);
            var invalidArticleNumber = "55";

            var actual = itemService.GetAllByQuery(invalidArticleNumber);

            Assert.Collection(actual, item => Assert.Equal(2, item.Id));
        }
    }
}
