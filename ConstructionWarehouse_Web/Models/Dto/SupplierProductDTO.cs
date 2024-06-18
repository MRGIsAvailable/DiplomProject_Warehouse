using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class SupplierProductDTO
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int SupplierId { get; set; }
        public ProductDTO Product { get; set; }
        public SupplierDTO Supplier { get; set; }

    }
}
