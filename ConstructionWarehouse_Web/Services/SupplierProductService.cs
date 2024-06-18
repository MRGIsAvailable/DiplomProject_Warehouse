using ConstructionWarehouse_Utility;
using ConstructionWarehouse_Web.Models;
using ConstructionWarehouse_Web.Models.Dto;
using ConstructionWarehouse_Web.Services.IServices;

namespace ConstructionWarehouse_Web.Services
{
    public class SupplierProductService : BaseService, ISupplierProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string supplierProductUrl;

        public SupplierProductService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            supplierProductUrl = configuration.GetValue<string>("ServiceUrls:CWarehouse");

        }

        public Task<T> CreateAsync<T>(SupplierProductCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = dto,
                Url = supplierProductUrl + "/api/SupplierProductAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = supplierProductUrl + "/api/SupplierProductAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = supplierProductUrl + "/api/SupplierProductAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = supplierProductUrl + "/api/SupplierProductAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(SupplierProductUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = dto,
                Url = supplierProductUrl + "/api/SupplierProductAPI/" + dto.Id,
                Token = token
            });
        }
    }
}
