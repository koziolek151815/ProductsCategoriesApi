using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsCategoriesApi.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryResponseDto> GetAllCategories()
        {
            return categoryRepository.GetAllCategories().Select(category => new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            });
        }

        public CategoryResponseDto GetCategoryById(int id)
        {
            CategoryEntity category = categoryRepository.GetCategoryById(id);
            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public CategoryResponseDto AddCategory(CategoryRequestDto categoryRequestDto)
        {
            CategoryEntity savedCategory = categoryRepository.AddCategory(new CategoryEntity
            {
                Name = categoryRequestDto.Name
            });
            return new CategoryResponseDto
            {
                Id = savedCategory.Id,
                Name = savedCategory.Name
            };
        }

        public CategoryResponseDto UpdateProduct(CategoryRequestDto categoryRequestDto, int id)
        {
            CategoryEntity updatedCategory = categoryRepository.UpdateProduct(new CategoryEntity
            {
                Name = categoryRequestDto.Name,
            }, id);
            return new CategoryResponseDto
            {
                Id = updatedCategory.Id,
                Name = updatedCategory.Name,
            };
        }

        public void DeleteCategory(int id)
        {
            categoryRepository.DeleteCategory(id);
        }
    }
}
