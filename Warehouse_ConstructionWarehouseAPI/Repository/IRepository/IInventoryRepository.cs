using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Models;

namespace Warehouse_ConstructionWarehouseAPI.Repository.IRepository
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<Inventory> UpdateAsync(Inventory entity);
    }
}
