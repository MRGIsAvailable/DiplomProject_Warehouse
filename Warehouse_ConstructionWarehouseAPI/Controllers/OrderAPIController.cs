using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using Warehouse_ConstructionWarehouseAPI.Data;
using Warehouse_ConstructionWarehouseAPI.Models;
using Warehouse_ConstructionWarehouseAPI.Models.Dto;
using Warehouse_ConstructionWarehouseAPI.Repository.IRepository;

namespace Warehouse_ConstructionWarehouseAPI.Controllers
{
    [Route("api/OrderAPI")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IOrderRepository _dbOrder;
        private readonly IProductRepository _dbProduct;
        private readonly IUserRepository _dbUser;
        private readonly IPremiseRepository _dbPremise;
        private readonly IStatusRepository _dbStatus;
        private readonly IMapper _mapper;
        public OrderAPIController(IOrderRepository dbOrder, IMapper mapper, IProductRepository dbProduct, IUserRepository dbUser, IStatusRepository dbStatus, IPremiseRepository dbPremise)
        {
            _dbOrder = dbOrder;
            _mapper = mapper;
            this._response = new();
            _dbProduct = dbProduct;
            _dbUser = dbUser;
            _dbStatus = dbStatus;
            _dbPremise = dbPremise;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> GetOrders([FromQuery(Name = "filter")] string? search)
        {
            try
            {
                IEnumerable<Order> orderList;
                
                if (!string.IsNullOrEmpty(search))
                {
                    orderList = await _dbOrder.GetAllAsync(includePropertiesOne: "Product", includePropertiesTwo: "User", includePropertiesThree: "Status", includePropertiesFour: "Premise");
                    orderList = orderList.Where(u => u.Phone.ToLower().Contains(search));
                }
                else
                {
                    orderList = await _dbOrder.GetAllAsync(includePropertiesOne: "Product", includePropertiesTwo: "User", includePropertiesThree: "Status", includePropertiesFour: "Premise");
                }

                _response.Result = _mapper.Map<List<OrderDTO>>(orderList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name ="GetOrder")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetOrder(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var order = await _dbOrder.GetAsync(u => u.Id == id);
                if (order == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<OrderDTO>(order);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [Authorize (Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateOrder([FromBody]OrderCreateDTO createDTO)
        {
            try
            {
                if (await _dbProduct.GetAsync(u => u.Id == createDTO.ProductId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Product ID is Invalid");
                    return BadRequest(ModelState);
                }
                if (await _dbUser.GetAsync(u => u.Id == createDTO.CustomerId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "User ID is Invalid");
                    return BadRequest(ModelState);
                }
                if (await _dbPremise.GetAsync(u => u.Id == createDTO.PremiseId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Premise ID is Invalid");
                    return BadRequest(ModelState);
                }
                if (await _dbStatus.GetAsync(u => u.Id == createDTO.DeliveryStatusId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Delivery status ID is Invalid");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Order order = _mapper.Map<Order>(createDTO);
                order.OrderDate = DateTime.Now;

                await _dbOrder.CreateAsync(order);

                _response.Result = _mapper.Map<OrderDTO>(order);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetOrder", new { id = order.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteOrder")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteOrder(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var order = await _dbOrder.GetAsync(u => u.Id == id);
                if (order == null)
                {
                    return NotFound();
                }
                await _dbOrder.RemoveAsync(order);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateOrder")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdateOrder(int id, [FromBody]OrderUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                if (await _dbProduct.GetAsync(u => u.Id == updateDTO.ProductId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Product ID is Invalid");
                    return BadRequest(ModelState);
                }
                if (await _dbUser.GetAsync(u => u.Id == updateDTO.CustomerId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "User ID is Invalid");
                    return BadRequest(ModelState);
                }
                if (await _dbPremise.GetAsync(u => u.Id == updateDTO.PremiseId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Premise ID is Invalid");
                    return BadRequest(ModelState);
                }
                if (await _dbStatus.GetAsync(u => u.Id == updateDTO.DeliveryStatusId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Delivery status ID is Invalid");
                    return BadRequest(ModelState);
                }

                Order model = _mapper.Map<Order>(updateDTO);
                model.OrderDate = DateTime.Now;

                await _dbOrder.UpdateAsync(model);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialOrder")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> UpdatePartialOrder(int id, JsonPatchDocument<OrderUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var order = await _dbOrder.GetAsync(u => u.Id == id, tracked: false);

            OrderUpdateDTO orderDTO = _mapper.Map<OrderUpdateDTO>(order);

            if (order == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(orderDTO, ModelState);

            Order model = _mapper.Map<Order>(orderDTO);
            model.OrderDate = DateTime.Now;

            await _dbOrder.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
