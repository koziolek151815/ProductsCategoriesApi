using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategoriesApi.Products
{
    public interface IProductRepository
    {
        public ProductEntity AddProduct(ProductEntity product);
        public ProductEntity GetProductById(int id);
        public IEnumerable<ProductEntity> GetAllProducts();
        public ProductEntity UpdateProduct(ProductEntity product, int id);
        public void DeleteProduct(int id);
    }
}
