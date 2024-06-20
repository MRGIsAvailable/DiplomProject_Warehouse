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
using System.Collections.Generic;
using System.Reflection;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Authorization;

namespace ConstructionWarehouse_Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IStatusService _statusService;
        private readonly IPremiseService _premiseService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper, IProductService productService, IUserService userService, IStatusService statusService, IPremiseService premiseService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _productService = productService;
            _userService = userService;
            _statusService = statusService;
            _premiseService = premiseService;
        }

        [Authorize]
        public async Task<IActionResult> IndexOrder(string? search)
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
                    || u.Status.StatusName.ToLower().Contains(search.ToLower()) || u.Phone.ToLower().Contains(search.ToLower()));
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

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> CreateOrder()
        {
            OrderCreateVM orderVM = new();
            var responseOne = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseTwo = await _userService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseThree = await _premiseService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseFour = await _statusService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (responseOne != null && responseOne.IsSuccess)
            {
                orderVM.ProductList = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(responseOne.Result)).Select(i => new SelectListItem
                    {
                        Text = i.ProductName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseTwo != null && responseTwo.IsSuccess)
            {
                orderVM.UserList = JsonConvert.DeserializeObject<List<UserDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.FullName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseThree != null && responseThree.IsSuccess)
            {
                orderVM.PremiseList = JsonConvert.DeserializeObject<List<PremiseDTO>>
                    (Convert.ToString(responseThree.Result)).Select(i => new SelectListItem
                    {
                        Text = i.PremiseName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseFour != null && responseFour.IsSuccess)
            {
                orderVM.StatusList = JsonConvert.DeserializeObject<List<StatusDTO>>
                    (Convert.ToString(responseFour.Result)).Select(i => new SelectListItem
                    {
                        Text = i.StatusName,
                        Value = i.Id.ToString(),
                    });
            }
            return View(orderVM);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(OrderCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderService.CreateAsync<APIResponse>(model.Order, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Заказ успешно добавлен";
                    return RedirectToAction(nameof(IndexOrder));
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
            var responseTwo = await _userService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseThree = await _premiseService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseFour = await _statusService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
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
                model.UserList = JsonConvert.DeserializeObject<List<UserDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.FullName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseThree != null && responseThree.IsSuccess)
            {
                model.PremiseList = JsonConvert.DeserializeObject<List<PremiseDTO>>
                    (Convert.ToString(responseThree.Result)).Select(i => new SelectListItem
                    {
                        Text = i.PremiseName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseFour != null && responseFour.IsSuccess)
            {
                model.StatusList = JsonConvert.DeserializeObject<List<StatusDTO>>
                    (Convert.ToString(responseFour.Result)).Select(i => new SelectListItem
                    {
                        Text = i.StatusName,
                        Value = i.Id.ToString(),
                    });
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> UpdateOrder(int orderId)
        {
            OrderUpdateVM orderVM = new();
            var response = await _orderService.GetAsync<APIResponse>(orderId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                OrderDTO model = JsonConvert.DeserializeObject<OrderDTO>(Convert.ToString(response.Result));
                orderVM.Order = _mapper.Map<OrderUpdateDTO>(model);
            }

            var responseOne = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseTwo = await _userService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseThree = await _premiseService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseFour = await _statusService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (responseOne != null && responseOne.IsSuccess)
            {
                orderVM.ProductList = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(responseOne.Result)).Select(i => new SelectListItem
                    {
                        Text = i.ProductName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseTwo != null && responseTwo.IsSuccess)
            {
                orderVM.UserList = JsonConvert.DeserializeObject<List<UserDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.FullName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseThree != null && responseThree.IsSuccess)
            {
                orderVM.PremiseList = JsonConvert.DeserializeObject<List<PremiseDTO>>
                    (Convert.ToString(responseThree.Result)).Select(i => new SelectListItem
                    {
                        Text = i.PremiseName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseFour != null && responseFour.IsSuccess)
            {
                orderVM.StatusList = JsonConvert.DeserializeObject<List<StatusDTO>>
                    (Convert.ToString(responseFour.Result)).Select(i => new SelectListItem
                    {
                        Text = i.StatusName,
                        Value = i.Id.ToString(),
                    });
                return View(orderVM);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOrder(OrderUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Заказ успешно обновлен";
                var response = await _orderService.UpdateAsync<APIResponse>(model.Order, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexOrder));
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
            var responseTwo = await _userService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseThree = await _premiseService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseFour = await _statusService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
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
                model.UserList = JsonConvert.DeserializeObject<List<UserDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.FullName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseThree != null && responseThree.IsSuccess)
            {
                model.PremiseList = JsonConvert.DeserializeObject<List<PremiseDTO>>
                    (Convert.ToString(responseThree.Result)).Select(i => new SelectListItem
                    {
                        Text = i.PremiseName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseFour != null && responseFour.IsSuccess)
            {
                model.StatusList = JsonConvert.DeserializeObject<List<StatusDTO>>
                    (Convert.ToString(responseFour.Result)).Select(i => new SelectListItem
                    {
                        Text = i.StatusName,
                        Value = i.Id.ToString(),
                    });
            }
            TempData["error"] = "Произошла ошибка";
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            OrderDeleteVM orderVM = new();
            var response = await _orderService.GetAsync<APIResponse>(orderId, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                OrderDTO model = JsonConvert.DeserializeObject<OrderDTO>(Convert.ToString(response.Result));
                orderVM.Order = _mapper.Map<OrderDTO>(model);
            }

            var responseOne = await _productService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseTwo = await _userService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseThree = await _premiseService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            var responseFour = await _statusService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (responseOne != null && responseOne.IsSuccess)
            {
                orderVM.ProductList = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(responseOne.Result)).Select(i => new SelectListItem
                    {
                        Text = i.ProductName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseTwo != null && responseTwo.IsSuccess)
            {
                orderVM.UserList = JsonConvert.DeserializeObject<List<UserDTO>>
                    (Convert.ToString(responseTwo.Result)).Select(i => new SelectListItem
                    {
                        Text = i.FullName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseThree != null && responseThree.IsSuccess)
            {
                orderVM.PremiseList = JsonConvert.DeserializeObject<List<PremiseDTO>>
                    (Convert.ToString(responseThree.Result)).Select(i => new SelectListItem
                    {
                        Text = i.PremiseName,
                        Value = i.Id.ToString(),
                    });
            }
            if (responseFour != null && responseFour.IsSuccess)
            {
                orderVM.StatusList = JsonConvert.DeserializeObject<List<StatusDTO>>
                    (Convert.ToString(responseFour.Result)).Select(i => new SelectListItem
                    {
                        Text = i.StatusName,
                        Value = i.Id.ToString(),
                    });
                return View(orderVM);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrder(OrderDeleteVM model)
        {
            var response = await _orderService.DeleteAsync<APIResponse>(model.Order.Id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Заказ успешно удален";
                return RedirectToAction(nameof(IndexOrder));
            }
            TempData["error"] = "Произошла ошибка";

            return View(model);
        }

        [HttpGet("generatepdf")]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> GeneratedPDF()
        {
            var document = new PdfDocument();

            List<OrderDTO> list = new();
            var resp = await _orderService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<OrderDTO>>(Convert.ToString(resp.Result));
            }

            string htmlContent = "<div style='width:100%; text-align:center'>";
            htmlContent += "<h2>Заказы</h2>";

            htmlContent += "<table style ='width:100%; border: 1px solid #000'>";
            htmlContent += "<thead style='font-weight:bold'>";
            htmlContent += "<tr>";
            htmlContent += "<td style='border:1px solid #000'> Товар </td>";
            htmlContent += "<td style='border:1px solid #000'> Количество </td>";
            htmlContent += "<td style='border:1px solid #000'>Менеджер</td>";
            htmlContent += "<td style='border:1px solid #000'>Помещение</td >";
            htmlContent += "<td style='border:1px solid #000'>Телефон</td>";
            htmlContent += "<td style='border:1px solid #000'>Статус заказа</td>";
            htmlContent += "<td style='border:1px solid #000'>Цена</td>";
            htmlContent += "</tr>";
            htmlContent += "</thead >";

            htmlContent += "<tbody>";
            if (resp != null)
            {
                list.ForEach(item =>
                {
                    htmlContent += "<tr style='border-bottom:1px solid #000'>";
                    htmlContent += "<td style='border-bottom:1px solid #000'>" + item.Product.ProductName + "</td>";
                    htmlContent += "<td style='border-bottom:1px solid #000'>" + item.Quantity + "</td >";
                    htmlContent += "<td style='border-bottom:1px solid #000'>" + item.User.FullName + "</td>";
                    htmlContent += "<td style='border-bottom:1px solid #000'> " + item.Premise.PremiseName + "</td >";
                    htmlContent += "<td style='border-bottom:1px solid #000'> " + item.Phone + "</td >";
                    htmlContent += "<td style='border-bottom:1px solid #000'> " + item.Status.StatusName + "</td >";
                    htmlContent += "<td style='border-bottom:1px solid #000'> " + ((item.Product.Price).ToString("c")) + "</td >";

                    htmlContent += "</tr>";
                });
            }
            htmlContent += "</tbody>";

            htmlContent += "</table>";
            htmlContent += "</div>";

            PdfGenerator.AddPdfPages(document, htmlContent, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            string fileName = "Orders_" + "f" + ".pdf";

                return File(response, "application/pdf", fileName);
        }
    }
}
