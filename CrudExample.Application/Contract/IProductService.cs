using CrudExample.Application.Dtos;

namespace CrudExample.Application.Contract
{
    public interface IProductService
    {
        ProductDto AddProduct(ProductDto productDto);
        ProductDto UpdateProduct(ProductDto productDto);
        void DeleteProduct(int id);
        ProductDto GetProductById(int id);
        IEnumerable<ProductDto> GetAllProducts();
    }
}
