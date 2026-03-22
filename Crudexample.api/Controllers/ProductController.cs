using CrudExample.API.DTOs;
using CrudExample.Domain.Repository;
using CrudExample.Domain.Entities; 
using Microsoft.AspNetCore.Mvc;

namespace CrudExample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _repository.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(ProductDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };

            _repository.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDTO dto)
        {
            var product = _repository.GetById(id);
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            _repository.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
