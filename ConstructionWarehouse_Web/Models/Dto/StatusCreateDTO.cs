using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class StatusCreateDTO
    {
        [Required]
        public string StatusName { get; set; }
    }
}
