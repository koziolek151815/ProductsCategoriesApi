using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategoriesApi.Categories
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryResponseDto> GetAllCategories();

        public CategoryResponseDto GetCategoryById(int id);

        public CategoryResponseDto AddCategory(CategoryRequestDto categoryRequestDto);

        public CategoryResponseDto UpdateProduct(CategoryRequestDto categoryRequestDto, int id);

        public void DeleteCategory(int id);
    }
}
