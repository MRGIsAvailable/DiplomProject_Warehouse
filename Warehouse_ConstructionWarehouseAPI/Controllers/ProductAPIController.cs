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
    [Route("api/ProductAPI")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IProductRepository _dbProduct;
        private readonly ICategoryRepository _dbCategory;
        private readonly IMapper _mapper;
        public ProductAPIController(IProductRepository dbProduct, IMapper mapper, ICategoryRepository dbCategory)
        {
            _dbProduct = dbProduct;
            _mapper = mapper;
            this._response = new();
            _dbCategory = dbCategory;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> GetProducts([FromQuery(Name = "filter")]string? search)
        {
            try
            {
                IEnumerable<Product> productList;

                if (!string.IsNullOrEmpty(search))
                {
                    productList = await _dbProduct.GetAllAsync(includePropertiesOne: "Category");
                    productList = productList.Where(u => u.ProductName.ToLower().Contains(search) || u.Details.ToLower().Contains(search));
                }
                else
                {
                    productList = await _dbProduct.GetAllAsync(includePropertiesOne: "Category");
                }

                _response.Result = _mapper.Map<List<ProductDTO>>(productList);
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

        [HttpGet("{id:int}", Name ="GetProduct")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetProduct(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var product = await _dbProduct.GetAsync(u => u.Id == id);
                if (product == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<ProductDTO>(product);
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
        public async Task<ActionResult<APIResponse>> CreateProduct([FromBody]ProductCreateDTO createDTO)
        {
            try
            {
                if (await _dbCategory.GetAsync(u => u.Id == createDTO.CategoryID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Category ID is Invalid");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Product product = _mapper.Map<Product>(createDTO);

                await _dbProduct.CreateAsync(product);

                _response.Result = _mapper.Map<ProductDTO>(product);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetProduct", new { id = product.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteProduct")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteProduct(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var product = await _dbProduct.GetAsync(u => u.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                await _dbProduct.RemoveAsync(product);
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

        [HttpPut("{id:int}", Name = "UpdateProduct")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdateProduct(int id, [FromBody]ProductUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                if (await _dbCategory.GetAsync(u => u.Id == updateDTO.CategoryID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Category ID is Invalid");
                    return BadRequest(ModelState);
                }

                Product model = _mapper.Map<Product>(updateDTO);

                await _dbProduct.UpdateAsync(model);

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

        [HttpPatch("{id:int}", Name = "UpdatePartialProduct")]
        [Authorize(Roles = "Администратор")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> UpdatePartialProduct(int id, JsonPatchDocument<ProductUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var product = await _dbProduct.GetAsync(u => u.Id == id, tracked: false);

            ProductUpdateDTO productDTO = _mapper.Map<ProductUpdateDTO>(product);

            if (product == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(productDTO, ModelState);

            Product model = _mapper.Map<Product>(productDTO);

            await _dbProduct.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
