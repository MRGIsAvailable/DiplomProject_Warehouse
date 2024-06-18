using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class ProductCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        public string Details { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
