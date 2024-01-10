using Microsoft.AspNetCore.Mvc;
using Store.Memory;

namespace Store.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository) 
        {
            this.itemRepository = itemRepository;
        }

        public IActionResult Index(int id)
        {
            Item item = itemRepository.GetById(id);

            return View(item);
        }
    }
}
