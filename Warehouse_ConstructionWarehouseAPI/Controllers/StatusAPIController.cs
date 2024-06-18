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
    [Route("api/StatusAPI")]
    [ApiController]
    public class StatusAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IStatusRepository _dbStatus;
        private readonly IMapper _mapper;
        public StatusAPIController(IStatusRepository dbStatus, IMapper mapper)
        {
            _dbStatus = dbStatus;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> GetStatuses()
        {
            try
            {
                IEnumerable<Status> statusList = await _dbStatus.GetAllAsync();
                _response.Result = _mapper.Map<List<StatusDTO>>(statusList);
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

        [HttpGet("{id:int}", Name = "GetStatus")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetStatus(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var status = await _dbStatus.GetAsync(u => u.Id == id);
                if (status == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<StatusDTO>(status);
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
        public async Task<ActionResult<APIResponse>> CreateStatus([FromBody] StatusCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Status status = _mapper.Map<Status>(createDTO);

                await _dbStatus.CreateAsync(status);

                _response.Result = _mapper.Map<StatusDTO>(status);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetStatus", new { id = status.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteStatus")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteStatus(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var status = await _dbStatus.GetAsync(u => u.Id == id);
                if (status == null)
                {
                    return NotFound();
                }
                await _dbStatus.RemoveAsync(status);
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

        [HttpPut("{id:int}", Name = "UpdateStatus")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdateStatus(int id, [FromBody]StatusUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Status model = _mapper.Map<Status>(updateDTO);

                await _dbStatus.UpdateAsync(model);

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

        [HttpPatch("{id:int}", Name = "UpdatePartialStatus")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> UpdatePartialStatus(int id, JsonPatchDocument<StatusUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var status = await _dbStatus.GetAsync(u => u.Id == id, tracked: false);

            StatusUpdateDTO statusDTO = _mapper.Map<StatusUpdateDTO>(status);

            if (status == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(statusDTO, ModelState);

            Status model = _mapper.Map<Status>(statusDTO);

            await _dbStatus.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
