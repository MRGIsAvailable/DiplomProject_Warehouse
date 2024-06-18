using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Models;

namespace Warehouse_ConstructionWarehouseAPI.Repository.IRepository
{
    public interface IStatusRepository : IRepository<Status>
    {
        Task<Status> UpdateAsync(Status entity);
    }
}
