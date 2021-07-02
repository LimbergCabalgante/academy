using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Dto
{
    public class ProductsWithPageCount
    {
        public List<Product> Products { get; set; }
        public int ProductCount { get; set; }
    }
}
