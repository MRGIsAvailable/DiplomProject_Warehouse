using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserRole { get; set; }
    }
}
