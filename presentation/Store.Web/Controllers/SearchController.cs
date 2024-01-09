using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ItemService itemService;

        public SearchController(ItemService itemService)
        {
            this.itemService = itemService;
        }
        public IActionResult Index(string query)
        {
            var items = itemService.GetAllByQuery(query);
            return View(items);
        }
    }
}
