using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class PremiseUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PremiseName { get; set; }
    }
}
