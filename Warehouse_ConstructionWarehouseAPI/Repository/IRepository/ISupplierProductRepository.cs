using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Models;

namespace Warehouse_ConstructionWarehouseAPI.Repository.IRepository
{
    public interface ISupplierProductRepository : IRepository<SupplierProduct>
    {
        Task<SupplierProduct> UpdateAsync(SupplierProduct entity);
    }
}
