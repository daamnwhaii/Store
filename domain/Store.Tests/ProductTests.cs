namespace Store.Tests
{
    public class ProductTests
    {
        [Fact]
        public void IsArticleNumber_WithNull_ReturnFalse()
        {
            bool actual = Product.IsArticleNumber(null);

            Assert.False(actual);
        }

        [Fact]
        public void IsArticleNumber_WithSpaceString_ReturnFalse()
        {
            bool actual = Product.IsArticleNumber("   ");

            Assert.False(actual);
        }

        [Fact]
        public void IsArticleNumber_WithInvalidArticleNumber_ReturnFalse()
        {
            bool actual = Product.IsArticleNumber("qwerty52");

            Assert.False(actual);
        }

        [Fact]
        public void IsArticleNumber_WithArticleNumber7_ReturnTrue()    //артикул у товаров всегда будет 7-значный
        {
            bool actual = Product.IsArticleNumber("8775324");

            Assert.True(actual);
        }
    }
}