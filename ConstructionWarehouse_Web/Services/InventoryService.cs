using ConstructionWarehouse_Utility;
using ConstructionWarehouse_Web.Models;
using ConstructionWarehouse_Web.Models.Dto;
using ConstructionWarehouse_Web.Services.IServices;

namespace ConstructionWarehouse_Web.Services
{
    public class InventoryService : BaseService, IInventoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string inventoryUrl;

        public InventoryService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            inventoryUrl = configuration.GetValue<string>("ServiceUrls:CWarehouse");

        }

        public Task<T> CreateAsync<T>(InventoryCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = dto,
                Url = inventoryUrl + "/api/InventoryAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = inventoryUrl + "/api/InventoryAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = inventoryUrl + "/api/InventoryAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = inventoryUrl + "/api/InventoryAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(InventoryUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = dto,
                Url = inventoryUrl + "/api/InventoryAPI/" + dto.Id,
                Token = token
            });
        }
    }
}
