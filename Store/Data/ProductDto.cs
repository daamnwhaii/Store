using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string? Brand { get; set; }

        public string ArticleNumber { get; set; }

        public string Description { get; set; }
    }
}
