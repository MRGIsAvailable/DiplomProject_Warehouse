using AutoMapper;
using ConstructionWarehouse_Utility;
using ConstructionWarehouse_Web.Models;
using ConstructionWarehouse_Web.Models.Dto;
using ConstructionWarehouse_Web.Services;
using ConstructionWarehouse_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConstructionWarehouse_Web.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;
        private readonly IMapper _mapper;
        public StatusController(IStatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> IndexStatus()
        {
            List<StatusDTO> list = new();

            var response = await _statusService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<StatusDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> CreateStatus()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStatus(StatusCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _statusService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Статус успешно добавлен";
                    return RedirectToAction(nameof(IndexStatus));
                }
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> UpdateStatus(int statusId)
        {
            var response = await _statusService.GetAsync<APIResponse>(statusId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                StatusDTO model = JsonConvert.DeserializeObject<StatusDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<StatusUpdateDTO>(model));
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(StatusUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Статус успешно обновлен";
                var response = await _statusService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexStatus));
                }
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> DeleteStatus(int statusId)
        {
            var response = await _statusService.GetAsync<APIResponse>(statusId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                StatusDTO model = JsonConvert.DeserializeObject<StatusDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStatus(StatusDTO model)
        {
            var response = await _statusService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Статус успешно удален";
                return RedirectToAction(nameof(IndexStatus));
            }
            TempData["error"] = "Произошла ошибка";

            return View(model);
        }
    }
}
