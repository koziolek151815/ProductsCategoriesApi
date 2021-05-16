using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsCategoriesApi.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductResponseDto> Get()
        {
            return productService.GetAllProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ProductResponseDto Get(int id)
        {
            return productService.GetProductById(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ProductResponseDto Post([FromBody] ProductRequestDto productRequestDto)
        {
            return productService.AddProduct(productRequestDto);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ProductResponseDto Put([FromBody] ProductRequestDto productRequestDto, int id)
        {
            return productService.UpdateProduct(productRequestDto, id);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productService.DeleteProduct(id);
        }
    }
}
