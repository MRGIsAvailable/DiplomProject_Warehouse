using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Warehouse_ConstructionWarehouseAPI.Data;
using Warehouse_ConstructionWarehouseAPI.Logging;
using Warehouse_ConstructionWarehouseAPI.Models;
using Warehouse_ConstructionWarehouseAPI.Models.Dto;

namespace Warehouse_ConstructionWarehouseAPI.Controllers
{
    [Route("api/WarehouseAPI")]
    [ApiController]
    public class WarehouseAPIController : ControllerBase
    {
        private readonly ILogging _logger;
        public WarehouseAPIController(ILogging logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WarehouseDTO>> GetWarehouses()
        {
            _logger.Log("Getting all warehouse", "");
            return Ok(WarehouseStore.WarehouseList);
        }

        [HttpGet("{id:int}", Name ="GetWarehouse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<WarehouseDTO> GetWarehouse(int id)
        {
            if (id == 0)
            {
                _logger.Log("Get Warehouse Error with Id" + id, "error");
                return BadRequest();
            }

            var Warehouse = WarehouseStore.WarehouseList.FirstOrDefault(u => u.Id == id);
            if (Warehouse == null)
            {
                return NotFound();
            }

            return Ok(WarehouseStore.WarehouseList.FirstOrDefault(u=>u.Id == id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<WarehouseDTO> CreateWarehouse([FromBody]WarehouseDTO warehouseDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (WarehouseStore.WarehouseList.FirstOrDefault(u=>u.Name.ToLower() == warehouseDTO.Name.ToLower())!=null) //Уникальность имени
            {
                ModelState.AddModelError("CustomError", "Warehouse already Exists!");
                return BadRequest(ModelState);
            }

            if (warehouseDTO == null)
            {
                return BadRequest(warehouseDTO);
            }
            if (warehouseDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            warehouseDTO.Id = WarehouseStore.WarehouseList.OrderByDescending(u=>u.Id).FirstOrDefault().Id + 1;
            WarehouseStore.WarehouseList.Add(warehouseDTO);

            return CreatedAtRoute("GetWarehouse", new { id = warehouseDTO.Id }, warehouseDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteWarehouse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteWarehouse(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var warehouse = WarehouseStore.WarehouseList.FirstOrDefault(u=>u.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }
            WarehouseStore.WarehouseList.Remove(warehouse);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateWarehouse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateWarehouse(int id, [FromBody]WarehouseDTO warehouseDTO)
        {
            if (warehouseDTO == null || id != warehouseDTO.Id)
            {
                return BadRequest();
            }
            var warehouse = WarehouseStore.WarehouseList.FirstOrDefault(u => u.Id == id);
            warehouse.Name = warehouseDTO.Name;
            warehouse.Sqft = warehouseDTO.Sqft;
            warehouse.Occupancy = warehouseDTO.Occupancy;

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialWarehouse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdatePartialWarehouse(int id, JsonPatchDocument<WarehouseDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var warehouse = WarehouseStore.WarehouseList.FirstOrDefault(u => u.Id == id);
            if (warehouse == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(warehouse, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
