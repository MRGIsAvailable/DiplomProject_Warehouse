using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Models;

namespace Warehouse_ConstructionWarehouseAPI.Repository.IRepository
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> UpdateAsync(Supplier entity);
    }
}
