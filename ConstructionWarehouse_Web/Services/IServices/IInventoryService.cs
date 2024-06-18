using ConstructionWarehouse_Web.Models.Dto;

namespace ConstructionWarehouse_Web.Services.IServices
{
    public interface IInventoryService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(InventoryCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(InventoryUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
