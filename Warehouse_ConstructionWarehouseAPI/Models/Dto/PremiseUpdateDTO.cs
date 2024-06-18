﻿using System.ComponentModel.DataAnnotations;

namespace Warehouse_ConstructionWarehouseAPI.Models.Dto
{
    public class PremiseUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PremiseName { get; set; }
    }
}
