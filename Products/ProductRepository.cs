using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategoriesApi.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext db;

        public ProductRepository(AppDbContext db)
        {
            this.db = db;
        }

        public ProductEntity AddProduct(ProductEntity product)
        {
            db.Add(product);
            db.SaveChanges();
            return product;
        }
        public ProductEntity GetProductById(int id)
        {
            return db.Products.Include(product => product.Category).SingleOrDefault(product => product.Id == id);
        }
        public IEnumerable<ProductEntity> GetAllProducts()
        {
            return db.Products.Include(product => product.Category);
        }
        public ProductEntity UpdateProduct(ProductEntity product, int id)
        {
            ProductEntity updatedProduct = db.Products.Include(product => product.Category).SingleOrDefault(product => product.Id == id);
            updatedProduct.Name = product.Name;
            updatedProduct.Category = product.Category;
            db.SaveChanges();
            return updatedProduct;
        }
        public void DeleteProduct(int id)
        {
            ProductEntity product = db.Products.SingleOrDefault(product => product.Id == id);
            db.Remove(product);
            db.SaveChanges();
        }
    }
}
