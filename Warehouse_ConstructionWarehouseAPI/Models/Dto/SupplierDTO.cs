using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class SupplierDTO
    {
        public int Id { get; set; }
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
