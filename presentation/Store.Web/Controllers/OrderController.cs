using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            this.productRepository = productRepository;
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
        //    var productIds = order.Items.Select(item => item.ProductId);
        //    var products = productRepository.GetAllByIds(productIds);
        //    var itemModels = from item in order.Items
        //                     join product in products on item.ProductId equals product.OrderId
        //                     select new OrderItemModel
        //                     {
        //                         ItemId = product.ItemId,
        //                         Title = product.Title,
        //                         Brand = product.Brand,
        //                         Price = product.Price,
        //                         Count = product.Count,
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

            var product = productRepository.GetById(id);
            order.AddItem(product, 1);
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;
            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Product", new { id });
        }
    }
}
