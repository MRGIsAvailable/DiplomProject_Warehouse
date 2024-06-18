using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("User")]
        public int CustomerId { get; set; }
        public User User { get; set; }
        [ForeignKey("Premise")]
        public int PremiseId { get; set; }
        public Premise Premise { get; set; }
        public string Phone { get; set; }
        public DateTime OrderDate { get; set; }
        [ForeignKey("Status")]
        public int DeliveryStatusId { get; set; }
        public Status Status { get; set; }
    }
}
