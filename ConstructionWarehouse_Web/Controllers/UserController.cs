using AutoMapper;
using ConstructionWarehouse_Utility;
using ConstructionWarehouse_Web.Models;
using ConstructionWarehouse_Web.Models.Dto;
using ConstructionWarehouse_Web.Services;
using ConstructionWarehouse_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConstructionWarehouse_Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexUser(string? search)
        {
            IEnumerable<UserDTO> list;

            var response = await _userService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    list = JsonConvert.DeserializeObject<List<UserDTO>>(Convert.ToString(response.Result));
                    list = list.Where(u => u.FullName.ToLower().Contains(search.ToLower()) ||
                    u.UserRole.ToLower().Contains(search.ToLower()));
                }
                else
                {
                    list = JsonConvert.DeserializeObject<List<UserDTO>>(Convert.ToString(response.Result));
                }
            }
            else
            {
                list = JsonConvert.DeserializeObject<List<UserDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Менеджер успешно добавлен";
                    return RedirectToAction(nameof(IndexUser));
                }
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        public async Task<IActionResult> UpdateUser(int userId)
        {
            var response = await _userService.GetAsync<APIResponse>(userId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                UserDTO model = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<UserUpdateDTO>(model));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Менеджер успешно обновлен";
                var response = await _userService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexUser));
                }
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        public async Task<IActionResult> DeleteUser(int userId)
        {
            var response = await _userService.GetAsync<APIResponse>(userId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                UserDTO model = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(UserDTO model)
        {
            var response = await _userService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Менеджер успешно удален";
                return RedirectToAction(nameof(IndexUser));
            }
            TempData["error"] = "Произошла ошибка";

            return View(model);
        }
    }
}
