namespace CrudExample.Infrastructure.Models
{
    public class ProductModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
