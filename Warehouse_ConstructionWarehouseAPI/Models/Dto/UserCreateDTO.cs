using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class UserCreateDTO
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserRole { get; set; }
    }
}
