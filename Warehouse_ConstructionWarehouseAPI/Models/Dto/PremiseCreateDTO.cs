using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class PremiseCreateDTO
    {
        [Required]
        public string PremiseName { get; set; }
    }
}
