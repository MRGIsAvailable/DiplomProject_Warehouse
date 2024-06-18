using System.ComponentModel.DataAnnotations;

namespace ConstructionWarehouse_Web.Models.Dto
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
