using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Models;

namespace Warehouse_ConstructionWarehouseAPI.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> UpdateAsync(Category entity);
    }
}
