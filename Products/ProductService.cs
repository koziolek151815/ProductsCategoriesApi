using ProductsCategoriesApi.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategoriesApi.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly AppDbContext db;

        public ProductService(IProductRepository productRepository, AppDbContext db)
        {
            this.productRepository = productRepository;
            this.db = db;
        }

        public ProductResponseDto AddProduct(ProductRequestDto productRequestDto)
        {
            CategoryEntity category = db.Categories.SingleOrDefault(category => category.Id == productRequestDto.CategoryId);
            ProductEntity savedProduct = productRepository.AddProduct(new ProductEntity
            {
                Name = productRequestDto.Name,
                Category = category
            });

            return new ProductResponseDto 
            {
                Id = savedProduct.Id,
                Name = savedProduct.Name,
                Category = new CategoryResponseDto
                {
                    Id = savedProduct.Category.Id,
                    Name = savedProduct.Category.Name
                }
            };
        }

        public ProductResponseDto GetProductById(int id)
        {
            ProductEntity product = productRepository.GetProductById(id);
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = new CategoryResponseDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            };
        }

        public IEnumerable<ProductResponseDto> GetAllProducts()
        {
            return productRepository.GetAllProducts().Select(product => new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = new CategoryResponseDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            });
        }

        public ProductResponseDto UpdateProduct(ProductRequestDto productRequestDto, int id)
        {
            CategoryEntity category = db.Categories.SingleOrDefault(category => category.Id == productRequestDto.CategoryId);
            ProductEntity updatedProduct = productRepository.UpdateProduct(new ProductEntity
            {
                Name = productRequestDto.Name,
                Category = category
            },id);
            return new ProductResponseDto
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                Category = new CategoryResponseDto
                {
                    Id = updatedProduct.Category.Id,
                    Name = updatedProduct.Category.Name
                }
            };
        }

        public void DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
        }
    }
}
