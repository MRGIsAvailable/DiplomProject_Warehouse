using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class StatusUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string StatusName { get; set; }
    }
}
