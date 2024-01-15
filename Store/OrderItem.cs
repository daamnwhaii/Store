using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class OrderItem
    {
        public int ItemId { get; }

        public int Count { get; }

        public decimal Price { get; }

        public OrderItem(int itemId, int count, decimal price)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count must be greater than zero.");
            }

            ItemId = itemId;
            Count = count;
            Price = price;
        }
    }
}