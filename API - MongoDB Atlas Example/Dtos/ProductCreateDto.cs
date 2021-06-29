using System.ComponentModel.DataAnnotations;

namespace Homework2.Dtos
{
    public class ProductCreateDto
    {
        [MaxLength(20)]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Manufacturer is required.")]
        public string Manufacturer { get; set; }

        public double Price { get; set; }

        public double WholesalePrice { get; set; }
    }
}