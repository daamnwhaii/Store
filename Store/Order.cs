using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Order
    {
        public int Id { get; }

        private List<OrderItem> items;

        public IReadOnlyCollection<OrderItem> Items
        {
            get { return items; }
        }
        public int TotalCount
        {
            get { return items.Sum(item => item.Count); }
        }

        public decimal TotalPrice
        {
            get { return items.Sum(item => item.Price * item.Count); }
        }

        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            Id = id;
            this.items = new List<OrderItem>(items);
        }

        public void AddItem(Product product, int count)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var item = items.SingleOrDefault(x => x.ProductId == product.Id);

            if (item == null)
            {
                items.Add(new OrderItem(product.Id, count, product.Price));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(product.Id, item.Count + count, product.Price));
            }
        }

        public void RemoveItem(Product product, int count)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (items.Count == 0)
                throw new InvalidOperationException("Cart must contain items");

            var item = items.SingleOrDefault(x => x.ProductId == product.Id);
            if (item == null)
                throw new InvalidOperationException("Cart does not contain item with ID: " + product.Id);

            items.Remove(item);
            if (item.Count - count == 0)
                return;

            items.Add(new OrderItem(product.Id, item.Count - count, product.Price));
        }

        public void RemoveItems(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (items.Count == 0)
                throw new InvalidOperationException("Cart must contain items");

            var item = items.SingleOrDefault(x => x.ProductId == product.Id);
            if (item == null)
                throw new InvalidOperationException("Cart does not contain item with ID: " + product.Id);

            items.RemoveAll(x => x.ProductId == product.Id);
        }
    }
}