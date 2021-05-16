using ProductsCategoriesApi.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategoriesApi.Products
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
