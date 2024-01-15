using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class OrderItem
    {
        public int ProductId { get; }

        public int Count { get; }

        public decimal Price { get; }

        public OrderItem(int productId, int count, decimal price)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count must be greater than zero.");
            }

            ProductId = productId;
            Count = count;
            Price = price;
        }
    }
}