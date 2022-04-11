using System;
using System.Threading.Tasks;
using GeekShopping.ProductAPI.DTO;
using GeekShopping.ProductAPI.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        
        [HttpGet]
        public async Task<ActionResult<ProductDTO>> FindAll()
        {
            var product = await _repository.FindAll();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create(ProductDTO productDto)
        {
            var product = await _repository.Create(productDto);
            return Ok(product);
        }
        
        [HttpPut]
        public async Task<ActionResult<ProductDTO>> Update(ProductDTO productDto)
        {
            var product = await _repository.Update(productDto);
            return Ok(product);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}