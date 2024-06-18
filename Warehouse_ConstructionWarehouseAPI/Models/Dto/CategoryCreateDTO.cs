using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class CategoryCreateDTO
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
