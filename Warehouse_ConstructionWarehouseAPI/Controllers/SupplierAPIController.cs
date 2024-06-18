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
    [Route("api/SupplierAPI")]
    [ApiController]
    public class SupplierAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ISupplierRepository _dbSupplier;
        private readonly IMapper _mapper;
        public SupplierAPIController(ISupplierRepository dbSupplier, IMapper mapper)
        {
            _dbSupplier = dbSupplier;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> GetSuppliers([FromQuery(Name = "filter")] string? search)
        {
            try
            {
                IEnumerable<Supplier> supplierList;

                if (!string.IsNullOrEmpty(search))
                {
                    supplierList = await _dbSupplier.GetAllAsync();
                    supplierList = supplierList.Where(u => u.SupplierName.ToLower().Contains(search) || 
                    u.ContactName.ToLower().Contains(search) || u.Phone.ToLower().Contains(search) || u.Email.ToLower().Contains(search));
                }
                else
                {
                    supplierList = await _dbSupplier.GetAllAsync();
                }

                _response.Result = _mapper.Map<List<SupplierDTO>>(supplierList);
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

        [HttpGet("{id:int}", Name = "GetSupplier")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetSupplier(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var supplier = await _dbSupplier.GetAsync(u => u.Id == id);
                if (supplier == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<SupplierDTO>(supplier);
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
        public async Task<ActionResult<APIResponse>> CreateSupplier([FromBody] SupplierCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Supplier supplier = _mapper.Map<Supplier>(createDTO);

                await _dbSupplier.CreateAsync(supplier);

                _response.Result = _mapper.Map<SupplierDTO>(supplier);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetSupplier", new { id = supplier.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteSupplier")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteSupplier(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var supplier = await _dbSupplier.GetAsync(u => u.Id == id);
                if (supplier == null)
                {
                    return NotFound();
                }
                await _dbSupplier.RemoveAsync(supplier);
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

        [HttpPut("{id:int}", Name = "UpdateSupplier")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdateSupplier(int id, [FromBody] SupplierUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Supplier model = _mapper.Map<Supplier>(updateDTO);

                await _dbSupplier.UpdateAsync(model);

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

        [HttpPatch("{id:int}", Name = "UpdatePartialSupplier")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> UpdatePartialSupplier(int id, JsonPatchDocument<SupplierUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var supplier = await _dbSupplier.GetAsync(u => u.Id == id, tracked: false);

            SupplierUpdateDTO supplierDTO = _mapper.Map<SupplierUpdateDTO>(supplier);

            if (supplier == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(supplierDTO, ModelState);

            Supplier model = _mapper.Map<Supplier>(supplierDTO);

            await _dbSupplier.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
