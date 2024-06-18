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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> IndexProduct(string? search)
        {
            IEnumerable<ProductDTO> list;

            var response = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    list = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
                    list = list.Where(u => u.ProductName.ToLower().Contains(search.ToLower()) || 
                    u.Details.ToLower().Contains(search.ToLower()) || u.Category.CategoryName.ToLower().Contains(search.ToLower()));
                }
                else
                {
                    list = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
                }
            }
            else
            {
                list = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> CreateProduct()
        {
            ProductCreateVM productVM = new();
            var response = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                productVM.CategoryList = JsonConvert.DeserializeObject<List<CategoryDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.CategoryName,
                        Value = i.Id.ToString(),
                    });
            }
            return View(productVM);
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateAsync<APIResponse>(model.Product, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Товар успешно добавлен";
                    return RedirectToAction(nameof(IndexProduct));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                model.CategoryList = JsonConvert.DeserializeObject<List<CategoryDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.CategoryName,
                        Value = i.Id.ToString(),
                    });
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> UpdateProduct(int productId)
        {
            ProductUpdateVM productVM = new();
            var response = await _productService.GetAsync<APIResponse>(productId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                ProductDTO model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                productVM.Product = _mapper.Map<ProductUpdateDTO>(model);
            }

            response = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                productVM.CategoryList = JsonConvert.DeserializeObject<List<CategoryDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.CategoryName,
                        Value = i.Id.ToString(),
                    });
                return View(productVM);
            }

            return NotFound();
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(ProductUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Товар успешно обновлен";
                var response = await _productService.UpdateAsync<APIResponse>(model.Product, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexProduct));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                model.CategoryList = JsonConvert.DeserializeObject<List<CategoryDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.CategoryName,
                        Value = i.Id.ToString(),
                    });
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            ProductDeleteVM productVM = new();
            var response = await _productService.GetAsync<APIResponse>(productId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                ProductDTO model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                productVM.Product = _mapper.Map<ProductDTO>(model);
            }

            response = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                productVM.CategoryList = JsonConvert.DeserializeObject<List<CategoryDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.CategoryName,
                        Value = i.Id.ToString(),
                    });
                return View(productVM);
            }

            return NotFound();
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(ProductDeleteVM model)
        {
            var response = await _productService.DeleteAsync<APIResponse>(model.Product.Id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Товар успешно удален";
                return RedirectToAction(nameof(IndexProduct));
            }
            TempData["error"] = "Произошла ошибка";

            return View(model);
        }
    }
}
