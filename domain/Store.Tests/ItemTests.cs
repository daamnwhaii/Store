namespace Store.Tests
{
    public class ItemTests
    {
        [Fact]
        public void IsArticleNumber_WithNull_ReturnFalse()
        {
            bool actual = Item.IsArticleNumber(null);

            Assert.False(actual);
        }

        [Fact]
        public void IsArticleNumber_WithSpaceString_ReturnFalse()
        {
            bool actual = Item.IsArticleNumber("   ");

            Assert.False(actual);
        }

        [Fact]
        public void IsArticleNumber_WithInvalidArticleNumber_ReturnFalse()
        {
            bool actual = Item.IsArticleNumber("qwerty52");

            Assert.False(actual);
        }

        [Fact]
        public void IsArticleNumber_WithArticleNumber7_ReturnTrue()    //артикул у товаров всегда будет 7-значный
        {
            bool actual = Item.IsArticleNumber("8775324");

            Assert.True(actual);
        }
    }
}