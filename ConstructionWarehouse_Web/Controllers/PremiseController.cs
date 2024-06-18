using AutoMapper;
using ConstructionWarehouse_Utility;
using ConstructionWarehouse_Web.Models;
using ConstructionWarehouse_Web.Models.Dto;
using ConstructionWarehouse_Web.Models.VM;
using ConstructionWarehouse_Web.Services;
using ConstructionWarehouse_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ConstructionWarehouse_Web.Controllers
{
    public class PremiseController : Controller
    {
        private readonly IPremiseService _premiseService;
        private readonly IMapper _mapper;
        public PremiseController(IPremiseService premiseService, IMapper mapper)
        {
            _premiseService = premiseService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexPremise()
        {
            List<PremiseDTO> list = new();

            var response = await _premiseService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<PremiseDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> CreatePremise()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePremise(PremiseCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _premiseService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Помещение успешно добавлено";
                    return RedirectToAction(nameof(IndexPremise));
                }
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        public async Task<IActionResult> UpdatePremise(int premiseId)
        {
            var response = await _premiseService.GetAsync<APIResponse>(premiseId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                PremiseDTO model = JsonConvert.DeserializeObject<PremiseDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<PremiseUpdateDTO>(model));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePremise(PremiseUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Помещение успешно обновлено";
                var response = await _premiseService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexPremise));
                }
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        public async Task<IActionResult> DeletePremise(int premiseId)
        {
            var response = await _premiseService.GetAsync<APIResponse>(premiseId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                PremiseDTO model = JsonConvert.DeserializeObject<PremiseDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePremise(PremiseDTO model)
        {
            var response = await _premiseService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Помещение успешно удалено";
                return RedirectToAction(nameof(IndexPremise));
            }
            TempData["error"] = "Произошла ошибка";

            return View(model);
        }
    }
}
