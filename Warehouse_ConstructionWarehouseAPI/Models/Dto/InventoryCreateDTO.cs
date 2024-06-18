using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class InventoryCreateDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int PremiseId { get; set; }
    }
}
