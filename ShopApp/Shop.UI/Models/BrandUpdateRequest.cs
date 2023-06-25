using System.ComponentModel.DataAnnotations;

namespace Shop.UI.Models
{
    public class BrandUpdateRequest
    {
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
