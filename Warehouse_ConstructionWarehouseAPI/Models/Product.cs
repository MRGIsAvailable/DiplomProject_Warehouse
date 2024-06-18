using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_ConstructionWarehouseAPI.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Details { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
    }
}
