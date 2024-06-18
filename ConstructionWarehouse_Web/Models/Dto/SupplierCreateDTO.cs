using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class SupplierCreateDTO
    {
        [Required]
        public string SupplierName { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
