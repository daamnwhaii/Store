using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class ItemService
    {
        private readonly IItemRepository itemRepository;

        public ItemService(IItemRepository itemRepository)
        { 
            this.itemRepository = itemRepository;
        }
        public Item[] GetAllByQuery(string query)
        {
            if (Item.IsArticleNumber(query))
            {
                return itemRepository.GetAllByArticleNumber(query);
            }
            else 
            {
                return itemRepository.GetAllByTitleOrBrand(query);
            }
        }
    }
}
