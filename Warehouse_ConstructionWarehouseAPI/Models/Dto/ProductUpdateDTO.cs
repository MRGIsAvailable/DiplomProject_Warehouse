using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class ProductUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Details { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
