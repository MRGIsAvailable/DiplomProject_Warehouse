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
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IPremiseService _premiseService;
        private readonly IMapper _mapper;
        public InventoryController(IInventoryService inventoryService, IMapper mapper, IProductService productService, IPremiseService premiseService)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
            _productService = productService;
            _premiseService = premiseService;
        }

        [Authorize]
        public async Task<IActionResult> IndexInventory(string? search)
        {
            IEnumerable<InventoryDTO> list;

            var response = await _inventoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    list = JsonConvert.DeserializeObject<List<InventoryDTO>>(Convert.ToString(response.Result));
                    list = list.Where(u => u.Product.ProductName.ToLower().Contains(search.ToLower()) ||
                    u.Premise.PremiseName.ToLower().Contains(search.ToLower()));
                }
                else
                {
                    list = JsonConvert.DeserializeObject<List<InventoryDTO>>(Convert.ToString(response.Result));
                }
            }
            else
            {
                list = JsonConvert.DeserializeObject<List<InventoryDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> CreateInventory()
        {
            InventoryCreateVM inventoryVM = new();
            var responseOne = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseTwo = await _premiseService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (responseOne != null && responseOne.IsSuccess)
            {
                inventoryVM.ProductList = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(responseOne.Result)).Select(i => new SelectListItem
                    {
                        Text = i.ProductName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseTwo != null && responseTwo.IsSuccess)
            {
                inventoryVM.PremiseList = JsonConvert.DeserializeObject<List<PremiseDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.PremiseName,
                        Value = i.Id.ToString(),
                    });
            }
            return View(inventoryVM);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInventory(InventoryCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _inventoryService.CreateAsync<APIResponse>(model.Inventory, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Товар добавлен на склад";
                    return RedirectToAction(nameof(IndexInventory));
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
            var responseTwo = await _premiseService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
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
                model.PremiseList = JsonConvert.DeserializeObject<List<PremiseDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.PremiseName,
                        Value = i.Id.ToString(),
                    });
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> UpdateInventory(int inventoryId)
        {
            InventoryUpdateVM inventoryVM = new();
            var response = await _inventoryService.GetAsync<APIResponse>(inventoryId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                InventoryDTO model = JsonConvert.DeserializeObject<InventoryDTO>(Convert.ToString(response.Result));
                inventoryVM.Inventory = _mapper.Map<InventoryUpdateDTO>(model);
            }

            var responseOne = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseTwo = await _premiseService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (responseOne != null && responseOne.IsSuccess)
            {
                inventoryVM.ProductList = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(responseOne.Result)).Select(i => new SelectListItem
                    {
                        Text = i.ProductName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseTwo != null && responseTwo.IsSuccess)
            {
                inventoryVM.PremiseList = JsonConvert.DeserializeObject<List<PremiseDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.PremiseName,
                        Value = i.Id.ToString(),
                    });
                return View(inventoryVM);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInventory(InventoryUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Данные о товаре на складе были успешно обновлены";
                var response = await _inventoryService.UpdateAsync<APIResponse>(model.Inventory, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexInventory));
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
            var responseTwo = await _premiseService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
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
                model.PremiseList = JsonConvert.DeserializeObject<List<PremiseDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.PremiseName,
                        Value = i.Id.ToString(),
                    });
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> DeleteInventory(int inventoryId)
        {
            InventoryDeleteVM inventoryVM = new();
            var response = await _inventoryService.GetAsync<APIResponse>(inventoryId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                InventoryDTO model = JsonConvert.DeserializeObject<InventoryDTO>(Convert.ToString(response.Result));
                inventoryVM.Inventory = _mapper.Map<InventoryDTO>(model);
            }

            var responseOne = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseTwo = await _premiseService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (responseOne != null && responseOne.IsSuccess)
            {
                inventoryVM.ProductList = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(responseOne.Result)).Select(i => new SelectListItem
                    {
                        Text = i.ProductName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseTwo != null && responseTwo.IsSuccess)
            {
                inventoryVM.PremiseList = JsonConvert.DeserializeObject<List<PremiseDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.PremiseName,
                        Value = i.Id.ToString(),
                    });
                return View(inventoryVM);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInventory(InventoryDeleteVM model)
        {
            var response = await _inventoryService.DeleteAsync<APIResponse>(model.Inventory.Id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Товар удален со склада";
                return RedirectToAction(nameof(IndexInventory));
            }
            TempData["error"] = "Произошла ошибка";

            return View(model);
        }
    }
}
