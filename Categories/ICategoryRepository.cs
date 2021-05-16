using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategoriesApi.Categories
{
    public interface ICategoryRepository
    {
        public IEnumerable<CategoryEntity> GetAllCategories();
        public CategoryEntity GetCategoryById(int id);
        public CategoryEntity AddCategory(CategoryEntity category);
        public CategoryEntity UpdateProduct(CategoryEntity category, int id);
        public void DeleteCategory(int id);
    }
}
