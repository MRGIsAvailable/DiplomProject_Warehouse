using ConstructionWarehouse_Utility;
using ConstructionWarehouse_Web.Models;
using ConstructionWarehouse_Web.Models.Dto;
using ConstructionWarehouse_Web.Services.IServices;

namespace ConstructionWarehouse_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string supplierProductUrl;

        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            supplierProductUrl = configuration.GetValue<string>("ServiceUrls:CWarehouse");

        }

        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = obj,
                Url = supplierProductUrl + "/api/LocalUserAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegisterationRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = obj,
                Url = supplierProductUrl + "/api/LocalUserAuth/register"
            });
        }
    }
}
