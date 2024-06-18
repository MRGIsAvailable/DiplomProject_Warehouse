using ConstructionWarehouse_Utility;
using ConstructionWarehouse_Web.Models;
using ConstructionWarehouse_Web.Models.Dto;
using ConstructionWarehouse_Web.Services.IServices;

namespace ConstructionWarehouse_Web.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string categoryUrl;

        public CategoryService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            categoryUrl = configuration.GetValue<string>("ServiceUrls:CWarehouse");

        }

        public Task<T> CreateAsync<T>(CategoryCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = dto,
                Url = categoryUrl + "/api/CategoryAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = categoryUrl + "/api/CategoryAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = categoryUrl + "/api/CategoryAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = categoryUrl + "/api/CategoryAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(CategoryUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = dto,
                Url = categoryUrl + "/api/CategoryAPI/" + dto.Id,
                Token = token
            });
        }
    }
}
