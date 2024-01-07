using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IItemRepository
    {

        // TODO: метод для поиска товаров по артиклю
        Item[] GetAllByArticleNumber(string articleNumber);

        Item[] GetAllByTitleOrBrand(string titleOrBrand);


        


    }
}
