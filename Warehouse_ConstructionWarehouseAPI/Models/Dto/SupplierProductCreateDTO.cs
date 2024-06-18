using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class SupplierProductCreateDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }
}
