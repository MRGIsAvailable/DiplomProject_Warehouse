using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class OrderCreateDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int PremiseId { get; set; }
        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }
        [Required]
        public int DeliveryStatusId { get; set; }
    }
}
