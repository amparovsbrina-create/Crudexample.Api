using System.ComponentModel.DataAnnotations;

namespace CrudExample.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Category { get; set; } = string.Empty;
    }
}
