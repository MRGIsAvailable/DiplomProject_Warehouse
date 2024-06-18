using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class UserUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserRole { get; set; }
    }
}
