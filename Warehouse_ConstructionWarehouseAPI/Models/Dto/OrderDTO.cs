using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class OrderDTO
    {
        public int Id { get; set; }
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
        public DateTime OrderDate { get; set; }
        [Required]
        public int DeliveryStatusId { get; set; }
        public ProductDTO Product { get; set; }
        public UserDTO User { get; set; }
        public StatusDTO Status { get; set; }
        public PremiseDTO Premise { get; set; }

    }
}
