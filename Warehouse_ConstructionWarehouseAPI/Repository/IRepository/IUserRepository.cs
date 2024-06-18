using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Models;

namespace Warehouse_ConstructionWarehouseAPI.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> UpdateAsync(User entity);
    }
}
