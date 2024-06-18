using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Models;

namespace Warehouse_ConstructionWarehouseAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includePropertiesOne = null, string? includePropertiesTwo = null, string?
            includePropertiesThree = null, string? includePropertiesFour = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includePropertiesOne = null, string? includePropertiesTwo = null,
            string? includePropertiesThree = null, string? includePropertiesFour = null);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
