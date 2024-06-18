using ConstructionWarehouse_Web.Models.Dto;

namespace ConstructionWarehouse_Web.Services.IServices
{
    public interface ISupplierService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(SupplierCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(SupplierUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
