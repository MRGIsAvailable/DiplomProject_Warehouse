using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
