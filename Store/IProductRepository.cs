using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IProductRepository
    {
        Product[] GetAllByArticleNumber(string articleNumber);

        Product[] GetAllByTitleOrBrand(string titleOrBrand);

        Product GetById(int id);

        Product[] GetAllByIds(IEnumerable<int> productIds);
    }
}
