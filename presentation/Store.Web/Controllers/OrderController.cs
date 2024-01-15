using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IItemRepository itemRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(IItemRepository itemRepository, IOrderRepository orderRepository)
        {
            this.itemRepository = itemRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index() 
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepository.GetById(cart.OrderId);
                OrderModel model = null;

                return View(model);
            }
            return View("Empty");
        }

        //private OrderModel Map(Order order) 
        //{
        //    var itemIds = order.Items.Select(item => item.ItemId);
        //    var items = itemRepository.GetAllByIds(itemIds);
        //    var itemModels = from item in order.Items
        //                     join item in items on item.ItemId equals item.OrderId
        //                     select new OrderItemModel
        //                     {
        //                         ItemId = item.ItemId,
        //                         Title = item.Title,
        //                         Brand = item.Brand,
        //                         Price = item.Price,
        //                         Count = item.Count,
        //                     };
        //}

        public IActionResult AddItem(int id)
        {
            Order order;
            Cart cart;

            if (HttpContext.Session.TryGetCart(out cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }

            var item = itemRepository.GetById(id);
            order.AddItem(item, 1);
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;
            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Item", new { id });
        }
    }
}
