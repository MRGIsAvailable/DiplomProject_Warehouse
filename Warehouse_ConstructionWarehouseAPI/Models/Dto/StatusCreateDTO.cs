using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class StatusCreateDTO
    {
        [Required]
        public string StatusName { get; set; }
    }
}
