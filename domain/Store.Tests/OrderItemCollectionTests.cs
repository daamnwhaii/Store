using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class OrderItemCollectionTests
    {
        [Fact]
        public void Get_WithExistingItem_ReturnsItem()
        {    
            var order = CreateTestOrder();

            var orderItem = order.Items.Get(1);

            Assert.Equal(3, orderItem.Count);
        }

        [Fact]
        private static Order CreateTestOrder()
        {
            return new Order(new OrderDto
            {
                Id = 1,
                Items = new List<OrderItemDto>
                {
                    new OrderItemDto { ProductId = 1, Price = 10m, Count = 3},
                    new OrderItemDto { ProductId = 2, Price = 100m, Count = 5},
                }
            });
        }
        [Fact]
        public void Get_WithNonExistingItem_ThrowsInvalidOperationException()
        {
            var order = CreateTestOrder();

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.Items.Get(100);
            });
        }


        [Fact]
        public void Add_WithExistingItem_ThrowInvalidOperationException()
        {
            var order = CreateTestOrder();

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.Items.Add(1, 10m, 10);
            });
        }
    }
}
