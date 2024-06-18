using ConstructionWarehouse_Web.Models.Dto;

namespace ConstructionWarehouse_Web.Services.IServices
{
    public interface IUserService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(UserCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(UserUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
