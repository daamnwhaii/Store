using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Web.App
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string? Brand { get; set; }

        //public string Size { get; }

        public string ArticleNumber { get; set; }

        public string Description { get; set; }
    }
}
