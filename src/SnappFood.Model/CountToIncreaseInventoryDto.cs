using System.ComponentModel.DataAnnotations;

namespace SnappFood.Model
{
    public class CountToIncreaseInventoryDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int count { get; set; }


    }
}
