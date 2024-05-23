using Warehouse_ConstructionWarehouseAPI.Models.Dto;

namespace Warehouse_ConstructionWarehouseAPI.Data
{
    public static class WarehouseStore
    {
        public static List<WarehouseDTO> WarehouseList = new List<WarehouseDTO>
            {
                new WarehouseDTO { Id = 1, Name = "Sklad", Sqft = 100, Occupancy = 4},
                new WarehouseDTO { Id = 2, Name = "Sklad2", Sqft = 100, Occupancy = 3}
            };
    }
}
