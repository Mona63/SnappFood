using System.ComponentModel.DataAnnotations;

namespace SnappFood.Model
{
    public class ProductToCreateDto
    {
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Discount { get; set; }
    }
}