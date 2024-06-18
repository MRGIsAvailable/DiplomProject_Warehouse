using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class StatusDTO
    {
        public int Id { get; set; }
        [Required]
        public string StatusName { get; set; }
    }
}
