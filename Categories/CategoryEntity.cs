using ProductsCategoriesApi.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategoriesApi.Categories
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
    }
}
