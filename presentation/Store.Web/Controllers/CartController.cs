using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IItemRepository itemRepository;

        public CartController(IItemRepository itemRepository) 
        {
            this.itemRepository = itemRepository;
        }

        public IActionResult Add(int id)
        {
            var item = itemRepository.GetById(id);
            Cart cart;
            if (!HttpContext.Session.TryGetCart(out cart)) 
            {
                cart = new Cart();
            }
            if (cart.Items.ContainsKey(id))
            {
                cart.Items[id]++;   
            }
            else
            {
                cart.Items[id] = 1;  
            }
            cart.Amount += item.Price;

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Item", new { id });
        }
    }
}
