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

namespace ConstructionWarehouse_Web.Controllers
{
    public class SupplierProductController : Controller
    {
        private readonly ISupplierProductService _supplierProductService;
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public SupplierProductController(ISupplierProductService supplierProductService, IMapper mapper, IProductService productService, ISupplierService supplierService)
        {
            _supplierProductService = supplierProductService;
            _mapper = mapper;
            _productService = productService;
            _supplierService = supplierService;
        }

        [Authorize]
        public async Task<IActionResult> IndexSupplierProduct()
        {
            List<SupplierProductDTO> list = new();

            var response = await _supplierProductService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<SupplierProductDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> CreateSupplierProduct()
        {
            SupplierProductCreateVM supplierProductVM = new();
            var responseOne = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseTwo = await _supplierService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (responseOne != null && responseOne.IsSuccess)
            {
                supplierProductVM.ProductList = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(responseOne.Result)).Select(i => new SelectListItem
                    {
                        Text = i.ProductName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseTwo != null && responseTwo.IsSuccess)
            {
                supplierProductVM.SupplierList = JsonConvert.DeserializeObject<List<SupplierDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.SupplierName,
                        Value = i.Id.ToString(),
                    });
            }
            return View(supplierProductVM);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSupplierProduct(SupplierProductCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _supplierProductService.CreateAsync<APIResponse>(model.SupplierProduct, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Данные были успешно добавлены";
                    return RedirectToAction(nameof(IndexSupplierProduct));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var responseOne = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseTwo = await _supplierService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (responseOne != null && responseOne.IsSuccess)
            {
                model.ProductList = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(responseOne.Result)).Select(i => new SelectListItem
                    {
                        Text = i.ProductName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseTwo != null && responseTwo.IsSuccess)
            {
                model.SupplierList = JsonConvert.DeserializeObject<List<SupplierDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.SupplierName,
                        Value = i.Id.ToString(),
                    });
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> UpdateSupplierProduct(int supplierProductId)
        {
            SupplierProductUpdateVM supplierProductVM = new();
            var response = await _supplierProductService.GetAsync<APIResponse>(supplierProductId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                SupplierProductDTO model = JsonConvert.DeserializeObject<SupplierProductDTO>(Convert.ToString(response.Result));
                supplierProductVM.SupplierProduct = _mapper.Map<SupplierProductUpdateDTO>(model);
            }

            var responseOne = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseTwo = await _supplierService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (responseOne != null && responseOne.IsSuccess)
            {
                supplierProductVM.ProductList = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(responseOne.Result)).Select(i => new SelectListItem
                    {
                        Text = i.ProductName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseTwo != null && responseTwo.IsSuccess)
            {
                supplierProductVM.SupplierList = JsonConvert.DeserializeObject<List<SupplierDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.SupplierName,
                        Value = i.Id.ToString(),
                    });
                return View(supplierProductVM);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSupplierProduct(SupplierProductUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Данные были успешно обновлены";
                var response = await _supplierProductService.UpdateAsync<APIResponse>(model.SupplierProduct, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexSupplierProduct));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var responseOne = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseTwo = await _supplierService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (responseOne != null && responseOne.IsSuccess)
            {
                model.ProductList = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(responseOne.Result)).Select(i => new SelectListItem
                    {
                        Text = i.ProductName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseTwo != null && responseTwo.IsSuccess)
            {
                model.SupplierList = JsonConvert.DeserializeObject<List<SupplierDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.SupplierName,
                        Value = i.Id.ToString(),
                    });
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> DeleteSupplierProduct(int supplierProductId)
        {
            SupplierProductDeleteVM supplierProductVM = new();
            var response = await _supplierProductService.GetAsync<APIResponse>(supplierProductId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                SupplierProductDTO model = JsonConvert.DeserializeObject<SupplierProductDTO>(Convert.ToString(response.Result));
                supplierProductVM.SupplierProduct = _mapper.Map<SupplierProductDTO>(model);
            }

            var responseOne = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseTwo = await _supplierService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (responseOne != null && responseOne.IsSuccess)
            {
                supplierProductVM.ProductList = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(responseOne.Result)).Select(i => new SelectListItem
                    {
                        Text = i.ProductName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseTwo != null && responseTwo.IsSuccess)
            {
                supplierProductVM.SupplierList = JsonConvert.DeserializeObject<List<SupplierDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.SupplierName,
                        Value = i.Id.ToString(),
                    });
                return View(supplierProductVM);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSupplierProduct(SupplierProductDeleteVM model)
        {
            var response = await _supplierProductService.DeleteAsync<APIResponse>(model.SupplierProduct.Id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Данные были успешно удалены";
                return RedirectToAction(nameof(IndexSupplierProduct));
            }
            TempData["error"] = "Произошла ошибка";

            return View(model);
        }
    }
}
