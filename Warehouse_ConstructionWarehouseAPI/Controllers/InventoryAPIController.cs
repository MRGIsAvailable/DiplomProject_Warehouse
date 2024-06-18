using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Warehouse_ConstructionWarehouseAPI.Data;
using Warehouse_ConstructionWarehouseAPI.Models;
using Warehouse_ConstructionWarehouseAPI.Models.Dto;
using Warehouse_ConstructionWarehouseAPI.Repository.IRepository;

namespace Warehouse_ConstructionWarehouseAPI.Controllers
{
    [Route("api/InventoryAPI")]
    [ApiController]
    public class InventoryAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IInventoryRepository _dbInventory;
        private readonly IProductRepository _dbProduct;
        private readonly IPremiseRepository _dbPremise;
        private readonly IMapper _mapper;
        public InventoryAPIController(IInventoryRepository dbInventory, IMapper mapper, IProductRepository dbProduct, IPremiseRepository dbPremise)
        {
            _dbInventory = dbInventory;
            _mapper = mapper;
            this._response = new();
            _dbProduct = dbProduct;
            _dbPremise = dbPremise;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> GetAllInventory()
        {
            try
            {
                IEnumerable<Inventory> inventoryList = await _dbInventory.GetAllAsync(includePropertiesOne: "Product", includePropertiesTwo: "Premise");
                _response.Result = _mapper.Map<List<InventoryDTO>>(inventoryList);
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

        [HttpGet("{id:int}", Name = "GetInventory")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetInventory(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var inventory = await _dbInventory.GetAsync(u => u.Id == id);
                if (inventory == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<InventoryDTO>(inventory);
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
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateInventory([FromBody] InventoryCreateDTO createDTO)
        {
            try
            {
                if (await _dbPremise.GetAsync(u => u.Id == createDTO.PremiseId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Premise ID is Invalid");
                    return BadRequest(ModelState);
                }
                if (await _dbProduct.GetAsync(u => u.Id == createDTO.ProductId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Product ID is Invalid");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Inventory inventory = _mapper.Map<Inventory>(createDTO);

                await _dbInventory.CreateAsync(inventory);

                _response.Result = _mapper.Map<InventoryDTO>(inventory);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetInventory", new { id = inventory.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteInventory")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteInventory(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var inventory = await _dbInventory.GetAsync(u => u.Id == id);
                if (inventory == null)
                {
                    return NotFound();
                }
                await _dbInventory.RemoveAsync(inventory);
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

        [HttpPut("{id:int}", Name = "UpdateInventory")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdateInventory(int id, [FromBody] InventoryUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                if (await _dbPremise.GetAsync(u => u.Id == updateDTO.PremiseId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Premise ID is Invalid");
                    return BadRequest(ModelState);
                }
                if (await _dbProduct.GetAsync(u => u.Id == updateDTO.ProductId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Product ID is Invalid");
                    return BadRequest(ModelState);
                }

                Inventory model = _mapper.Map<Inventory>(updateDTO);

                await _dbInventory.UpdateAsync(model);

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

        [HttpPatch("{id:int}", Name = "UpdatePartialInventory")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> UpdatePartialInventory(int id, JsonPatchDocument<InventoryUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var inventory = await _dbInventory.GetAsync(u => u.Id == id, tracked: false);

            InventoryUpdateDTO inventoryDTO = _mapper.Map<InventoryUpdateDTO>(inventory);

            if (inventory == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(inventoryDTO, ModelState);

            Inventory model = _mapper.Map<Inventory>(inventoryDTO);

            await _dbInventory.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
