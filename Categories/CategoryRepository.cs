using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategoriesApi.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext db;

        public CategoryRepository(AppDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CategoryEntity> GetAllCategories()
        {
            return db.Categories;
        }
        public CategoryEntity GetCategoryById(int id)
        {
            return db.Categories.Include(category => category.Products).SingleOrDefault(category => category.Id == id);
        }
        public CategoryEntity AddCategory(CategoryEntity category)
        {
            db.Add(category);
            db.SaveChanges();
            return category;
        }

        public CategoryEntity UpdateProduct(CategoryEntity category, int id)
        {
            CategoryEntity updatedCategory = db.Categories.SingleOrDefault(category => category.Id == id);
            updatedCategory.Name = category.Name;
            db.SaveChanges();
            return updatedCategory;
        }

        public void DeleteCategory(int id)
        {
            CategoryEntity category = db.Categories.SingleOrDefault(category => category.Id == id);
            db.Remove(category);
            db.SaveChanges();
        }
    }
}
