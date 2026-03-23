using CrudExample.Application.Contract;
using CrudExample.Application.Dtos;
using CrudExample.Domain.Entities;
using CrudExample.Infrastructure.Repositories;

namespace CrudExample.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public ProductDto AddProduct(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category
            };

            _repository.Add(product);
            dto.Id = product.Id;
            return dto;
        }

        public ProductDto UpdateProduct(ProductDto dto)
        {
            var product = _repository.GetById(dto.Id);
            if (product == null) throw new Exception("Producto no encontrado");

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Category = dto.Category;

            _repository.Update(product);
            return dto;
        }

        public void DeleteProduct(int id) => _repository.Delete(id);

        public ProductDto GetProductById(int id)
        {
            var p = _repository.GetById(id);
            if (p == null) throw new Exception("Producto no encontrado");

            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.Category
            };
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _repository.GetAll().Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.Category
            });
        }
    }
}
