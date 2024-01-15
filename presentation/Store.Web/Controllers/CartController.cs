using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IItemRepository itemRepository;
        private readonly IOrderRepository orderRepository;

        public CartController(IItemRepository itemRepository, IOrderRepository orderRepository)
        {
            this.itemRepository = itemRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Add(int id)
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
