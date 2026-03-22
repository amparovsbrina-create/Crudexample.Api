using CrudExample.Domain.Entities;
using CrudExample.Domain.Repository;
using CrudExample.Infrastructure.Context;
using CrudExample.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CrudExample.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll() => _context.Products.ToList();

        public Product GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                throw new ProductException($"El producto con Id {id} no existe.");
            return product;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
