using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Contractors
{
    public class CourierDelivery : IDeliveryService
    {
        public string UniqueCode => "Courier";

        public string Title => "Доставка курьером";

        public Form CreateForm(Order order)
        {
            throw new NotImplementedException();
        }

        public OrderDelivery GetDelivery(Form form)
        {
            throw new NotImplementedException();
        }

        public Form MoveNextForm(int orderId, int step, IReadOnlyDictionary<string, string> values)
        {
            throw new NotImplementedException();
        }
    }
}
