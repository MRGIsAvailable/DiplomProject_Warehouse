using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int PremiseId { get; set; }
        public ProductDTO Product { get; set; }
        public PremiseDTO Premise { get; set; }
    }
}
