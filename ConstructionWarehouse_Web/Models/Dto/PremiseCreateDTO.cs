using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class PremiseCreateDTO
    {
        [Required]
        public string PremiseName { get; set; }
    }
}
