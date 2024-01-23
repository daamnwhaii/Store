using Store.Contractors;

namespace Store.Contractors
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

        public string Name => "PickUpPoint";

        public string Title => "Доставка в пункты выдачи в Уфе и Стерлитамаке";

        public Form FirstForm(Order order)
        {
            return Form.CreateFirst(Name)
                       .AddParameter("orderId", order.Id.ToString())
                       .AddField(new SelectionField("Город", "city", "1", cities));
        }

        public Form NextForm(int step, IReadOnlyDictionary<string, string> values)
        {
            if (step == 1)
            {
                if (values["city"] == "1")
                {
                    return Form.CreateNext(Name, 2, values)
                               .AddField(new SelectionField("Пункт выдачи", "pickUpPoint", "1", pickUpPoints["1"]));
                }
                else if (values["city"] == "2")
                {
                    return Form.CreateNext(Name, 2, values)
                               .AddField(new SelectionField("Пункт выдачи", "pickUpPoint", "4", pickUpPoints["2"]));
                }
                else
                    throw new InvalidOperationException("Invalid pick-up points city.");
            }
            else if (step == 2)
            {
                return Form.CreateLast(Name, 3, values);
            }
            else
                throw new InvalidOperationException("Invalid pick-up points step.");
        }

        public OrderDelivery GetDelivery(Form form)
        {
            if (form.ServiceName != Name || !form.IsFinal)
                throw new InvalidOperationException("Invalid form.");

            var cityId = form.Parameters["city"];
            var cityName = cities[cityId];
            var pickUpPointId = form.Parameters["pickUpPoint"];
            var pickUpPointName = pickUpPoints[cityId][pickUpPointId];

            var parameters = new Dictionary<string, string>
            {
                { nameof(cityId), cityId },
                { nameof(cityName), cityName },
                { nameof(pickUpPointId), pickUpPointId },
                { nameof(pickUpPointName), pickUpPointName },
            };

            var description = $"Город: {cityName}\nПункт выдачи: {pickUpPointName}";

            return new OrderDelivery(Name, description, 150m, parameters);
        }
    }

}
