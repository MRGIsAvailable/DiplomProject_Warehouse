using ConstructionWarehouse_Utility;
using ConstructionWarehouse_Web.Models;
using ConstructionWarehouse_Web.Models.Dto;
using ConstructionWarehouse_Web.Services.IServices;

namespace ConstructionWarehouse_Web.Services
{
    public class PremiseService : BaseService, IPremiseService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string premiseUrl;

        public PremiseService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            premiseUrl = configuration.GetValue<string>("ServiceUrls:CWarehouse");

        }

        public Task<T> CreateAsync<T>(PremiseCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = dto,
                Url = premiseUrl + "/api/PremiseAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = premiseUrl + "/api/PremiseAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = premiseUrl + "/api/PremiseAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = premiseUrl + "/api/PremiseAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(PremiseUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = dto,
                Url = premiseUrl + "/api/PremiseAPI/" + dto.Id,
                Token = token
            });
        }
    }
}
