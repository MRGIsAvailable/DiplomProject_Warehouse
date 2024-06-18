using AutoMapper;
using AutoMapper.Internal.Mappers;
using ConstructionWarehouse_Utility;
using ConstructionWarehouse_Web.Models;
using ConstructionWarehouse_Web.Models.Dto;
using ConstructionWarehouse_Web.Services;
using ConstructionWarehouse_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConstructionWarehouse_Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexSupplier(string? search)
        {
            IEnumerable<SupplierDTO> list;

            var response = await _supplierService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    list = JsonConvert.DeserializeObject<List<SupplierDTO>>(Convert.ToString(response.Result));
                    list = list.Where(u => u.SupplierName.ToLower().Contains(search.ToLower()) ||
                    u.ContactName.ToLower().Contains(search.ToLower()) || u.Email.ToLower().Contains(search.ToLower())
                    || u.Phone.ToLower().Contains(search.ToLower()));
                }
                else
                {
                    list = JsonConvert.DeserializeObject<List<SupplierDTO>>(Convert.ToString(response.Result));
                }
            }
            else
            {
                list = JsonConvert.DeserializeObject<List<SupplierDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> CreateSupplier()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSupplier(SupplierCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _supplierService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Производитель успешно добавлен";
                    return RedirectToAction(nameof(IndexSupplier));
                }
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        public async Task<IActionResult> UpdateSupplier(int supplierId)
        {
            var response = await _supplierService.GetAsync<APIResponse>(supplierId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                SupplierDTO model = JsonConvert.DeserializeObject<SupplierDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<SupplierUpdateDTO>(model));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSupplier(SupplierUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Производитель успешно обновлен";
                var response = await _supplierService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexSupplier));
                }
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        public async Task<IActionResult> DeleteSupplier(int supplierId)
        {
            var response = await _supplierService.GetAsync<APIResponse>(supplierId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                SupplierDTO model = JsonConvert.DeserializeObject<SupplierDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSupplier(SupplierDTO model)
        {
            var response = await _supplierService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Производитель успешно удален";
                return RedirectToAction(nameof(IndexSupplier));
            }
            TempData["error"] = "Произошла ошибка";

            return View(model);
        }
    }
}