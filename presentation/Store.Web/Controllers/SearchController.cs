using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IItemRepository itemRepository;

        public SearchController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }
        public IActionResult Index(string query)
        {
            var items = itemRepository.GetAllByTitle(query);
            return View(items);
        }
    }
}
