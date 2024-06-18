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
    [Route("api/SupplierProductAPI")]
    [ApiController]
    public class SupplierProductAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ISupplierProductRepository _dbSupplierProduct;
        private readonly IProductRepository _dbProduct;
        private readonly ISupplierRepository _dbSupplier;
        private readonly IMapper _mapper;
        public SupplierProductAPIController(ISupplierProductRepository dbSupplierProduct, IMapper mapper, IProductRepository dbProduct, ISupplierRepository dbSupplier)
        {
            _dbSupplierProduct = dbSupplierProduct;
            _mapper = mapper;
            this._response = new();
            _dbProduct = dbProduct;
            _dbSupplier = dbSupplier;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> GetSupplierProducts()
        {
            try
            {
                IEnumerable<SupplierProduct> supplierProductList = await _dbSupplierProduct.GetAllAsync(includePropertiesOne: "Product", includePropertiesTwo: "Supplier");
                _response.Result = _mapper.Map<List<SupplierProductDTO>>(supplierProductList);
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

        [HttpGet("{id:int}", Name = "GetSupplierProduct")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetSupplierProduct(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var supplierProduct = await _dbSupplierProduct.GetAsync(u => u.Id == id);
                if (supplierProduct == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<SupplierProductDTO>(supplierProduct);
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
        public async Task<ActionResult<APIResponse>> CreateSupplierProduct([FromBody] SupplierProductCreateDTO createDTO)
        {
            try
            {
                if (await _dbProduct.GetAsync(u => u.Id == createDTO.ProductId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Product ID is Invalid");
                    return BadRequest(ModelState);
                }
                if (await _dbSupplier.GetAsync(u => u.Id == createDTO.SupplierId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Supplier ID is Invalid");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                SupplierProduct supplierProduct = _mapper.Map<SupplierProduct>(createDTO);

                await _dbSupplierProduct.CreateAsync(supplierProduct);

                _response.Result = _mapper.Map<SupplierProductDTO>(supplierProduct);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetSupplierProduct", new { id = supplierProduct.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteSupplierProduct")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteSupplierProduct(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var supplierProduct = await _dbSupplierProduct.GetAsync(u => u.Id == id);
                if (supplierProduct == null)
                {
                    return NotFound();
                }
                await _dbSupplierProduct.RemoveAsync(supplierProduct);
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

        [HttpPut("{id:int}", Name = "UpdateSupplierProduct")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdateSupplierProduct(int id, [FromBody] SupplierProductUpdateDTO updateDTO)
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
                if (await _dbSupplier.GetAsync(u => u.Id == updateDTO.SupplierId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Supplier ID is Invalid");
                    return BadRequest(ModelState);
                }

                SupplierProduct model = _mapper.Map<SupplierProduct>(updateDTO);

                await _dbSupplierProduct.UpdateAsync(model);

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

        [HttpPatch("{id:int}", Name = "UpdatePartialSupplierProduct")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> UpdatePartialSupplierProduct(int id, JsonPatchDocument<SupplierProductUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var supplierProduct = await _dbSupplierProduct.GetAsync(u => u.Id == id, tracked: false);

            SupplierProductUpdateDTO supplierProductDTO = _mapper.Map<SupplierProductUpdateDTO>(supplierProduct);

            if (supplierProduct == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(supplierProductDTO, ModelState);

            SupplierProduct model = _mapper.Map<SupplierProduct>(supplierProductDTO);

            await _dbSupplierProduct.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
