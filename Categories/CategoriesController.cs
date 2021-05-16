using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsCategoriesApi.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsCategoriesApi.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<CategoryResponseDto> Get()
        {
            return categoryService.GetAllCategories();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public CategoryResponseDto Get(int id)
        {
            return categoryService.GetCategoryById(id);
        }

        

        // POST api/<CategoriesController>
        [HttpPost]
        public CategoryResponseDto Post([FromBody] CategoryRequestDto categoryRequestDto)
        {
            return categoryService.AddCategory(categoryRequestDto);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public CategoryResponseDto Put([FromBody] CategoryRequestDto categoryRequestDto, int id)
        {
            return categoryService.UpdateProduct(categoryRequestDto, id);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            categoryService.DeleteCategory(id);
        }
    }
}
