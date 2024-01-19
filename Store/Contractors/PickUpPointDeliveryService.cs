using Store.Contractors;

namespace Store.Web.Controllers
{
    public class PickUpPointDeliveryService : IDeliveryService
    {
        private static IReadOnlyDictionary<string, string> cities = new Dictionary<string, string>
        {
            { "1", "Уфа" },
            { "2", "Стерлитамак" },
        };

        private static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> pickUpPoints = new Dictionary<string, IReadOnlyDictionary<string, string>>
        {
            {
                "1",
                new Dictionary<string, string>
                {
                    { "1", "Гостиный двор" },
                    { "2", "ТЦ Планета" },
                    { "3", "ТЦ Центральный" },
                }
            },
            {
                "2",
                new Dictionary<string, string>
                {
                    { "4", "ТЦ Арбат" },
                    { "5", "ТЦ Сити-молл" },
                    { "6", "ТЦ Фабри" },
                }
            }
        };

        public string UniqueCode => "PickUpPoint";

        public string Title => "Доставка в пункты выдачи в Уфе и Стерлитамаке";

        public Form CreateForm(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return new Form(UniqueCode, order.Id, 1, false, new[]
            {
                new SelectionField("Город", "city", "1", cities),
            });
        }

        public OrderDelivery GetDelivery(Form form)
        {
            if (form.UniqueCode != UniqueCode || !form.IsFinal)
                throw new InvalidOperationException("Invalid form.");

            var cityId = form.Fields
                             .Single(field => field.Name == "city")
                             .Value;
            var cityName = cities[cityId];
            var pickUpPointId = form.Fields
                                    .Single(field => field.Name == "pickUpPoint")
                                    .Value;
            var picUpPointName = pickUpPoints[cityId][pickUpPointId];

            var parameters = new Dictionary<string, string>
            {
                { nameof(cityId), cityId },
                { nameof(cityName), cityName },
                { nameof(pickUpPointId), pickUpPointId },
                { nameof(picUpPointName), picUpPointName },
            };

            var description = $"Город: {cityName}\nПункт выдачи: {picUpPointName}";

            return new OrderDelivery(UniqueCode, description, 150m, parameters);
        }

        public Form MoveNextForm(int orderId, int step, IReadOnlyDictionary<string, string> values)
        {
            if (step == 1)
            {
                if (values["city"] == "1")
                {
                    return new Form(UniqueCode, orderId, 2, false, new Field[]
                    {
                        new HiddenField("Город", "city", "1"),
                        new SelectionField("Пункт выдачи", "pickUpPoint", "1", pickUpPoints["1"]),
                    });
                }
                else if (values["city"] == "2")
                {
                    return new Form(UniqueCode, orderId, 2, false, new Field[]
                    {
                        new HiddenField("Город", "city", "2"),
                        new SelectionField("Пункт выдачи", "pickUpPoint", "4", pickUpPoints["2"]),
                    });
                }
                else
                    throw new InvalidOperationException("Invalid pick-up city.");
            }
            else if (step == 2)
            {
                return new Form(UniqueCode, orderId, 3, true, new Field[]
                {
                    new HiddenField("Город", "city", values["city"]),
                    new HiddenField("Пункт выдачи", "pickUpPoint", values["pickUpPoint"]),
                });
            }
            else
                throw new InvalidOperationException("Invalid pickUpPoint step.");
        }
    }

}
