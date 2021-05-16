using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategoriesApi.Products
{
    public interface IProductService
    {
        public ProductResponseDto AddProduct(ProductRequestDto productRequestDto);

        public ProductResponseDto GetProductById(int id);

        public IEnumerable<ProductResponseDto> GetAllProducts();

        public ProductResponseDto UpdateProduct(ProductRequestDto productRequestDto, int id);

        public void DeleteProduct(int id);
    }
}
