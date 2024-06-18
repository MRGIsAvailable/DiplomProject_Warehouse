using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class InventoryUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int PremiseId { get; set; }
    }
}
