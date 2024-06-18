using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class StatusDTO
    {
        public int Id { get; set; }
        [Required]
        public string StatusName { get; set; }
    }
}
