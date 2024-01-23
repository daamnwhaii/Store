﻿using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = 0;
                OrderItem.DtoFactory.Create(new OrderDto(), 1, 10m, count);
            });
        }

        [Fact]
        public void OrderItem_WithNegativeCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = -1;
                OrderItem.DtoFactory.Create(new OrderDto(), 1, 10m, count);
            });
        }

        [Fact]
        public void OrderItem_WithPositiveCount_SetsCount()
        {
            var orderItem = OrderItem.DtoFactory.Create(new OrderDto(), 1, 10m, 2);

            Assert.Equal(1, orderItem.ProductId);
            Assert.Equal(10m, orderItem.Price);
            Assert.Equal(2, orderItem.Count);
        }
    }
}