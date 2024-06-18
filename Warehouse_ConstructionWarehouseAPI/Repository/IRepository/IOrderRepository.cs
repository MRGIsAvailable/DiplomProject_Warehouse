using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Models;

namespace Warehouse_ConstructionWarehouseAPI.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> UpdateAsync(Order entity);
    }
}
