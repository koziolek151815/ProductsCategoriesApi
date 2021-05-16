using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategoriesApi.Products
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
