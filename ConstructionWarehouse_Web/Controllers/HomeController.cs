using AutoMapper;
using ConstructionWarehouse_Utility;
using ConstructionWarehouse_Web.Models;
using ConstructionWarehouse_Web.Models.Dto;
using ConstructionWarehouse_Web.Models.VM;
using ConstructionWarehouse_Web.Services;
using ConstructionWarehouse_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace ConstructionWarehouse_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IStatusService _statusService;
        private readonly IPremiseService _premiseService;
        private readonly IMapper _mapper;
        public HomeController(IOrderService orderService, IMapper mapper, IProductService productService, IUserService userService, IStatusService statusService, IPremiseService premiseService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _productService = productService;
            _userService = userService;
            _statusService = statusService;
            _premiseService = premiseService;
        }

        [Authorize]
        public async Task<IActionResult> Index(string? search)
        {
            IEnumerable<OrderDTO> list;

            var response = await _orderService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    list = JsonConvert.DeserializeObject<List<OrderDTO>>(Convert.ToString(response.Result));
                    list = list.Where(u => u.Product.ProductName.ToLower().Contains(search.ToLower()) ||
                    u.User.FullName.ToLower().Contains(search.ToLower()) || u.Premise.PremiseName.ToLower().Contains(search.ToLower())
                    || u.Status.StatusName.ToLower().Contains(search.ToLower()));
                }
                else
                {
                    list = JsonConvert.DeserializeObject<List<OrderDTO>>(Convert.ToString(response.Result));
                }
            }
            else
            {
                list = JsonConvert.DeserializeObject<List<OrderDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
    }
}
