using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class SupplierProductCreateDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }
}
