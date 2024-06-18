using AutoMapper;
using ConstructionWarehouse_Web.Models.Dto;
using ConstructionWarehouse_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ConstructionWarehouse_Web.Models.VM
{
    public class InventoryCreateVM
    {
        public InventoryCreateVM()
        {
            Inventory = new InventoryCreateDTO();
        }
        public InventoryCreateDTO Inventory { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ProductList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> PremiseList { get; set; }
    }
}
