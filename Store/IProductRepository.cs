using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IProductRepository
    {

        // TODO: метод для поиска товаров по артиклю
        Product[] GetAllByArticleNumber(string articleNumber);

        Product[] GetAllByTitleOrBrand(string titleOrBrand);

        Product GetById(int id);
    }
}
