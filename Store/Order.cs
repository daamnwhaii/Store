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

        public void AddItem(Item item, int count)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var _item = items.SingleOrDefault(x => x.ItemId == item.Id);

            if (_item == null)
            {
                items.Add(new OrderItem(item.Id, count, item.Price));
            }
            else
            {
                items.Remove(_item);
                items.Add(new OrderItem(item.Id, _item.Count + count, item.Price));
            }
        }
    }
}