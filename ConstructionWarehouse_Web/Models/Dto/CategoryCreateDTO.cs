using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class CategoryCreateDTO
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
